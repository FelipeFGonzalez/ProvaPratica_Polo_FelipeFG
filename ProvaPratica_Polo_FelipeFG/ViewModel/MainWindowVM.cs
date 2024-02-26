using ProvaPratica_Polo_FelipeFG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPratica_Polo_FelipeFG.ViewModel
{
    public class MainWindowVM : VMBase
    {
        public VMBase Current { get; }
        public MainWindowVM(AcessoAPI acessoAPI)
        {
            Current = new MainViewVM(acessoAPI);
        }

    }
}
