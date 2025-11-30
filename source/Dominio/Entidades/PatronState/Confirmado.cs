using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Dominio.Entidades.PatronState
{
    public class Confirmado : Estado
    {
        private Confirmado()
            : base() { }

        public static Confirmado ConfirmarDirecto()
        {
            return new Confirmado { Ambito = "EventoSismico", Nombre = "Confirmado" };
        }
    }
}
