namespace source.Entidades.EventoSismo
{
    public class EventoSismico
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

        public void bloquear(DateTime fechaHoraActual, Estado estadoBloqueado, Empleado empleadoLogueado) //27.
        {
            foreach (CambioEstado cambio in listaCambioEstado) // Loop [Buscar ultimo cambio estado]
            {
                if (cambio.esEstadoActual()) //28.esEstadoActual
                {
                    cambio.setFechaHoraFin(fechaHoraActual); //29. setFechaHoraFin()
                    break;
                }
            } 
            crearCambioEstado(fechaHoraActual, estadoBloqueado, empleadoLogueado); //30. crearCambioEstado
            setEstado(estadoBloqueado);
        }

        public void crearCambioEstado(DateTime fechaHoraActual, Estado estado, Empleado empleadoLogueado)
        {
            listaCambioEstado.Add(new CambioEstado(fechaHoraActual, estado, empleadoLogueado)); //31. newBloqueado:CambioEstado
        }

        public void setEstado(Estado estado)
        {
            this.estado = estado;
        }

        public (string Alcance, string Clasificacion, string Origen, double MagnitudValor, IEnumerable<(double Valor, string TipoMuestraDenominacion, string TipoMuestraUnidad, double TipoMuestraValorUmbral)> Detalles) getDatosSismicos()
            {
            //Primero que nada lo que hace esta verga es crear una tupla llamada "detalles" donde se va a guardar cada dato de cada detalle
            //de cada muestra, de cada serie temporal
            var detalles = serieTemporal
            .SelectMany(serie => serie.getMuestrasSismicas())
            .SelectMany(muestra => muestra.getDetalleMuestraSismica())
            .Select(detalle => (
            Valor: detalle.getValor(),
            TipoMuestraDenominacion: detalle.getTipoDeDato().getDenomincacion(),
            TipoMuestraUnidad: detalle.getTipoDeDato().getNombreUnidadMedida(),
            TipoMuestraValorUmbral: detalle.getTipoDeDato().getValorUmbral()
            ));

            // Despues retorna una lista que esta compuesta de cada atributo unico del evento sismico en orden y al final la tupla anterior con todos los datos
            
            return (
               Alcance: alcanceSismo.getNombre(),
               Clasificacion: clasificacionSismo.getNombre(),
               Origen: origenDeGeneracion.getNombre(),
               MagnitudValor: magnitud.getNombre(),
               Detalles: detalles
                    );
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
