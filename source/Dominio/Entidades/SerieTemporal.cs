using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace source.Domain.Entities
{
    [Table("series_temporales")]
    public class SerieTemporal
    {
        [Key]
        public int Id { get; set; }

        public bool CondicionAlarma { get; set; }

        public DateTime FechaHoraInicioRegistroMuestras { get; set; }

        public DateTime? FechaHoraRegistro { get; set; }

        // Frecuencia en Hz o en el intervalo que uses
        public double? FrecuenciaMuestreo { get; set; }

        // FK a EventoSismico
        [ForeignKey(nameof(EventoSismico))]
        public int? EventoSismicoId { get; set; }
        public EventoSismico? EventoSismico { get; set; }

        // Relación con muestras
        public List<MuestraSismica> MuestraSismica { get; set; } = new();

        // FK a Sismografo
        [ForeignKey(nameof(Sismografo))]
        public int? SismografoId { get; set; }
        public Sismografo? Sismografo { get; set; }

        private SerieTemporal() { } // EntityFramework necesita esto para no romperse

        public SerieTemporal(
            bool condicionAlarma,
            DateTime fechaHoraRegistroMuestras,
            DateTime fechaHoraRegistro,
            float frecuenciaMuestreo,
            List<MuestraSismica> muestraSismica
        )
        {
            this.CondicionAlarma = condicionAlarma;
            FechaHoraInicioRegistroMuestras = fechaHoraRegistroMuestras;
            this.FechaHoraRegistro = fechaHoraRegistro;
            this.FrecuenciaMuestreo = frecuenciaMuestreo;
            this.MuestraSismica = muestraSismica;
        }

        public List<MuestraSismica> getMuestrasSismicas()
        {
            return MuestraSismica;
        }

        public DateTime getFecha()
        {
            return FechaHoraInicioRegistroMuestras;
        }

        public (string codigo, string nombre) getEstacionSismografica(
            List<Sismografo> listaSismografo
        )
        {
            foreach (Sismografo sismografo in listaSismografo)
            {
                // 51. sosMiSismografo()
                if (sismografo.sosMiSismografo(this))
                {
                    // 52. getDatosEstacion()
                    return sismografo.getDatosEstacion();
                }
            }
            return (null, null);
        }
    }
}
