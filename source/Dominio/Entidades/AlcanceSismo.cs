using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace source.Domain.Entities
{
    [Table("alcance_sismo")]
    public class AlcanceSismo
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Nombre { get; set; } = "";

        [MaxLength(1000)]
        public string? Descripcion { get; set; }

        public AlcanceSismo(string nombre)
        {
            this.Nombre = nombre;
        }

        public string getNombre()
        {
            return Nombre;
        }
    }
}
