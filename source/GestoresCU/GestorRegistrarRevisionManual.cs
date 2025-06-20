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
        private List<EventoSismico> listaEventoSismicosSinRevision;
        private List<Estado> listaEstado;
        private List<EventoSismico> listaEventoSismicos = new List<EventoSismico>();
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


        //Constructor
        public GestorRegistrarRevisionManual(PantallaRegistrarResultado pantallaRegistrarResultado)
        {
            var EventoSismico = cargarDataBase(); //Aca estoy cargando un evento de prueba para testeo no mas esto no tendria que estar


            // 4. buscarEventosSimicosSinRevision
            listaEventoSismicosSinRevision = buscarEventoSismicoSinRevision(listaEventoSismicos);
            pantallaRegistrarResultado.mostrarEventoSismicoParaRevision(listaEventoSismicosSinRevision); // 16. mostrarEventoSimicosParaSeleccion
        }



        public void newRevisionManual() { }

        public List<EventoSismico> buscarEventoSismicoSinRevision(List<EventoSismico> listaEventosSimicos)
        {

            foreach (EventoSismico evento in listaEventoSismicosSinRevision) //Loop [Eventos Sismicos Auto Detectados]
            {
                //5. esPendienteRevision
                //7. esAutoDetectable
                if (evento.esPendienteRevision() || evento.esAutoDetectado())
                {
                    listaEventoSismicosSinRevision.Add(evento);
                    //9,10,11,12,13,14 (getDatos)
                }
            }

            return ordenarEventoSismicos(listaEventoSismicosSinRevision); // 15 OrdenarEventosSismicos
        }


        public List<EventoSismico> ordenarEventoSismicos(List<EventoSismico> listaEventoSismicosSinRevisionDesordenada)
        {
            return listaEventoSismicosSinRevisionDesordenada
                .OrderBy(evento => evento.getFechaHoraOcurrencia())
                .ToList();
        }

        public void tomarSeleccionEventoSismico() { }

        public Estado buscarEstadoBloqueadoEnRevision()//19. bsucarEstadoBloqueadoEnRevision()
        {
            foreach (Estado estado in listaEstado)
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
            fechaHoraActual = DateTime.Now;
            return fechaHoraActual;
        }

        public Empleado buscarEmpleadoLogueado()
        {
            return sesionActual.getUsuarioLogueado();
        }

        public void bloquearEventoSismico(EventoSismico eventoSismicoSeleccionado)
        {
            eventoSismicoSeleccionado.bloquear(getFechaHoraActual(), buscarEstadoBloqueadoEnRevision(), buscarEmpleadoLogueado());
        }

        public (string Alcance, string Clasificacion, string Origen, double MagnitudValor, IEnumerable<(double Valor, string TipoMuestraDenominacion, string TipoMuestraUnidad, double TipoMuestraValorUmbral)> Detalles) buscarDatosSismicos(EventoSismico evento) 
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

            return evento.getDatosSismicos(); 
            //La logica de la obtencion de la info esta adentro del metodo en EventoSismico, me asegure de que respete la encapsulacion,
            //osea esta todo hecho con gets()
            }

        public void buscarDatosEstacion()
        {


        }

        public void ordenarPorCodigo() { }

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
            foreach (Estado estado in listaEstado)
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


        public EventoSismico cargarDataBase() // Metodo de testeo!
        {
            var tipoDato = new TipoDeDato("Velocidad de onda", "km/seg", 7);
            var tipoDato2 = new TipoDeDato("Frecuencia de onda", "Hz", 10);
            var tipoDato3 = new TipoDeDato("Longitud", "km/ciclo", 0.7);

            var detalle = new DetalleMuestraSismica(1, tipoDato);
            var detalle2 = new DetalleMuestraSismica(2, tipoDato2);
            var detalle3 = new DetalleMuestraSismica(3, tipoDato3);

            var muestra = new MuestraSismica(DateTime.Now, new List<DetalleMuestraSismica> { detalle, detalle2, detalle3 });

            // ¿Por que hay que crear la lista acá de vuelta si ya la tengo arriba??? 
            var serie = new SerieTemporal(false, DateTime.Now, DateTime.Now.AddHours(1), 50, new List<MuestraSismica> { muestra });

            var empleado = new Empleado("Juan", "Pérez", "juan.perez@email.com", "3511234567");
            var usuario = new Usuario("juanperez", "juanperez123", empleado);
            var sesion = new Sesion(DateTime.Now, DateTime.Now.AddHours(2), usuario);

            var estadoPendiente = new Estado(Ambito.EventoSismico, "PendienteRevisión");
            var estadoBloqueado = new Estado(Ambito.Sismografo, "BloqueadoRevisión");

            var cambioEstado = new CambioEstado(DateTime.Now.AddMinutes(8), estadoPendiente, empleado);

            var alcance = new AlcanceSismo("Regional");
            // A chequear los floats que le chante de kms?
            var clasificacion = new ClasificacionSismo("Moderado", 500, 500);
            var origen = new OrigenDeGeneracion("Autodetección");
            var magnitud = new MagnitudRichter(10.0, "Legendario");

            var evento = new EventoSismico(
                DateTime.Now.AddHours(-1),
                (float)-31.42,   // latitud epicentro
                (float)-64.18,   // longitud epicentro
                (float)30.5,     // latitud hipocentro
                (float)-64.2,    // longitud hipocentro
                new List<SerieTemporal> { serie },
                estadoPendiente,
                clasificacion,
                alcance,
                origen,
                new List<CambioEstado> { cambioEstado },
                magnitud
            );

            return evento;
        }
    }




}
