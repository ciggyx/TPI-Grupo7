using System.ComponentModel;
using source.Boundarys;
using source.Entidades;
using source.Entidades.EventoSismo;
using source.GestoresCU.DTO;

namespace source.GestoresCU
{
    internal class GestorRegistrarRevisionManual
    {
        private DateTime fechaHoraOcurrencia;
        private float latitudEpicentro;
        private float longitudEpicentro;
        private float latitudHipocentro;
        private float longitudHipocentro;
        private List<(DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, float valorMagnitud)> listaEventoSismicosSinRevision = new();
        private List<Estado> listaEstados;
        private List<EventoSismico> listaEventosSismicos = new List<EventoSismico>();
        private EventoSismico eventoSismicoSeleccionado;
        private DateTime fechaHoraActual;
        private Empleado asLogueado;
        private Estado estadoRechazado;
        private Estado estadoBloqueado;
        private List<SerieTemporal> listaSerieTemporales;
        private EstacionSismologica estacionSismologica;
        private string accionSobreEvento;
        private EstacionSismologica estacionSismologicaModificada;
        private Sesion sesionActual;
        private List<Sismografo> listaSismografo; // Se usa para testing, despues esto no va en el modelo final
        private Estado estadoBloqueadoEnRevision;
        private List<EventoSismico> eventos = new List<EventoSismico>();

        public SerieTemporal SerieTemporalConEstacion { get; private set; }


        //Constructor
        public GestorRegistrarRevisionManual(PantallaRegistrarResultado pantallaRegistrarResultado)
        {
            var generador = new BaseTestDataGenerator();
            eventos = generador.GenerarEventosSismicos();
            listaEstados = generador.GenerarEstados();
            sesionActual = generador.GenerarSesion();

            // 4. buscarEventosSimicosSinRevision
            listaEventoSismicosSinRevision = buscarEventoSismicoSinRevision(eventos);
            pantallaRegistrarResultado.mostrarEventoSismicoParaRevision(listaEventoSismicosSinRevision); // 16. mostrarEventoSimicosParaSeleccion
            estadoBloqueadoEnRevision = buscarEstadoBloqueadoEnRevision();
            fechaHoraActual = getFechaHoraActual(); // 22. getFechaHoraActual()
            asLogueado = buscarEmpleadoLogueado(); // 23. buscarEmpleadoLogueado()
            // 26. bloquearEventoSismico()
            //bloquearEventoSismico(eventoSismicoSeleccionado, estadoBloqueadoEnRevision, asLogueado, fechaHoraActual);
        }



        public void newRevisionManual() { }

        public List<(DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, float valorMagnitud)> buscarEventoSismicoSinRevision(List<EventoSismico> listaEventosSismicos)
        {
            var listaEventoSismicosSinRevision = new List<(DateTime, float, float, float, float, float)>();
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

            return ordenarEventoSismicos(listaEventoSismicosSinRevision); // 15 OrdenarEventosSismicos
        }


        public List<(DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, float valorMagnitud)> ordenarEventoSismicos(List<(DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, float valorMagnitud)> listaEventoSismicosSinRevisionDesordenada)
        {
            return listaEventoSismicosSinRevisionDesordenada
                .OrderBy(evento => evento.fechaHoraOcurrencia)
                .ToList();
        }

        public void tomarSeleccionEventoSismico((DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, float valorMagnitud) eventoSeleccionado) // 18.tomarSeleccionEventoSismico()
        {
            // falopa lo de los numeros? matematicas
            this.eventoSismicoSeleccionado = eventos.FirstOrDefault(e =>
                e.getFechaHoraOcurrencia() == eventoSeleccionado.fechaHoraOcurrencia &&
                Math.Abs(e.getLatitudEpicentro() - eventoSeleccionado.latitudEpicentro) < 0.0001f &&
                Math.Abs(e.getLongitudEpicentro() - eventoSeleccionado.longitudEpicentro) < 0.0001f &&
                Math.Abs(e.getLatitudHipocentro() - eventoSeleccionado.latitudHipocentro) < 0.0001f &&
                Math.Abs(e.getLongitudHipocentro() - eventoSeleccionado.longitudHipocentro) < 0.0001f &&
                Math.Abs(e.getValorMagnitud() - eventoSeleccionado.valorMagnitud) < 0.0001f
            );
        }
        public Estado buscarEstadoBloqueadoEnRevision()//19. bsucarEstadoBloqueadoEnRevision()
        {
            foreach (Estado estado in listaEstados)
            {
                if (estado.sosAmbitoEventoSismico() && estado.sosBloqueadoEnRevision())
                {
                    return estado;
                }
            }
            return null;
        }

        public DateTime getFechaHoraActual()
        {
            return DateTime.Now;
        }

