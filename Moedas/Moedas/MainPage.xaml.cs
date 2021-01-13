using Moedas.Services.Coins;
using Moedas.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Moedas
{
    public partial class MainPage : ContentPage
    {
        public ICoinsService iCoinsService;
        public MainPage()
        {
            InitializeComponent();            
        }

        private void PckSelectedIndexChanged(object sender, EventArgs e)
        {           
            DisplayAlert("", "Foi o item Selecionado", "OK");
        }
    }
}
