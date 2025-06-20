namespace source.Entidades
{
    public class DetalleMuestraSismica
    {
        private double valor;
        private TipoDeDato tipoDeDato;

        public DetalleMuestraSismica(int valor, TipoDeDato tipoDeDato)
        {
            this.valor = valor;
            this.tipoDeDato = tipoDeDato;
        }

        public double getValor() { return valor; }

        public TipoDeDato getTipoDeDato() { return tipoDeDato; }
    }
}
