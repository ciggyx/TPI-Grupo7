using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace source.Domain.Entities
{
    [Table("detalle_muestra_sismica")]
    public class DetalleMuestraSismica
    {
        [Key]
        public int Id { get; set; }

        public double Valor { get; set; }

        // FK a TipoDeDato (qué tipo de dato es ese valor)
        [ForeignKey(nameof(TipoDeDato))]
        public int TipoDeDatoId { get; set; }
        public TipoDeDato TipoDeDato { get; set; } = null!;

        // FK a MuestraSismica
        [ForeignKey(nameof(MuestraSismica))]
        public int MuestraSismicaId { get; set; }
        public MuestraSismica MuestraSismica { get; set; } = null!;

        private DetalleMuestraSismica() { } // EntityFramework necesita esto para no romperse

        public DetalleMuestraSismica(int valor, TipoDeDato tipoDeDato)
        {
            this.Valor = valor;
            this.TipoDeDato = tipoDeDato;
        }

        public double getValor()
        {
            return Valor;
        }

        public TipoDeDato getTipoDeDato()
        {
            return TipoDeDato;
        }
    }
}
