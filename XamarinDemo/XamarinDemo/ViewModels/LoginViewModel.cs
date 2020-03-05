using System.Windows.Input;
using Xamarin.Forms;
using XamarinDemo.Common;
using XamarinDemo.Helpers;
using XamarinDemo.Views;
using Newtonsoft.Json;
using XamarinDemo.Dto;
using Xamarin.Essentials;
using System;

namespace XamarinDemo.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        string email = string.Empty;
        string password = string.Empty;
        bool showPassword = true;

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value);
                (LoginCommand as Command).ChangeCanExecute(); 
            }
        }
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value);
                (LoginCommand as Command).ChangeCanExecute();
            }
        }

        public bool ShowPassword
        {
            get { return showPassword; }
            set
            {
                SetProperty(ref showPassword, value);
                (TogglePasswordCommand as Command).ChangeCanExecute();
            }
        }
        public ICommand LoginCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand TogglePasswordCommand { get; private set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(
                execute: () => { Login(null); }
                ,
                canExecute: () =>
                {
                    return Validator.IsValidEmail(Email) && !string.IsNullOrWhiteSpace(Password);
                }
                );
            ResetCommand = new Command(() => { Email = ""; Password = ""; });
            CancelCommand = new Command(() => {
                App.Current.MainPage = new NavigationPage(new Home());
            });
            TogglePasswordCommand = new Command(() => ShowPassword = !ShowPassword);
        }

        public async void Login(object sender)
        {
            //if (!Validator.IsValidEmail(Email))
            //{
            //    await App.Current.MainPage.DisplayAlert(AppConstants.Messages.ErrorTitle, AppConstants.Messages.EmailError, AppConstants.Messages.OK);
            //    return;
            //}
            //if (string.IsNullOrWhiteSpace(Password))
            //{
            //    await App.Current.MainPage.DisplayAlert(AppConstants.Messages.ErrorTitle, AppConstants.Messages.PasswordError, AppConstants.Messages.OK);
            //    return;
            //}
            if (!Network.IsNetworkAvailable())
            {
                await App.Current.MainPage.DisplayAlert(AppConstants.Messages.NetworkErrorTitle, AppConstants.Messages.NetworkError, AppConstants.Messages.OK);
                return;
            }
            try
            {
                var response = await HTTPHelper.SendPostRequest(AppConstants.WebURLs.LoginURL, new { email = Email, password = Password }, false);
                var client = JsonConvert.DeserializeObject<Client>(response);
                Session.Set(AppConstants.Constants.Token, client.Jwt);
                Session.Set(AppConstants.Constants.UserId, client.User.UserId);
                Session.Set(AppConstants.Constants.RoleId, client.Role.RoleId);
                //Inbuilt class to managing app session data (similar to our session class)
                Preferences.Set(AppConstants.Constants.Client, JsonConvert.SerializeObject(client));

                App.Current.MainPage = new MasterDetailView();

                //Other Preferences operations
                //Preferences.Get(AppConstants.Constants.Token, userDto.jwt);
                //Preferences.Remove(AppConstants.Constants.Token);
                //Preferences.Clear();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(AppConstants.Messages.GenericError, ex.Message, AppConstants.Messages.OK);
            }
        }
    }
}
