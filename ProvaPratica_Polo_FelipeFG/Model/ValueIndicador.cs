using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPratica_Polo_FelipeFG.Model
{
    public class ValueIndicador
    {
        public string Indicador { get; set; }
        public string Data { get; set; }
        public string DataReferencia { get; set; }
        public string Reuniao { get; set; }

        public double Media { get; set; }
        public double Mediana { get; set; }
        public double DesvioPadrao { get; set; }
        public double Minimo { get; set; }
        public double Maximo { get; set; }
        public Nullable<int> numeroRespondentes { get; set; }
        public int baseCalculo { get; set; }
    }
}
