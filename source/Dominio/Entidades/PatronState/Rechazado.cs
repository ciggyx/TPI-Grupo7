using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Dominio.Entidades.PatronState
{
    public class Rechazado : Estado
    {
        public Rechazado()
            : base() { }

        public static Rechazado Rechazar()
        {
            return new Rechazado { Ambito = "EventoSismico", Nombre = "Rechazado" };
        }
    }
}
