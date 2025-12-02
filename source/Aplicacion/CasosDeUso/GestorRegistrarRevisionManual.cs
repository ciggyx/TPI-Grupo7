using System.CodeDom;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using source.Boundarys;
using source.Domain.Entities;
using source.Dominio.Entidades.PatronState;
using source.Repositorios;

namespace source.Application.UseCases
{
    internal class GestorRegistrarRevisionManual
    {
        private DateTime fechaHoraOcurrencia;
        private float latitudEpicentro;
        private float longitudEpicentro;
        private float latitudHipocentro;
        private float longitudHipocentro;
        private List<(
            DateTime fechaHoraOcurrencia,
            float latitudEpicentro,
            float longitudEpicentro,
            float latitudHipocentro,
            float longitudHipocentro,
            float valorMagnitud
        )> listaEventoSismicosSinRevision = new();
        private List<Estado> listaEstados;
        private List<EventoSismico> listaEventosSismicos = new List<EventoSismico>();
        private EventoSismico eventoSismicoSeleccionado;
        private DateTime fechaHoraActual;
        private Empleado asLogueado;
        private Estado estadoRechazado;
        private Estado estadoBloqueado;
        private List<SerieTemporal> listaSerieTemporales;
        private EstacionSismologica estacionSismologica;
        private string accionSobreVisualizarMapa;
        private string accionSobreEvento;
        private string accionModificacionDatosES;
        private EstacionSismologica estacionSismologicaModificada;
        private Sesion sesionActual;
        private List<Sismografo> listaSismografos; // Se usa para testing, despues esto no va en el modelo final
        private Estado estadoBloqueadoEnRevision;
        private List<EventoSismico> eventos = new List<EventoSismico>();
        private PantallaRegistrarResultado pantallaRegistrarResultado;
        private List<SerieTemporal> listaSerieTemporalesTotal = new List<SerieTemporal>();
        private readonly IRepositorioEventoSismico eventoSismicoRepo;
        private readonly IRepositorioSismografo sismografoRepo;
        private readonly IRepositorioEstado estadoRepo;
        private readonly IRepositorioSesion sesionRepo;
        private readonly IUnitOfWork unitOfWork;

        public SerieTemporal SerieTemporalConEstacion { get; private set; }

        public GestorRegistrarRevisionManual(
            IRepositorioEventoSismico eventoSismicoRepo,
            IRepositorioSismografo sismografoRepo,
            IRepositorioEstado estadoRepo,
            IRepositorioSesion sesionRepo,
            IUnitOfWork unitOfWork
        )
        {
            this.eventoSismicoRepo = eventoSismicoRepo;
            this.sismografoRepo = sismografoRepo;
            this.estadoRepo = estadoRepo;
            this.sesionRepo = sesionRepo;
            this.unitOfWork = unitOfWork;
        }

        // Este método es necesario porque no se puede llamar métodos asíncronos
        // en un constructor(antes estaba en el gestor).
        public async Task InitAsync()
        {
            eventos = (await eventoSismicoRepo.ObtenerTodosConSeriesAsync()).ToList();

            listaSerieTemporalesTotal = eventos.SelectMany(e => e.SerieTemporal).ToList();
            foreach (EventoSismico evento in eventos)
            {
                foreach (SerieTemporal serie in evento.getSerieTemporal())
                {
                    listaSerieTemporalesTotal.Add(serie);
                }
            }

            listaSismografos = (await sismografoRepo.ObtenerTodosAsyncConEstacion()).ToList();
            listaEstados = (await estadoRepo.ObtenerTodosAsync()).ToList();
            sesionActual = await sesionRepo.ObtenerPorIdAsync(1);
        }

        public void IniciarFlujoRevisionManual()
        {
            // 4. buscarEventosSimicosSinRevision()
            listaEventoSismicosSinRevision = buscarEventoSismicoSinRevision(eventos);
            // 17. solicitarSeleccionEventoSismico()
            pantallaRegistrarResultado.solicitarSeleccionEventoSismico(
                listaEventoSismicosSinRevision
            );
        }

        public void SetPantalla(PantallaRegistrarResultado pantalla)
        {
            this.pantallaRegistrarResultado = pantalla;
        }

        public void newRevisionManual() { }

        public List<(
            DateTime fechaHoraOcurrencia,
            float latitudEpicentro,
            float longitudEpicentro,
            float latitudHipocentro,
            float longitudHipocentro,
            float valorMagnitud
        )> buscarEventoSismicoSinRevision(List<EventoSismico> listaEventosSismicos)
        {
            var listaEventoSismicosSinRevision =
                new List<(DateTime, float, float, float, float, float)>();
            foreach (EventoSismico evento in listaEventosSismicos) //Loop [Eventos Sismicos Auto Detectados]
            {
                //5. esPendienteRevision
                //7. esAutoDetectable
                if (evento.esPendienteRevision() || evento.esAutoDetectado())
                {
                    // 9. getDatos()
                    listaEventoSismicosSinRevision.Add(evento.getDatos());
                }
            }

            // 16. ordenarEventosSismicos()
            return ordenarEventosSismicos(listaEventoSismicosSinRevision);
        }

