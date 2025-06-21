using source.Boundarys;
using source.Entidades;
using source.Entidades.EventoSismo;

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

        public SerieTemporal SerieTemporalConEstacion { get; private set; }

        //Constructor
        public GestorRegistrarRevisionManual(PantallaRegistrarResultado pantallaRegistrarResultado)
        {
            this.pantallaRegistrarResultado = pantallaRegistrarResultado;
            Random random = new Random();
            int cantidad = random.Next(3, 7);
            var generador = new BaseTestDataGenerator();
            eventos = generador.GenerarEventosSismicos(cantidad);

            foreach (EventoSismico evento in eventos)
            {
                foreach (SerieTemporal serie in evento.getSerieTemporal())
                {
                    listaSerieTemporalesTotal.Add(serie);
                }
            }

            listaSismografos = generador.GenerarSismografos(listaSerieTemporalesTotal);
            listaEstados = generador.GenerarEstados();
            sesionActual = generador.GenerarSesion();

            // 4. buscarEventosSimicosSinRevision
            listaEventoSismicosSinRevision = buscarEventoSismicoSinRevision(eventos);
            pantallaRegistrarResultado.solicitarSeleccionEventoSismico(listaEventoSismicosSinRevision); // 16. mostrarEventoSimicosParaSeleccion
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
            estadoBloqueadoEnRevision = buscarEstadoBloqueadoEnRevision();
            fechaHoraActual = getFechaHoraActual(); // 22. getFechaHoraActual()
            asLogueado = buscarEmpleadoLogueado(); // 23. buscarEmpleadoLogueado()

            // 26. bloquearEventoSismico()
            bloquearEventoSismico(eventoSismicoSeleccionado, estadoBloqueadoEnRevision, asLogueado, fechaHoraActual);
            // 33. buscarDatosSismicos
            pantallaRegistrarResultado.mostrarDatos(buscarDatosSismicos(eventoSismicoSeleccionado));
            pantallaRegistrarResultado.solicitarSeleccionMapa();
        }
        public Estado buscarEstadoBloqueadoEnRevision()//19. buscarEstadoBloqueadoEnRevision()
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
            var datosSismicos = evento.getDatosSismicos();
            listaSerieTemporales = evento.getSerieTemporal();

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
            return serie.getEstacionSismografica(listaSismografos);
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

        public void tomarSeleccionMapa(string accionVisualizarMapa)
        {
            this.accionSobreVisualizarMapa = accionVisualizarMapa;
            // 57. solicitarModificacionDatosES()
            pantallaRegistrarResultado.solicitarModificacionDatosES(eventoSismicoSeleccionado);
        }

        public void tomarModificacionDatosES(string accionModificacionDatosES)
        {
            this.accionModificacionDatosES = accionModificacionDatosES;
            // 60. solicitarAccionSobreEvento()
            pantallaRegistrarResultado.solicitarAccionSobreEvento();
        }

        public void tomarAccionSobreEvento(string accionSobreEvento)
        {
            this.accionSobreEvento = accionSobreEvento;
            // 63. validarDatos()
            var datosValidados = validarDatos(eventoSismicoSeleccionado);
            if (datosValidados == true)
            {
                if (accionSobreEvento == "Rechazar evento")
                {
                    rechazarEventoSismico(getFechaHoraActual(), buscarEstadoRechazado(), asLogueado);
                }
                else if (accionSobreEvento == "Confirmar evento")
                {
                    confirmarEventoSismico(getFechaHoraActual(), buscarEstadoConfirmado(), asLogueado);
                }
                //67, 64, 68
                finCU();
            }
            else
            {
                MessageBox.Show("Datos invalidos");
            }
        }

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
                // 65 y 66
                if (estado.sosAmbitoEventoSismico() && estado.sosRechazado())
                {
                    return estado;
                }
            }
            return null;
        }

        public Estado buscarEstadoConfirmado()
        {
            foreach (Estado estado in listaEstados)
            {
                // 65 y 66
                if (estado.sosAmbitoEventoSismico() && estado.sosConfirmado())
                {
                    return estado;
                }
            }
            return null;
        }

        public void rechazarEventoSismico(DateTime fechaHoraActual, Estado estadoRechazado, Empleado empleadoLogueado)
        {
            eventoSismicoSeleccionado.rechazar(fechaHoraActual, estadoRechazado, empleadoLogueado);
        }

        public void confirmarEventoSismico(DateTime fechaHoraActual, Estado estadoConfirmado, Empleado empleadoLogueado)
        {
            eventoSismicoSeleccionado.confirmar(fechaHoraActual, estadoConfirmado, empleadoLogueado);
        }

        public void finCU()
        {
            MessageBox.Show("Resultado de revisión registrado correctamente");
            pantallaRegistrarResultado.Close();
        }
    }
}
