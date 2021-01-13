using Moedas.Models;
using Moedas.Services.Coins;
using Moedas.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Moedas.ViewModels
{
    public class CoinsViewModel:BaseViewModel
    {

        #region Atributtes
        public INavigation _navigationService;
        public ICoinsService _iCoinsService;
        //private List<CoinsModel.Value> _coins;
        ObservableCollection<CoinsModel.Value> _coins;
        public ObservableCollection<CoinsModel.Value> Coins
        {
            get { return _coins; }
            set { _coins = value; OnPropertyChanged(); }
        }
        #endregion

        #region Properties   
        //public List<CoinsModel.Value> Coins
        //{
        //    get { return _coins; }
        //    set { _coins = value; OnPropertyChanged(); }
        //}
        #endregion

        #region commands
        CoinsModel.Value selectedCoins;
        public CoinsModel.Value SelectedCoin
        {
            get { return selectedCoins; }
            set
            {
                if (SelectedCoin != value)
                {
                    selectedCoins = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public CoinsViewModel(INavigationService navigationService, ICoinsService iCoinsService)
                  : base(navigationService)
        {
            _iCoinsService = iCoinsService;
            Coins = new  ObservableCollection<CoinsModel.Value>();
            LoadAsync();
        }

        public async Task LoadAsync()
        {
           

            var result = await  _iCoinsService.GetAllCoinsAsync();

            foreach (var x in result) 
            {
                Coins.Add(new CoinsModel.Value 
                { 
                    nomeFormatado = x.nomeFormatado,
                    tipoMoeda = x.tipoMoeda,
                    simbolo = x.simbolo
                });
            
            }

            //CRUD

            await App.CoinRepository.AddNewProductAsync(null);//Create
            await App.CoinRepository.GetAllProductAsync();//Read
            await App.CoinRepository.RemoveProductAsync(1);//Delete 
            await App.CoinRepository.DeleteAllListaAsync();//Delete
            await App.CoinRepository.UpdateItemAsync(null);//update
           
          
        }
    }

    
}
