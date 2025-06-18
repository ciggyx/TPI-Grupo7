using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Entidades
{
    public class CambioEstado
    {
        public CambioEstado(DateTime fechaHoraInicio, Estado estado, Empleado empleado)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.estado = estado;
            this.empleado = empleado;
        }
        private DateTime fechaHoraInicio;
        private DateTime? fechaHoraFin;
        private Estado estado;
        private Empleado empleado;

        public bool esEstadoActual()
        {
            return fechaHoraFin == null;
        }

        public void setFechaHoraFin(DateTime fechaHoraActual)

        {
            fechaHoraFin = fechaHoraActual;
        }
    } 
    }

    
