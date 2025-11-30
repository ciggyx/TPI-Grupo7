using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;

namespace source.Domain.Entities
{
    [Table("sismografos")]
    public class Sismografo
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(300)]
        public string? Caracteristicas { get; set; }

        [MaxLength(200)]
        public string? NombreModelo { get; set; }

        // FK a EstacionSismologica (ubicación)
        [ForeignKey(nameof(EstacionSismologica))]
        public int? EstacionSismologicaId { get; set; }
        public EstacionSismologica? EstacionSismologica { get; set; }

        public List<SerieTemporal> SerieTemporal { get; set; } = new();

        public Sismografo() { } // EntityFramework necesita esto para no romperse

        public Sismografo(EstacionSismologica estacionSismologica)
        {
            this.EstacionSismologica = estacionSismologica;
        }

        public bool sosMiSismografo(SerieTemporal serie)
        {
            foreach (SerieTemporal s in SerieTemporal)
            {
                if (SerieTemporal.Contains(serie))
                {
                    return true;
                }
            }
            return false;
        }

        public (string codigo, string nombre) getDatosEstacion()
        {
            return (
                // 53. getCodigo()
                codigo: EstacionSismologica.getCodigo(),
                // 54. getNombre()
                nombre: EstacionSismologica.getNombre()
            );
        }

        public void agregarSerieTemporal(SerieTemporal serie)
        {
            SerieTemporal.Add(serie);
        }
    }
}
