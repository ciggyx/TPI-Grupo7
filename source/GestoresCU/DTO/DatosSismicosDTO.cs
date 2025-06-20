using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.GestoresCU.DTO
{
    public class DatosSismicosDTO
    {
        public string Alcance { get; set; }
        public string Clasificacion { get; set; }
        public string Origen { get; set; }
        public double MagnitudValor { get; set; }
        public List<DetalleDTO> Detalles { get; set; }

        public class DetalleDTO
        {
            public double Valor { get; set; }
            public string TipoMuestraDenominacion { get; set; }
            public string TipoMuestraUnidad { get; set; }
            public double TipoMuestraValorUmbral { get; set; }
        }
    }
}
