namespace source.Entidades.EventoSismo
{
    internal class EventoSismico
    {
        private DateTime fechaHoraOcurrencia;
        private float latitudEpicentro;
        private float longitudEpicentro;
        private float latitudHipocentro;
        private float longitudHipocentro;
        private List<SerieTemporal> serieTemporal;
        private Estado estado;
        private ClasificacionSismo clasificacionSismo;
        private AlcanceSismo alcanceSismo;
        private OrigenDeGeneracion origenDeGeneracion;
        private List<CambioEstado> listaCambioEstado;
        private MagnitudRichter magnitud;

        public EventoSismico(DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, List<SerieTemporal> serieTemporal, Estado estado, ClasificacionSismo clasificacionSismo, AlcanceSismo alcanceSismo, OrigenDeGeneracion origenDeGeneracion, List<CambioEstado> listaCambioEstado, MagnitudRichter magnitud)
        {
            this.fechaHoraOcurrencia = fechaHoraOcurrencia;
            this.latitudEpicentro = latitudEpicentro;
            this.longitudEpicentro = longitudEpicentro;
            this.latitudHipocentro = latitudHipocentro;
            this.longitudHipocentro = longitudHipocentro;
            this.serieTemporal = serieTemporal;
            this.estado = estado;
            this.clasificacionSismo = clasificacionSismo;
            this.alcanceSismo = alcanceSismo;
            this.origenDeGeneracion = origenDeGeneracion;
            this.listaCambioEstado = listaCambioEstado;
            this.magnitud = magnitud;
        }

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


        public float getLatitudEpicentro()
        {
            return latitudEpicentro;
        }

        public float getLongitudEpicentro()
        {
            return longitudEpicentro;
        }

        public float getLatitudHipocentro()
        {
            return latitudHipocentro;
        }

        public float getLongitudHipocentro()
        {
            return longitudHipocentro;
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
