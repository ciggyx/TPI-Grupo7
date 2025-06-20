namespace source.Entidades
{
    internal class TipoDeDato
    {
        private string denominacion;
        private string nombreUnidadMedida;
        private double valorUmbral;

        public TipoDeDato(string denominacion, string nombreUnidadMedida, double valorUmbral)
        {
            this.denominacion = denominacion;
            this.nombreUnidadMedida = nombreUnidadMedida;
            this.valorUmbral = valorUmbral;
        }

        public string getDenomincacion()
        {
            return denominacion;
        }

        public string getNombreUnidadMedida()
        {
            return nombreUnidadMedida;
        }

        public double getValorUmbral()
        {
            return valorUmbral;
        }

    }
}
