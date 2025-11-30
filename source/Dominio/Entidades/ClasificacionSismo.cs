using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace source.Domain.Entities
{
    [Table("clasificaciones_sismo")]
    public class ClasificacionSismo
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; } = "";

        public double? KmProfundidadDesde { get; set; }
        public double? KmProfundidadHasta { get; set; }

        private ClasificacionSismo() { } // EntityFramework necesita esto para no romperse

        public ClasificacionSismo(string nombre, float kmProfundidadDesde, float kmProfundidadHasta)
        {
            this.Nombre = nombre;
            this.KmProfundidadDesde = kmProfundidadDesde;
            this.KmProfundidadHasta = kmProfundidadHasta;
        }

        public string getNombre()
        {
            return Nombre;
        }
    }
}
