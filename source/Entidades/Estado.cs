namespace source.Entidades
{
    public enum Ambito //Clase simple de C# que permite manejar estados segun numero.
    {
        EventoSismico, // 0
        Sismografo     // 1   
    }
    public enum Nombre
    {
        PendienteRevision, // 0
        AutoDetectado,    // 1   
        BloqueadoRevision,   //2
        Rechazado //3
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
            return nombre == Nombre.PendienteRevision;
        }

        public bool sosAutoDetectado()
        {
            return nombre == Nombre.AutoDetectado;
        }

        public bool sosAmbitoEventoSismico()
        {
            return ambito == Ambito.EventoSismico;
        }

        public bool sosBloqueadoEnRevision()
        {
            return nombre == Nombre.BloqueadoRevision;
        }

        public bool sosRechazado()
        {
            return nombre == Nombre.Rechazado;
        }

        public Nombre getNombre()
        {
            return nombre;
        }
    }



}
