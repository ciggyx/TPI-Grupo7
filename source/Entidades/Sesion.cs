using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace source.Entidades
{
    internal class Sesion
    {
        private string fechaHoraInicio;
        private string fechaHoraFin;
        private Usuario usuarioLogueado;

        public Empleado getUsuarioLogueado()
        {
            return usuarioLogueado.getEmpleado();
        }
    }

    
}
