namespace source.Entidades
{
    public class Sismografo
    {
        private EstacionSismologica estacionSismologica;
        private List<SerieTemporal> listaSerieTemporal = new List<SerieTemporal>();
        public Sismografo(EstacionSismologica estacionSismologica)
        {
            this.estacionSismologica = estacionSismologica;

        }

        public bool sosMiSismografo(SerieTemporal serie)
        {
            foreach (SerieTemporal s in listaSerieTemporal)
            {
                if (listaSerieTemporal.Contains(serie))
                {
                    return true;
                }

            }
            return false;
        }


        public (string codigo, string nombre) getDatosEstacion()
        {
            return
            (
            // 49. getCodigo()
            codigo: estacionSismologica.getCodigo(),
            // 50. getNombre()
            nombre: estacionSismologica.getNombre()
            );
        }

        public void agregarSerieTemporal(SerieTemporal serie)
        {
            listaSerieTemporal.Add(serie);
        }



    }
}
