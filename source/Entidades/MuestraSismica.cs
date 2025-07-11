﻿namespace source.Entidades
{
    public class MuestraSismica
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

        public DateTime getFecha()
        {
            return fechaHoraMuestra;
        }

    }


}
