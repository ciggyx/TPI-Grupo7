namespace source.Entidades
{
    public class SerieTemporal
    {
        private int numeroSerie;
        private bool condicionAlarma;
        private DateTime fechaHoraInicioRegistroMuestras;
        private DateTime fechaHoraRegistro;
        // Quizás es int? Ej: 50 Hz
        private float frecuenciaMuestreo;
        private List<MuestraSismica> muestraSismica;

        // ? Como definir este constructor?
        public SerieTemporal(bool condicionAlarma, DateTime fechaHoraRegistroMuestras, DateTime fechaHoraRegistro, float frecuenciaMuestreo, List<MuestraSismica> muestraSismica)
        {
            this.condicionAlarma = condicionAlarma;
            this.fechaHoraInicioRegistroMuestras = fechaHoraInicioRegistroMuestras;
            this.fechaHoraRegistro = fechaHoraRegistro;
            this.frecuenciaMuestreo = frecuenciaMuestreo;
            this.muestraSismica = muestraSismica;
        }

        public List<MuestraSismica> getMuestrasSismicas()
        {
            //Acá podríamos pasar las estaciones, aunque no respetaría el orden del diagrama de secuencia
            return muestraSismica;
        }


        public (string codigo, string nombre) getEstacionSismografica(List<Sismografo> listaSismografo)
        {
            foreach (Sismografo sismografo in listaSismografo)
            {
                if (sismografo.sosMiSismografo(this))
                {
                    return sismografo.getDatosEstacion();
                }
            }
            return (null,null);
            
        }
    }
}
