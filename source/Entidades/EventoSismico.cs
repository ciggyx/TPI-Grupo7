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
        private List<CambioEstado> listaCambioEstado;
        private MagnitudRichter magnitud;


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


        public void getLatitudEpicentro()
        {

        }

        public void getLongitudEpicentro()
        {

        }

        public void getLatitudHipocentro()
        {

        }

        public void getLongitudHipocentro()
        {

        }

        public void bloquear(DateTime fechaHoraActual, Estado estadoBloqueado, Empleado empleadoLogueado)
        {
            foreach (CambioEstado cambio in listaCambioEstado)
            {
                if (cambio.esEstadoActual())
                {
                    cambio.setFechaHoraFin(fechaHoraActual);
                    break;
                }
            }
            crearCambioEstado(fechaHoraActual, estadoBloqueado, empleadoLogueado);
            setEstado(estadoBloqueado);
        }

        public void crearCambioEstado(DateTime fechaHoraActual, Estado estado, Empleado empleadoLogueado)
        {
            listaCambioEstado.Add(new CambioEstado(fechaHoraActual, estado, empleadoLogueado));
        }

        public void setEstado(Estado estado)
        {
            this.estado = estado;
        }

        public List<object> getDatosSismicos()
        {
            List<object> datos = [alcanceSismo.getNombre(), clasificacionSismo.getNombre(), origenDeGeneracion.getNombre()];
            return datos;

        }

        public void rechazar(DateTime fechaHoraActual, Estado estadoRechazado, Empleado empleadoLogueado)
        {
            foreach (CambioEstado cambio in listaCambioEstado)
                        {
                            if (cambio.esEstadoActual())
                            {
                                cambio.setFechaHoraFin(fechaHoraActual);
                                break;
                            }
                        }
                        crearCambioEstado(fechaHoraActual, estadoRechazado, empleadoLogueado);
                        setEstado(estadoRechazado);
        }
        public MagnitudRichter getMagnitud()
        {
            return magnitud;
        }
        public OrigenDeGeneracion getOrigen()
        {
            return origenDeGeneracion;
        }
            
        public AlcanceSismo getAlcance()
            {
                return alcanceSismo;
            }    
    }

    
}
