namespace source.Entidades
{
    public enum Ambito //Clase simple de C# que permite manejar estados segun numero.
    {
        EventoSismico, // 0
        Sismografo     // 1   
    }

    public class Estado
    {
        private Ambito ambito;
        private string nombre;

        public Estado(Ambito ambito, string nombre)
        {
            this.ambito = ambito;
            this.nombre = nombre;
        }

        public bool sosPendienteRevision()
        {
            // ¿Esto es asi? ¿No utilizamos otro enum?
            return nombre == "pendienteRevision";
        }

        public bool sosAutoDetectado()
        {
            return nombre == "pendienteRevision";
        }

        public bool sosAmbitoEventoSismico()
        {
            return ambito == Ambito.EventoSismico;
        }

        public bool sosBloqueadoEnRevision()
        {
            return nombre == "bloqueadoEnRevision";
        }

        public bool sosRechazado()
        {
            return nombre == "rechadazado";
        }
    }



}
