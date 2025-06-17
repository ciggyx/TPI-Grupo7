using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Entidades.EventoSismo
{
    internal class EventoSismico
    {
        private string fechaHoraOcurrencia;
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

    }

    public Boolean esPendienteRevision()
        {
            return true;
        }
    public Boolean esAutoDetectado()
        {
            return true;
        }

    public getFechaHoraOcurrenciaDatos()
        {
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
