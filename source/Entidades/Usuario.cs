using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Entidades
{
    internal class Usuario
    {

        private Empleado empleadoLogueado;
        private string contraseña;
        private string nombreUsuario;
    public Empleado getEmpleado()
        {
            return empleadoLogueado;
        }      

    }
    
    
}
