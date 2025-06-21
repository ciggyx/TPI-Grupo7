namespace source.Entidades
{
    public class ClasificacionSismo
    {
        private string nombre;
        private float kmProfundidadDesde;
        private float kmProfundidadHasta;

        public ClasificacionSismo(string nombre, float kmProfundidadDesde, float kmProfundidadHasta)
        {
            this.nombre = nombre;
            this.kmProfundidadDesde = kmProfundidadDesde;
            this.kmProfundidadHasta = kmProfundidadHasta;
        }

        public string getNombre()
        {
            return nombre;
        }
    }


}
