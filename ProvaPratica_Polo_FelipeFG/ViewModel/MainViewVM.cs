using Caliburn.Micro;
using ProvaPratica_Polo_FelipeFG.Model;
using ProvaPratica_Polo_FelipeFG.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProvaPratica_Polo_FelipeFG.ViewModel
{
    public class MainViewVM : VMBase
    {
        public ObservableCollection<ValueIndicador> _indicadores { get; set; }
        private string _indicador;
        private DateTime _dataIni = new DateTime(2000, 1, 1);
        private DateTime _dataFim = new DateTime(2000, 1, 1);

        public ObservableCollection<ValueIndicador> Indicadores
        {
            get { return _indicadores; }
            set
            {
                _indicadores = value;
                OnPropertyChanged(nameof(Indicadores));
            }
        }

        public string Indicador
        {
            get { return _indicador;}
            set 
            { 
                _indicador = value;
                OnPropertyChanged(nameof(Indicador));
            }
        }

        public DateTime DataIni
        {
            get { return _dataIni; }
            set
            {
                _dataIni = value;
                OnPropertyChanged(nameof(DataIni));
            }
        }

        public DateTime DataFim
        {
            get { return _dataFim; }
            set
            {
                _dataFim = value;
                OnPropertyChanged(nameof(DataFim));
            }
        }


        public ICommand PesquisarC { get; }

        public MainViewVM(AcessoAPI acessoAPI)
        {
            PesquisarC = new PesquisarCommand(this, acessoAPI);
            
        }

    }
}
