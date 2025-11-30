using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace source.Domain.Entities
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string NombreUsuario { get; set; } = "";

        [Required, MaxLength(250)]
        public string Contrasena { get; set; } = "";

        // FK hacia Empleado si corresponde
        [ForeignKey(nameof(Empleado))]
        public int EmpleadoId { get; set; }
        public Empleado EmpleadoLogueado { get; set; }

        public Usuario() { } // EntityFramework necesita esto para no romperse

        public Usuario(string nombreUsuario, string contrasena, Empleado empleadoLogueado)
        {
            this.NombreUsuario = nombreUsuario;
            this.Contrasena = contrasena;
            this.EmpleadoLogueado = empleadoLogueado;
        }

        public Empleado getEmpleado()
        {
            return EmpleadoLogueado;
        }
    }
}
