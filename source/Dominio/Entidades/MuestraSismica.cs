using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace source.Domain.Entities
{
    [Table("muestras_sismicas")]
    public class MuestraSismica
    {
        [Key]
        public int Id { get; set; }

        public DateTime FechaHoraMuestra { get; set; }

        // Relación con SerieTemporal (opcional)
        [ForeignKey(nameof(SerieTemporal))]
        public int? SerieTemporalId { get; set; }
        public SerieTemporal? SerieTemporal { get; set; }

        // Detalle de la muestra
        public List<DetalleMuestraSismica> DetalleMuestraSismica { get; set; } = new();

        private MuestraSismica() { } // EntityFramework necesita esto para no romperse

        public MuestraSismica(
            DateTime fechaHoraMuestra,
            List<DetalleMuestraSismica> detalleMuestraSismicas
        )
        {
            this.FechaHoraMuestra = fechaHoraMuestra;
            DetalleMuestraSismica = detalleMuestraSismicas;
        }

        public List<DetalleMuestraSismica> getDetalleMuestraSismica()
        {
            return DetalleMuestraSismica;
        }

        public DateTime getFecha()
        {
            return FechaHoraMuestra;
        }
    }
}
