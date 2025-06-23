namespace source.Entidades
{
    public class SerieTemporal
    {
        private int numeroSerie;
        private bool condicionAlarma;
        private DateTime fechaHoraInicioRegistroMuestras;
        private DateTime fechaHoraRegistro;
        private float frecuenciaMuestreo;
        private List<MuestraSismica> muestraSismica;

        public SerieTemporal(bool condicionAlarma, DateTime fechaHoraRegistroMuestras, DateTime fechaHoraRegistro, float frecuenciaMuestreo, List<MuestraSismica> muestraSismica)
        {
            this.condicionAlarma = condicionAlarma;
            this.fechaHoraInicioRegistroMuestras = fechaHoraRegistroMuestras;
            this.fechaHoraRegistro = fechaHoraRegistro;
            this.frecuenciaMuestreo = frecuenciaMuestreo;
            this.muestraSismica = muestraSismica;
        }

        public List<MuestraSismica> getMuestrasSismicas()
        {
            return muestraSismica;
        }

        public DateTime getFecha()
        {
            return fechaHoraInicioRegistroMuestras;
        }


        public (string codigo, string nombre) getEstacionSismografica(List<Sismografo> listaSismografo)
        {
            foreach (Sismografo sismografo in listaSismografo)
            {
                // 47. sosMiSismografo()
                if (sismografo.sosMiSismografo(this))
                {
                    // 48. getDatosEstacion()
                    return sismografo.getDatosEstacion();
                }
            }
            return (null, null);

        }
    }
}
