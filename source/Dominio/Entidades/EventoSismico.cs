using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using source.Dominio.Entidades.PatronState;
using source.Repositorios;

namespace source.Domain.Entities
{
    [Table("eventos_sismicos")]
    public class EventoSismico
    {
        [Key]
        public int Id { get; set; }

        public DateTime FechaHoraOcurrencia { get; set; }
        public DateTime? FechaHoraFin { get; set; }

        public float LatitudEpicentro { get; set; }
        public float LongitudEpicentro { get; set; }
        public float LatitudHipocentro { get; set; }
        public float LongitudHipocentro { get; set; }

        // Valor numérico de la magnitud, uso decimal para magnitudes
        public float ValorMagnitud { get; set; }

        // FK Many-to-One a MagnitudRichter
        [ForeignKey(nameof(Magnitud))]
        public int? MagnitudId { get; set; }
        public MagnitudRichter? Magnitud { get; set; }

        // FK a Estado (estado actual)
        [ForeignKey(nameof(Estado))]
        public int? EstadoId { get; set; }
        public Estado? Estado { get; set; }

        // FK a ClasificacionSismo
        [ForeignKey(nameof(ClasificacionSismo))]
        public int? ClasificacionSismoId { get; set; }
        public ClasificacionSismo? ClasificacionSismo { get; set; }

        // FK a AlcanceSismo
        [ForeignKey(nameof(AlcanceSismo))]
        public int? AlcanceSismoId { get; set; }
        public AlcanceSismo? AlcanceSismo { get; set; }

        // FK a OrigenDeGeneracion
        [ForeignKey(nameof(OrigenDeGeneracion))]
        public int? OrigenDeGeneracionId { get; set; }
        public OrigenDeGeneracion? OrigenDeGeneracion { get; set; }

        // Colecciones relacionadas
        public List<SerieTemporal> SerieTemporal { get; set; } = new();
        public List<CambioEstado> ListaCambioEstado { get; set; } = new();

        private EventoSismico() { } // EntityFramework necesita esto para no romperse

        public EventoSismico(
            DateTime fechaHoraOcurrencia,
            float latitudEpicentro,
            float longitudEpicentro,
            float latitudHipocentro,
            float longitudHipocentro,
            float valorMagnitud,
            List<SerieTemporal> serieTemporal,
            Estado estado,
            ClasificacionSismo clasificacionSismo,
            AlcanceSismo alcanceSismo,
            OrigenDeGeneracion origenDeGeneracion,
            List<CambioEstado> listaCambioEstado,
            MagnitudRichter magnitud
        )
        {
            this.FechaHoraOcurrencia = fechaHoraOcurrencia;
            this.LatitudEpicentro = latitudEpicentro;
            this.LongitudEpicentro = longitudEpicentro;
            this.LatitudHipocentro = latitudHipocentro;
            this.LongitudHipocentro = longitudHipocentro;
            this.ValorMagnitud = valorMagnitud;
            this.SerieTemporal = serieTemporal;
            this.Estado = estado;
            this.ClasificacionSismo = clasificacionSismo;
            this.AlcanceSismo = alcanceSismo;
            this.OrigenDeGeneracion = origenDeGeneracion;
            this.ListaCambioEstado = listaCambioEstado;
            this.Magnitud = magnitud;
        }

        public (
            DateTime fechaHoraOcurrencia,
            float latitudEpicentro,
            float longitudEpicentro,
            float latitudHipocentro,
            float longitudHipocentro,
            float valorMagnitud
        ) getDatos()
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
            return Estado.sosPendienteRevision(); //6. sosPendienteRevision
        }

        public bool esAutoDetectado()
        {
            return Estado.sosAutoDetectado(); // 8. sosAutodetectado
        }

        public DateTime getFechaHoraOcurrencia() // 10. getFechaHoraOcurrenciaEvento()
        {
            return FechaHoraOcurrencia;
        }

        public float getLatitudEpicentro() // 11. getLatitudEpicentro()
        {
            return LatitudEpicentro;
        }

        public float getLongitudEpicentro()
        {
            return LongitudEpicentro;
        }

        public float getLatitudHipocentro()
        {
            return LatitudHipocentro;
        }

