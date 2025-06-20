namespace source.Entidades
{
    internal class Usuario
    {

        private string contrasena;
        private string nombreUsuario;
        private Empleado empleadoLogueado;

        public Usuario(string nombreUsuario, string contrasena, Empleado empleadoLogueado)
        {
            this.nombreUsuario = nombreUsuario;
            this.contrasena = contrasena;
            this.empleadoLogueado = empleadoLogueado;
        }

        public Empleado getEmpleado()
        {
            return empleadoLogueado;
        }

    }


}
