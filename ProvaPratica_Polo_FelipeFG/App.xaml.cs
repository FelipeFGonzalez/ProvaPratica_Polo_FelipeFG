using ProvaPratica_Polo_FelipeFG.Model;
using ProvaPratica_Polo_FelipeFG.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ProvaPratica_Polo_FelipeFG
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly AcessoAPI acessoAPI;

        public App()
        {
            acessoAPI = new AcessoAPI();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowVM(acessoAPI)
            };
            MainWindow.Show();


            base.OnStartup(e);
        }
    }

}
