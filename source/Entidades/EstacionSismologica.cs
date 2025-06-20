namespace source.Entidades
{
    internal class EstacionSismologica
    {
        private string nombre;
        private string codigo;

        public EstacionSismologica(string nombre, string codigo)
        {
            this.nombre = nombre;
            this.codigo = codigo;
        }

        public string getNombre()
        {
            return nombre;
        }

        public string getCodigo()
        {
            return codigo;
        }
    }
}
