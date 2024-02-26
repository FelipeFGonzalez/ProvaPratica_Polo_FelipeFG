using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPratica_Polo_FelipeFG.Model
{
    public class RootIndicador
    {
        public string odatacontext { get; set; }
        public List<ValueIndicador> value { get; set; }
    }
}
