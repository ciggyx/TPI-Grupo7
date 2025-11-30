using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace source.Domain.Entities
{
    [Table("empleados")]
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Nombre { get; set; } = "";

        [Required, MaxLength(150)]
        public string Apellido { get; set; } = "";

        [MaxLength(200)]
        public string Mail { get; set; }

        [MaxLength(50)]
        public string Telefono { get; set; }

        public Empleado(string nombre, string apellido, string mail, string telefono)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Mail = mail;
            this.Telefono = telefono;
        }
    }
}
