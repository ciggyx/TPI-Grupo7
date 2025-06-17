using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Entidades
{
    public enum Ambito //Clase simple de C# que permite manejar estados segun numero.
    {
        EventoSismico, // 0
        Sismografo     // 1   
    }


    internal class Estado
    {
        //Atributos
        private Ambito ambito;
        private string nombre;


        public bool sosPendienteRevision()
        {

        }

        public bool sosAutoDetectado()
        {

        }

        public bool sosAmbitoEventoSismico()
        {

        }

        public bool sosBloqueadoEnRevision()
        {

        }

        public bool sosRechazado()
        {

        }
    }

    

}
