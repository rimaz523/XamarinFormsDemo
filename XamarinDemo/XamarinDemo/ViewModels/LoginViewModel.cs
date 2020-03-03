using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinDemo.Common;
using XamarinDemo.Helpers;
using XamarinDemo.Models;

namespace XamarinDemo.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        string email = string.Empty;
        string password = string.Empty;

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        public ICommand LoginCommand { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
        }

        public async void Login(object sender)
        {
            if (!Validator.IsValidEmail(Email))
            {
                await App.Current.MainPage.DisplayAlert(AppConstants.Messages.ErrorTitle, AppConstants.Messages.EmailError, AppConstants.Messages.OK);
                return;
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                await App.Current.MainPage.DisplayAlert(AppConstants.Messages.ErrorTitle, AppConstants.Messages.PasswordError, AppConstants.Messages.OK);
                return;
            }
            if (!Network.IsNetworkAvailable())
            {
                await App.Current.MainPage.DisplayAlert(AppConstants.Messages.NetworkErrorTitle, AppConstants.Messages.NetworkError, AppConstants.Messages.OK);
                return;
            }
            var credentials = new Credentials 
            {
                email = Email,
                password = Password
            };
            var request = await HTTPHelper.SendPostRequest(AppConstants.WebURLs.LoginURL, credentials, false);
            await App.Current.MainPage.DisplayAlert(AppConstants.Messages.NetworkErrorTitle, request.ToString(), AppConstants.Messages.OK);
        }
    }
}
