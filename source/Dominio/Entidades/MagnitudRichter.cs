using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace source.Domain.Entities
{
    [Table("magnitudes_richter")]
    public class MagnitudRichter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Numero { get; set; }

        [MaxLength(500)]
        public string? Descripcion { get; set; }

        // Eventos que referencian esta magnitud
        public List<EventoSismico> Eventos { get; set; } = new();

        public MagnitudRichter() { }

        public MagnitudRichter(double numero, string descripcion)
        {
            Numero = numero;
            Descripcion = descripcion;
        }

        public double getNombre()
        {
            return Numero;
        }
    }
}
