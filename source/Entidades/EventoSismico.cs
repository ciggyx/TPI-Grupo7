namespace source.Entidades.EventoSismo
{
    public class EventoSismico
    {
        private DateTime fechaHoraOcurrencia;
        private float latitudEpicentro;
        private float longitudEpicentro;
        private float latitudHipocentro;
        private float longitudHipocentro;
        private float valorMagnitud;
        private List<SerieTemporal> serieTemporal;
        private Estado estado;
        private ClasificacionSismo clasificacionSismo;
        private AlcanceSismo alcanceSismo;
        private OrigenDeGeneracion origenDeGeneracion;
        private List<CambioEstado> listaCambioEstado;
        private MagnitudRichter magnitud;

        public EventoSismico(DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, float valorMagnitud, List<SerieTemporal> serieTemporal, Estado estado, ClasificacionSismo clasificacionSismo, AlcanceSismo alcanceSismo, OrigenDeGeneracion origenDeGeneracion, List<CambioEstado> listaCambioEstado, MagnitudRichter magnitud)
        {
            this.fechaHoraOcurrencia = fechaHoraOcurrencia;
            this.latitudEpicentro = latitudEpicentro;
            this.longitudEpicentro = longitudEpicentro;
            this.latitudHipocentro = latitudHipocentro;
            this.longitudHipocentro = longitudHipocentro;
            this.valorMagnitud = valorMagnitud;
            this.serieTemporal = serieTemporal;
            this.estado = estado;
            this.clasificacionSismo = clasificacionSismo;
            this.alcanceSismo = alcanceSismo;
            this.origenDeGeneracion = origenDeGeneracion;
            this.listaCambioEstado = listaCambioEstado;
            this.magnitud = magnitud;
        }

        public (DateTime fechaHoraOcurrencia, float latitudEpicentro, float longitudEpicentro, float latitudHipocentro, float longitudHipocentro, float valorMagnitud) getDatos()
        {
            return (
                // 10. getFechaHoraOcurrencia()
                fechaHoraOcurrencia: getFechaHoraOcurrencia(),
                // 11. getLatitudEpicentro()
                latitudEpicentro: getLatitudEpicentro(),
                // 12. getLongitudEpicentro()
                longitudEpicentro: getLongitudEpicentro(),
                // 13. getLatitudHipocentro()
                latitudHipocentro: getLatitudHipocentro(),
                // 14. getLongitudHipocentro()
                longitudHipocentro: getLongitudHipocentro(),
                // 15. getValorMagnitud()
                valorMagnitud: getValorMagnitud()
                );
        }

        public bool esPendienteRevision()
        {
            return estado.sosPendienteRevision(); //6. sosPendienteRevision
        }
        public bool esAutoDetectado()
        {
            return estado.sosAutoDetectado(); // 8. sosAutodetectado
        }
        public DateTime getFechaHoraOcurrencia() // 10. getFechaHoraOcurrenciaEvento()
        {
            return fechaHoraOcurrencia;
        }
        public float getLatitudEpicentro() // 11. getLatitudEpicentro() 
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
        public List<SerieTemporal> getSerieTemporal()
        {
            return serieTemporal;
        }

        public void bloquear(Estado estadoBloqueadoEnRevision, Empleado asLogueado, DateTime fechaHoraActual) //27. bloquear()
        {
            foreach (CambioEstado cambio in listaCambioEstado) // Loop [Buscar ultimo cambio estado]
            {
                // 29. esEstadoActual()
                if (cambio.esEstadoActual())
                {
                    //30. setFechaHoraFin()
                    cambio.setFechaHoraFin(fechaHoraActual);
                    break;
                }
            }
            //31. crearCambioEstado
            crearCambioEstado(fechaHoraActual, estadoBloqueadoEnRevision, asLogueado);
            //33. setEstado()
            setEstado(estadoBloqueadoEnRevision);
        }

        public void crearCambioEstado(DateTime fechaHoraActual, Estado estado, Empleado empleadoLogueado)
        {
            // 32. new() 
            // 73. new()
            listaCambioEstado.Add(new CambioEstado(fechaHoraActual, estado, empleadoLogueado));
        }

        public void setEstado(Estado estado)
        {
            this.estado = estado;
        }

        public float getValorMagnitud()
        {
            return valorMagnitud;
        }

        public (string Alcance, string Clasificacion, string Origen, List<DateTime> fechasMuestra, IEnumerable<(double Valor, string TipoMuestraDenominacion, string TipoMuestraUnidad, double TipoMuestraValorUmbral)> Detalles) getDatosSismicos()
        {
            var detalles = serieTemporal
            // 36. getMuestrasSismicas()
            .SelectMany(serie => serie.getMuestrasSismicas())
            // 37. getDetalleMuestrasSismicas()
            .SelectMany(muestra => muestra.getDetalleMuestraSismica())
            .Select(detalle => (
            // 38. getValor()
            Valor: detalle.getValor(),
            // 39. getDenominacion()
            TipoMuestraDenominacion: detalle.getTipoDeDato().getDenominacion(),
            // 40. getNombreUnidadMedida()
            TipoMuestraUnidad: detalle.getTipoDeDato().getNombreUnidadMedida(),
            // 41. getValorUmbral()
            TipoMuestraValorUmbral: detalle.getTipoDeDato().getValorUmbral()
            ));
            var fechasDeMuestra = serieTemporal
            .SelectMany(serie => serie.getMuestrasSismicas())
            .Select(muestra => muestra.getFecha())
            .ToList();

            return (
               // 42. getNombre()
               Alcance: alcanceSismo.getNombre(),
               // 43. getNombre()
               Clasificacion: clasificacionSismo.getNombre(),
               // 44. getNombre()
               Origen: origenDeGeneracion.getNombre(),
               fechasMuestra: fechasDeMuestra,
               Detalles: detalles
                    );

        }


        public void rechazar(DateTime fechaHoraActual, Estado estadoRechazado, Empleado empleadoLogueado)
        {
            foreach (CambioEstado cambio in listaCambioEstado)
            {
                // 70. esEstadoActual()
                if (cambio.esEstadoActual())
                {
                    // 71. setFechaHoraFin()
                    cambio.setFechaHoraFin(fechaHoraActual);
                    break;
                }
            }
            // 72. crearCambioEstado()
            crearCambioEstado(fechaHoraActual, estadoRechazado, empleadoLogueado);
            // 74. setEstado()
            setEstado(estadoRechazado);
        }
        public void confirmar(DateTime fechaHoraActual, Estado estadoConfirmado, Empleado empleadoLogueado)
        {
            foreach (CambioEstado cambio in listaCambioEstado)
            {
                if (cambio.esEstadoActual())
                {
                    cambio.setFechaHoraFin(fechaHoraActual);
                    break;
                }
            }
            crearCambioEstado(fechaHoraActual, estadoConfirmado, empleadoLogueado);
            setEstado(estadoConfirmado);
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

        public Estado getEstado()
        {
            return estado;
        }

    }


}