        public Empleado buscarEmpleadoLogueado()
        {
            return sesionActual.getUsuarioLogueado();
        }

        public void bloquearEventoSismico(EventoSismico eventoSismicoSeleccionado, Estado estadoBloqueadoEnRevision, Empleado asLogueado, DateTime fechaHoraActual)
        {
            eventoSismicoSeleccionado.bloquear(estadoBloqueadoEnRevision, asLogueado, fechaHoraActual);
        }

        public (string Alcance, string Clasificacion, string Origen, double MagnitudValor,
        IEnumerable<(double Valor, string TipoMuestraDenominacion, string TipoMuestraUnidad, double TipoMuestraValorUmbral, string EstacionCodigo, string EstacionNombre)> Detalles) buscarDatosSismicos(EventoSismico evento)
        {
            //Esta aberracion de metodo retorna una lista gigante que contiene, primero los datos unicos de cada EventoSismico (los del punto 9.1) 
            //uno atras del otro en el orden que estan listados ahi, y despues el ultimo elemento de la lista es una tupla que contiene todos los datos
            //de todos los detalles de todas las muestras sismicas, de todas las series temporales del eventoSismico.
            //La tupla viene contenida en un enumerator llamado Detalles, osea que para acceder a los datos de la tupla tenes que primero entrar en el detalle
            //pero para los datos de la lista no hace falta. por ejemplo:

            // resultado = buscarDatosSismicos()
            // resultado.Alcance -> Te da el string del alcance
            // resultado.Detalle.ToList() -> te da la lista entera con los chorrosientos millones de informacion acoplada

            //Segun Gepeto la mejor forma de mostrar esto es poner los datos unicos en labels y para el Detalle usar un Grid, como no se manejar las pantallas
            //se lo dejo al pedro eso.

            var datosSismicos = evento.getDatosSismicos();
            listaSerieTemporales = evento.getSerieTemporal();
            
            //La logica de la obtencion de la info esta adentro del metodo en EventoSismico, me asegure de que respete la encapsulacion,
            //osea esta todo hecho con gets()
            
            var seriesOrdenadas = ordenarPorCodigo(datosSismicos.Detalles, listaSerieTemporales);

            return (
                datosSismicos.Alcance,
                datosSismicos.Clasificacion, 
                datosSismicos.Origen, 
                datosSismicos.MagnitudValor,
                Detalles: seriesOrdenadas
                );
        }

        public (string codigo, string nombre) buscarDatosEstacion(SerieTemporal serie)
        {
            
            return serie.getEstacionSismografica(listaSismografo);
        
        }

        public IEnumerable<(double Valor, string TipoMuestraDenominacion, string TipoMuestraUnidad, double TipoMuestraValorUmbral, string EstacionCodigo, string EstacionNombre)> ordenarPorCodigo(IEnumerable<(double Valor, string TipoMuestraDenominacion, string TipoMuestraUnidad, double TipoMuestraValorUmbral)> serieTemporalParaMostrar, List<SerieTemporal> serieTemporales)
        {
            var resultado = new List<(double Valor, string TipoMuestraDenominacion, string TipoMuestraUnidad, double TipoMuestraValorUmbral, string Codigo, string EstacionNombre)>();

            int index = 0;

            foreach (SerieTemporal serie in serieTemporales)
            {
                var (codigo, nombre) = buscarDatosEstacion(serie);
                var dato = serieTemporalParaMostrar.ElementAt(index);
                resultado.Add((dato.Valor, dato.TipoMuestraDenominacion, dato.TipoMuestraUnidad, dato.TipoMuestraValorUmbral, codigo, nombre));
                index = index + 1;
            }
            return resultado.OrderBy(x => x.Codigo);
        }

        public void llamarCUGenerarSismograma() { }

        public void tomarSeleccionDeMapa() { }

        public void tomarModificacionDatosES() { }

        public void tomarAccionSobreEvento() { }

        public bool validarDatos(EventoSismico eventoSismico)
        {
            if (eventoSismico.getMagnitud() is null || eventoSismico.getOrigen() is null || eventoSismico.getAlcance() is null || accionSobreEvento is null)
            {
                return false;
            }
            return true;
        }

        public Estado buscarEstadoRechazado()
        {
            foreach (Estado estado in listaEstados)
            {
                if (estado.sosAmbitoEventoSismico() && estado.sosRechazado())
                {
                    return estado;
                }
            }
            return null;
        }

        public void rechazarEventoSismico()
        {
            eventoSismicoSeleccionado.rechazar(getFechaHoraActual(), buscarEstadoBloqueadoEnRevision(), buscarEmpleadoLogueado());
        }

        public void finCU()
        {
            //qué diantres hace esto?
        }

    }




}
