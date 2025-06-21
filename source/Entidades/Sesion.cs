namespace source.Entidades
{
    public class Sesion
    {
        private DateTime fechaHoraInicio;
        private DateTime fechaHoraFin;
        private Usuario usuarioLogueado;

        public Sesion(DateTime fechaHoraInicio, DateTime fechaHoraFin, Usuario usuarioLogueado)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.usuarioLogueado = usuarioLogueado;
        }

        public Empleado getUsuarioLogueado() //24.
        {
            return usuarioLogueado.getEmpleado(); //25.
        }
    }


}
