using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace source.Domain.Entities
{
    [Table("tipos_de_dato")]
    public class TipoDeDato
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Denominacion { get; set; } = "";

        [MaxLength(100)]
        public string NombreUnidadMedida { get; set; }

        public double ValorUmbral { get; set; }

        public TipoDeDato(string denominacion, string nombreUnidadMedida, double valorUmbral)
        {
            this.Denominacion = denominacion;
            this.NombreUnidadMedida = nombreUnidadMedida;
            this.ValorUmbral = valorUmbral;
        }

        public string getDenominacion()
        {
            return Denominacion;
        }

        public string getNombreUnidadMedida()
        {
            return NombreUnidadMedida;
        }

        public double getValorUmbral()
        {
            return ValorUmbral;
        }
    }
}
