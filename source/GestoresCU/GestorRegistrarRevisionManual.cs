using source.Boundarys;
using source.Entidades;
using source.Entidades.EventoSismo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.GestoresCU
{
    internal class GestorRegistrarRevisionManual
    {
        //ATRIBUTOS
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
            // 4. buscarEventosSimicosSinRevision
            listaEventoSismicosSinRevision = buscarEventoSismicoSinRevision(listaEventoSismicos);
            pantallaRegistrarResultado.mostrarEventoSismicoParaRevision(listaEventoSismicosSinRevision); // 16. mostrarEventoSimicosParaSeleccion
        }



        public void  newRevisionManual() { }

        public List<EventoSismico> buscarEventoSismicoSinRevision(List<EventoSismico> listaEventosSimicos) 
        {

            foreach(EventoSismico evento in listaEventoSismicosSinRevision) //Loop [Eventos Sismicos Auto Detectados]
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
            eventoSismicoSeleccionado.bloquear(getFechaHoraActual(), buscarEstadoBloqueadoEnRevision(),buscarEmpleadoLogueado());
        }

        public void buscarDatosSismicos(EventoSismico eventoSismicoSeleccionado)
        {
            eventoSismicoSeleccionado.getDatosSismicos();
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


        private void cargarDataBase() // Metodo de testeo!
        {
        }
    }


    

}
