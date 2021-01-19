using Moedas.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Moedas.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
       
        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                         await _navigationService.NavigateToAsync<CoinsViewModel>();
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }
        }        

        #endregion
        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
         
        }
    }
}