        public List<(
            DateTime fechaHoraOcurrencia,
            float latitudEpicentro,
            float longitudEpicentro,
            float latitudHipocentro,
            float longitudHipocentro,
            float valorMagnitud
        )> ordenarEventosSismicos(
            List<(
                DateTime fechaHoraOcurrencia,
                float latitudEpicentro,
                float longitudEpicentro,
                float latitudHipocentro,
                float longitudHipocentro,
                float valorMagnitud
            )> listaEventoSismicosSinRevisionDesordenada
        )
        {
            return listaEventoSismicosSinRevisionDesordenada
                .OrderBy(evento => evento.fechaHoraOcurrencia)
                .ToList();
        }

        public async void tomarSeleccionEventoSismico(
            (
                DateTime fechaHoraOcurrencia,
                float latitudEpicentro,
                float longitudEpicentro,
                float latitudHipocentro,
                float longitudHipocentro,
                float valorMagnitud
            ) eventoSeleccionado
        ) // 18.tomarSeleccionEventoSismico()
        {
            eventoSismicoSeleccionado = eventos.FirstOrDefault(e =>
                e.getFechaHoraOcurrencia() == eventoSeleccionado.fechaHoraOcurrencia
                && Math.Abs(e.getLatitudEpicentro() - eventoSeleccionado.latitudEpicentro) < 0.0001f
                && Math.Abs(e.getLongitudEpicentro() - eventoSeleccionado.longitudEpicentro)
                    < 0.0001f
                && Math.Abs(e.getLatitudHipocentro() - eventoSeleccionado.latitudHipocentro)
                    < 0.0001f
                && Math.Abs(e.getLongitudHipocentro() - eventoSeleccionado.longitudHipocentro)
                    < 0.0001f
                && Math.Abs(e.getValorMagnitud() - eventoSeleccionado.valorMagnitud) < 0.0001f
            );
            // 20. bloquearEventoSismico()
            await bloquearEventoSismico();
            // 36. buscarDatosSismicos()
            // 57. mostrarDatos()
            pantallaRegistrarResultado.mostrarDatos(buscarDatosSismicos(eventoSismicoSeleccionado));
            pantallaRegistrarResultado.solicitarSeleccionMapa();
        }

        public async Task bloquearEventoSismico()
        {
            unitOfWork.Begin();
            // 21. getFechaHoraActual()
            fechaHoraActual = getFechaHoraActual();
            // 22. buscarEmpleadoLogueado()
            asLogueado = buscarEmpleadoLogueado();
            // 25. bloquear()
            await eventoSismicoSeleccionado.bloquear(asLogueado, fechaHoraActual, estadoRepo);
            unitOfWork.Commit();

        }

        public DateTime getFechaHoraActual()
        {
            return DateTime.UtcNow;
        }

        public Empleado buscarEmpleadoLogueado()
        {
            // 23. getUsuarioLogueado()
            return sesionActual.getUsuarioLogueado();
        }

        public (
            string Alcance,
            string Clasificacion,
            string Origen,
            List<DateTime> fechasMuestra,
            List<DateTime> fechasSeriesTemporales,
            float valorMagnitud,
            IEnumerable<(
                int numeroSerieTemporal,
                int numeroMuestra,
                double Valor,
                string TipoMuestraDenominacion,
                string TipoMuestraUnidad,
                double TipoMuestraValorUmbral,
                string EstacionCodigo,
                string EstacionNombre
            )> Detalles
        ) buscarDatosSismicos(EventoSismico evento)
        {
            // 37. getDatosSismicos()
            var datosSismicos = evento.getDatosSismicos();
            listaSerieTemporales = evento.getSerieTemporal();

            // 49. ordenarPorCodigo()
            var seriesOrdenadas = ordenarPorCodigo(datosSismicos.Detalles, listaSerieTemporales);

            return (
                datosSismicos.Alcance,
                datosSismicos.Clasificacion,
                datosSismicos.Origen,
                datosSismicos.fechasMuestra,
                datosSismicos.fechasSeriesTemporales,
                eventoSismicoSeleccionado.getValorMagnitud(),
                Detalles: seriesOrdenadas
            );
        }

        public (string codigo, string nombre) buscarDatosEstacion(SerieTemporal serie)
        {
            return serie.getEstacionSismografica(listaSismografos);
        }

