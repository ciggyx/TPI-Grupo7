namespace source.Entidades
{
    internal class SerieTemporal
    {
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

        public void getDatos() { }
    }
}
