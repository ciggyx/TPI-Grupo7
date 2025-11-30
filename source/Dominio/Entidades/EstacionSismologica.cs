using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace source.Domain.Entities
{
    [Table("estaciones_sismologicas")]
    public class EstacionSismologica
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Codigo { get; set; } = "";

        [MaxLength(200)]
        public string? Nombre { get; set; }

        public EstacionSismologica(string nombre, string codigo)
        {
            this.Nombre = nombre;
            this.Codigo = codigo;
        }

        public string getNombre()
        {
            return Nombre;
        }

        public string getCodigo()
        {
            return Codigo;
        }
    }
}
