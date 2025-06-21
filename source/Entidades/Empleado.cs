namespace source.Entidades
{
    public class Empleado
    {
        private string nombre;
        private string apellido;
        private string mail;
        private string telefono;

        public Empleado(string nombre, string apellido, string mail, string telefono)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.telefono = telefono;
        }
    }
}
