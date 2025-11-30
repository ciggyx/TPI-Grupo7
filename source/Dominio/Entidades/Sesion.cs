using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace source.Domain.Entities
{
    [Table("sesiones")]
    public class Sesion
    {
        [Key]
        public int Id { get; set; }

        public DateTime FechaHoraInicio { get; set; }
        public DateTime? FechaHoraFin { get; set; }

        // FK a Usuario
        [ForeignKey(nameof(Usuario))]
        public int? UsuarioId { get; set; }
        public Usuario? UsuarioLogueado { get; set; }

        public Sesion() { } // EntityFramework necesita esto para no romperse

        public Sesion(DateTime fechaHoraInicio, DateTime fechaHoraFin, Usuario usuarioLogueado)
        {
            this.FechaHoraInicio = fechaHoraInicio;
            this.FechaHoraFin = fechaHoraFin;
            this.UsuarioLogueado = usuarioLogueado;
        }

        public Empleado getUsuarioLogueado()
        {
            // 24. getEmpleado()
            return UsuarioLogueado.getEmpleado();
        }
    }
}
