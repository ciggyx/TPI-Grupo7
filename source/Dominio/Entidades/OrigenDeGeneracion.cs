using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace source.Domain.Entities
{
    [Table("origenes_generacion")]
    public class OrigenDeGeneracion
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; } = "";

        public OrigenDeGeneracion(string nombre)
        {
            this.Nombre = nombre;
        }

        public string getNombre()
        {
            return Nombre;
        }
    }
}
