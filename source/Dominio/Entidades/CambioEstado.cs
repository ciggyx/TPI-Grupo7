using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using source.Dominio.Entidades.PatronState;

namespace source.Domain.Entities
{
    [Table("cambios_estado")]
    public class CambioEstado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime FechaHoraInicio { get; set; }

        public DateTime? FechaHoraFin { get; set; }

        [MaxLength(1000)]
        public string? Comentario { get; set; }

        // FK a EventoSismico
        [ForeignKey(nameof(EventoSismico))]
        public int EventoSismicoId { get; set; }
        public EventoSismico EventoSismico { get; set; } = null!;

        // FK a Estado
        [ForeignKey(nameof(Estado))]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        // FK a Empleado
        [ForeignKey(nameof(Empleado))]
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }

        private CambioEstado() { } // EntityFramework necesita esto para no romperse

        public CambioEstado(DateTime fechaHoraInicio, Estado estado, Empleado empleado)
        {
            this.FechaHoraInicio = fechaHoraInicio;
            this.Estado = estado;
            this.Empleado = empleado;
        }

        public bool esEstadoActual()
        {
            return FechaHoraFin == null;
        }

        public void setFechaHoraFin(DateTime fechaHoraActual)
        {
            FechaHoraFin = fechaHoraActual;
        }
    }
}
