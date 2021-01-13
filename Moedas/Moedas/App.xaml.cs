using Moedas.Bootstrap;
using Moedas.Services.Navigation;
using Moedas.Sqlite;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Moedas
{
    public partial class App : Application
    {
        #region Properties
        public static CoinRepository CoinRepository { get; private set; }
        #endregion

        public App(string pathDataBase)
        {
            InitializeComponent();
            CoinRepository = new CoinRepository(pathDataBase);//procurar fazer pelo container
            InitializeApp();
            InitializeNavigation();           
        }

        private void InitializeApp()
        {
            AppContainer.RegisterDependencies();// Registro VM, Interfaces e Servicos
        }

        private async Task InitializeNavigation()
        {
            //Resolve : casos em que eh necessario instancia, e nao ha injecao de dependencia no construtor(casos VM)
            var navigationService = AppContainer.Resolve<INavigationService>();
            await navigationService.InitializeAsync();// Inicia a pagina Inicial
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
