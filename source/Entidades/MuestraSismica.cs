namespace source.Entidades
{
    internal class MuestraSismica
    {
        private DateTime fechaHoraMuestra;
        private List<DetalleMuestraSismica> detalleMuestraSismica;

        public MuestraSismica(DateTime fechaHoraMuestra, List<DetalleMuestraSismica> detalleMuestraSismicas)
        {
            this.fechaHoraMuestra = fechaHoraMuestra;
            this.detalleMuestraSismica = detalleMuestraSismicas;
        }

        public List<DetalleMuestraSismica> getDetalleMuestraSismica()
        {
            return detalleMuestraSismica;
        }

    }


}
