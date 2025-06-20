namespace source.Entidades
{
    public enum Ambito //Clase simple de C# que permite manejar estados segun numero.
    {
        EventoSismico, // 0
        Sismografo     // 1   
    }

    public enum Nombre
    {
        pendienteRevision, // 0
        autoDetectado,    // 1   
        bloqueadoRevision,   //2
        rechadazado //3
    }

    public class Estado
    {
        private Ambito ambito;
        private Nombre nombre;

        public Estado(Ambito ambito, Nombre nombre)
        {
            this.ambito = ambito;
            this.nombre = nombre;
        }

        public bool sosPendienteRevision()
        {
            // ¿Esto es asi? ¿No utilizamos otro enum?
            return nombre == Nombre.pendienteRevision;
        }

        public bool sosAutoDetectado()
        {
            return nombre == Nombre.autoDetectado;
        }

        public bool sosAmbitoEventoSismico()
        {
            return ambito == Ambito.EventoSismico;
        }

        public bool sosBloqueadoEnRevision()
        {
            return nombre == Nombre.bloqueadoRevision;
        }

        public bool sosRechazado()
        {
            return nombre == Nombre.rechadazado;
        }
    }



}
