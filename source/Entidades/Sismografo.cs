namespace source.Entidades
{
    public class Sismografo
    {
        private EstacionSismologica estacionSismologica;
        private List<SerieTemporal> listaSerieTemporal;
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
            (codigo: estacionSismologica.getCodigo(),
            nombre: estacionSismologica.getNombre()
            );
        }
    }
}