        public float getLongitudHipocentro()
        {
            return LongitudHipocentro;
        }

        public List<SerieTemporal> getSerieTemporal()
        {
            return SerieTemporal;
        }

        public async Task<Estado> bloquear(
            Empleado asLogueado,
            DateTime fechaHoraActual,
            IRepositorioEstado repoEstado
        ) //25. bloquear()
        {
            // 26. bloquear()
            return await Estado.Bloquear(
                fechaHoraActual,
                asLogueado,
                ListaCambioEstado,
                this,
                repoEstado
            );
        }

        public void crearCambioEstado(
            DateTime fechaHoraActual,
            Estado estado,
            Empleado empleadoLogueado
        )
        {
            // 32. new()
            // 73. new()
            ListaCambioEstado.Add(new CambioEstado(fechaHoraActual, estado, empleadoLogueado));
        }

        public void setEstado(Estado estado)
        {
            this.Estado = estado;
        }

        public float getValorMagnitud()
        {
            return ValorMagnitud;
        }

        public (
            string Alcance,
            string Clasificacion,
            string Origen,
            List<DateTime> fechasMuestra,
            List<DateTime> fechasSeriesTemporales,
            IEnumerable<(
                double Valor,
                string TipoMuestraDenominacion,
                string TipoMuestraUnidad,
                double TipoMuestraValorUmbral
            )> Detalles
        ) getDatosSismicos()
        {
            var detalles = SerieTemporal
                // 39. getMuestrasSismicas()
                .SelectMany(serie => serie.getMuestrasSismicas())
                // 41. getDetalleMuestrasSismicas()
                .SelectMany(muestra => muestra.getDetalleMuestraSismica())
                .Select(detalle =>
                    (
                        // 42. getValor()
                        Valor: detalle.getValor(),
                        // 43. getDenominacion()
                        TipoMuestraDenominacion: detalle.getTipoDeDato().getDenominacion(),
                        // 44. getNombreUnidadMedida()
                        TipoMuestraUnidad: detalle.getTipoDeDato().getNombreUnidadMedida(),
                        // 45. getValorUmbral()
                        TipoMuestraValorUmbral: detalle.getTipoDeDato().getValorUmbral()
                    )
                );
            var fechasDeMuestra = SerieTemporal
                .SelectMany(serie => serie.getMuestrasSismicas())
                // 40. getFecha()
                .Select(muestra => muestra.getFecha())
                .ToList();

            var fechasDeSerie = SerieTemporal.Select(serie => serie.getFecha()).ToList();

            return (
                // 46. getNombre()
                Alcance: AlcanceSismo.getNombre(),
                // 47. getNombre()
                Clasificacion: ClasificacionSismo.getNombre(),
                // 48. getNombre()
                Origen: OrigenDeGeneracion.getNombre(),
                fechasMuestra: fechasDeMuestra,
                fechasSeriesTemporales: fechasDeSerie,
                Detalles: detalles
            );
        }

        public async Task<Estado> rechazar(
            DateTime fechaHoraActual,
            Empleado empleadoLogueado,
            IRepositorioEstado repoEstado
        )
        {
            //71. rechazar()
            return await Estado.Rechazar(
                fechaHoraActual,
                empleadoLogueado,
                ListaCambioEstado,
                this,
                repoEstado
            );
        }

        public async Task<Estado> confirmar(
            DateTime fechaHoraActual,
            Empleado empleadoLogueado,
            IRepositorioEstado repoEstado
        )
        {
            return await Estado.Confirmar(
                fechaHoraActual,
                empleadoLogueado,
                ListaCambioEstado,
                this,
                repoEstado
            );
        }

        public MagnitudRichter getMagnitud()
        {
            return Magnitud;
        }

        public OrigenDeGeneracion getOrigen()
        {
            return OrigenDeGeneracion;
        }

        public AlcanceSismo getAlcance()
        {
            return AlcanceSismo;
        }

        public Estado getEstado()
        {
            return Estado;
        }

        public void agregarCambioEstado(CambioEstado cambioEstado)
        {
            ListaCambioEstado.Add(cambioEstado);
        }
    }
}
