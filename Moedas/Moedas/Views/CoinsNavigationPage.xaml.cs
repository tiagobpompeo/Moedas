using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Moedas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoinsNavigationPage : NavigationPage
    {
        public CoinsNavigationPage()
        {
            InitializeComponent();
            //BarBackgroundColor = Color.FromHex("#602040");
            //BarTextColor = Color.White;
        }

        public CoinsNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}