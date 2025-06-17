using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Entidades.EventoSismo
{
    public class EventoSismico
    {
        private DateTime fechaHoraOcurrencia;
        private float latitudEpicentro;
        private float longitudEpicentro;
        private float latitudHipocentro;
        private float longitudHipocentro;
        private SerieTemporal serieTemporal;
        private Estado estado;
        private ClasificacionSismo clasificacionSismo;
        private AlcanceSismo alcanceSismo;
        private OrigenDeGeneracion origenDeGeneracion;
        private CambioEstado cambioEstado;


        public bool esPendienteRevision()
        {
            return estado.sosPendienteRevision(); //6. sosPendienteRevision
        }
        public bool esAutoDetectado()
        {
            return estado.sosAutoDetectado(); // 8. sosAutodetectado
        }
        public DateTime getFechaHoraOcurrencia()
        {
            return fechaHoraOcurrencia;
        }


        public getLatitudEpicentro()
        {

        }

        public getLongitudEpicentro()
        {

        }

        public getLatitudHipocentro()
        {

        }

        public getLongitudHipocentro()
        {

        }

        public bloquear()
        {

        }

        public crearCambioEstado()
        {

        }

        public setEstado()
        {

        }

        public getDatosSismicos()
        {

        }

        public rechazar()
        {

        }

    }

    
}
