using Caliburn.Micro;
using ProvaPratica_Polo_FelipeFG.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPratica_Polo_FelipeFG.ViewModel.Commands
{
    public class PesquisarCommand : CommandB
    {
        private readonly MainViewVM _mainViewVM;
        private readonly AcessoAPI _acessoAPI;

        public PesquisarCommand(MainViewVM mainViewVM, AcessoAPI acessoAPI)
        {
            _mainViewVM = mainViewVM;
            _acessoAPI = acessoAPI;
        }
        public override async void Execute(object? parameter)
        {

            if (_mainViewVM.Indicador == null || _mainViewVM.DataFim < _mainViewVM.DataIni)
            {
                return;
            }
            else if (_mainViewVM.Indicador == "Selic")
            {
                RootIndicador resp = await _acessoAPI.getSelic(_mainViewVM.DataIni, _mainViewVM.DataFim);
                _mainViewVM.Indicadores = new ObservableCollection<ValueIndicador>(resp.value);
            }
            else
            {
                RootIndicador resp = await _acessoAPI.getIndicadores(_mainViewVM.Indicador, _mainViewVM.DataIni, _mainViewVM.DataFim);
                _mainViewVM.Indicadores = new ObservableCollection<ValueIndicador>(resp.value);
            }

        }
    }
}
