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
        private string fechaHoraOcurrencia;
        private float latitudEpicentro;
        private float longitudEpicentro;
        private float latitudHipocentro;
        private float longitudHipocentro;
        private List<EventoSismico> listaEventoSismicosSinRevision;
        private List<EventoSismico> listaEventoSismicos = new List<EventoSismico>();
        private EventoSismico eventoSismicoSeleccionado;
        private string fechaHoraActual;
        private Empleado asLogueado;
        private Estado estadoRechazado;
        private Estado estadoBloqueado;
        private List<SerieTemporal> listaSerieTemporales;
        private EstacionSismologica estacionSismologica;
        private string accionSobreEvento;
        private EstacionSismologica estacionSismologicaModificada;


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

        public void buscarEstadoBloqueadoEnRevision() { }

        public void getFechaHoraActual() { }

        public void buscarEmpleadoLogueado() { }

        public void bloquerEventoSismico() { }

        public void buscarDatosSismicos() { }

        public void buscarDatosEstacion() { }

        public void ordenarPorCodigo() { }

        public void llamarCUGenerarSismograma() { }

        public void tomarSeleccionDeMapa() { }

        public void tomarModificacionDatosES() { }

        public void tomarAccionSobreEvento() { }

        public void validarDatos() { }

        public void buscarEstadoRechazado() { }

        public void rechazarEventoSismico() { }

        public void finCU() { }


        private void cargarDataBase() // Metodo de testeo!
        {
        }
    }


    

}
