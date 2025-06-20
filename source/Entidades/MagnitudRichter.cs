namespace source.Entidades
{
    internal class MagnitudRichter
    {
        private double numero;
        private string descripcion;

        public MagnitudRichter(double numero, string descripcion)
        {
            this.numero = numero;
            this.descripcion = descripcion;
        }

        public double getNombre()
        {
            return numero;
        }
    }


}