        public IEnumerable<(
            int numeroSerieTemporal,
            int numeroMuestra,
            double Valor,
            string TipoMuestraDenominacion,
            string TipoMuestraUnidad,
            double TipoMuestraValorUmbral,
            string EstacionCodigo,
            string EstacionNombre
        )> ordenarPorCodigo(
            IEnumerable<(
                double Valor,
                string TipoMuestraDenominacion,
                string TipoMuestraUnidad,
                double TipoMuestraValorUmbral
            )> serieTemporalParaMostrar,
            List<SerieTemporal> serieTemporales
        )
        {
            var resultados =
                new List<(
                    int numeroSerieTemporal,
                    int numeroMuestra,
                    double Valor,
                    string TipoMuestraDenominacion,
                    string TipoMuestraUnidad,
                    double TipoMuestraValorUmbral,
                    string Codigo,
                    string EstacionNombre
                )>();
            for (int k = 0; k < serieTemporales.Count; k++)
            {
                // 50. getEstacionSismografica()
                var (codigo, nombre) = serieTemporales[k].getEstacionSismografica(listaSismografos);

                for (int j = 0; j < serieTemporales[k].getMuestrasSismicas().Count; j++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var dato = serieTemporalParaMostrar.ElementAt(i);
                        var nuevoElemento = (
                            k + 1,
                            j + 1,
                            dato.Valor,
                            dato.TipoMuestraDenominacion,
                            dato.TipoMuestraUnidad,
                            dato.TipoMuestraValorUmbral,
                            codigo,
                            nombre
                        );

                        resultados.Add(nuevoElemento);
                    }
                }
            }
            return resultados;
        }

        // 55. llamarCUGenerarSismograma()
        public void llamarCUGenerarSismograma() { }

        public void tomarSeleccionMapa(string accionVisualizarMapa)
        {
            accionSobreVisualizarMapa = accionVisualizarMapa;
            // 61. solicitarModificacionDatosES()
            pantallaRegistrarResultado.solicitarModificacionDatosES(eventoSismicoSeleccionado);
        }

        public void tomarModificacionDatosES(string accionModificacionDatosES)
        {
            this.accionModificacionDatosES = accionModificacionDatosES;
            // 64. solicitarAccionSobreEvento()
            pantallaRegistrarResultado.solicitarAccionSobreEvento();
        }

        public async void tomarAccionSobreEvento(string accionSobreEvento)
        {
            this.accionSobreEvento = accionSobreEvento;
            // 67. validarDatos()
            var datosValidados = validarDatos(eventoSismicoSeleccionado);
            if (datosValidados)
            {
                switch (accionSobreEvento)
                {
                    case "Rechazar evento":
                        // 68. rechazarEventoSismico()
                        await rechazarEventoSismico();
                        break;

                    case "Confirmar evento":
                        await confirmarEventoSismico();
                        break;

                    case "Cancelar revision evento" when eventoSismicoSeleccionado != null:
                        await cancelarRevisionEventoSismico();
                        return;   

                    default:
                        MessageBox.Show("Acción no reconocida o inválida.");
                        return;
                }
                // 75. finCU()
                finCU();   
            }
            else
            {
                MessageBox.Show("Datos invalidos");
            }

        }

        public async Task rechazarEventoSismico()
        {
            unitOfWork.Begin();
            // 69. getFechaHoraActual()
            fechaHoraActual = getFechaHoraActual();
            // 70. rechazar()
            await eventoSismicoSeleccionado.rechazar(fechaHoraActual, asLogueado, estadoRepo);
            unitOfWork.Commit();
        }

        public bool validarDatos(EventoSismico eventoSismico)
        {
            if (
                eventoSismico.getMagnitud() is null
                || eventoSismico.getOrigen() is null
                || eventoSismico.getAlcance() is null
                || accionSobreEvento is null
            )
            {
                return false;
            }
            return true;
        }

        public async Task confirmarEventoSismico()
        {
            unitOfWork.Begin();
            fechaHoraActual = getFechaHoraActual();
            await eventoSismicoSeleccionado.confirmar(fechaHoraActual, asLogueado, estadoRepo);
            unitOfWork.Commit();
        }
        public async Task cancelarRevisionEventoSismico()
        {
            unitOfWork.Begin();
            fechaHoraActual = getFechaHoraActual();
            await eventoSismicoSeleccionado.cancelar(fechaHoraActual, asLogueado, estadoRepo);
            unitOfWork.Commit();
        }

        public void finCU()
        {
            try
            {
                MessageBox.Show("Resultado de revisión registrado correctamente");
                pantallaRegistrarResultado.Close();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                MessageBox.Show("Error al guardar cambios: " + ex.Message);
            }
        }
    }
}
