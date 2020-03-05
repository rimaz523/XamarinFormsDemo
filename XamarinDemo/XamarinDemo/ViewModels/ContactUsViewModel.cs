using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using XamarinDemo.Common;
using XamarinDemo.Helpers;
using XamarinDemo.Dto;
using Newtonsoft.Json;

namespace XamarinDemo.ViewModels
{
    public class ContactUsViewModel : BaseViewModel
    {
        string email = string.Empty;
        string mobile = string.Empty;
        string landline = string.Empty;
        string subject = string.Empty;
        string message = string.Empty;

        public string ContactEmail
        {
            get { return email; }
            set { SetProperty(ref email, value);
                (SubmitContactCommand as Command).ChangeCanExecute();
            }
        }
        public string Mobile
        {
            get { return mobile; }
            set { SetProperty(ref mobile, value);
                (SubmitContactCommand as Command).ChangeCanExecute();
            }
        }
        public string Landline
        {
            get { return landline; }
            set { SetProperty(ref landline, value);
                (SubmitContactCommand as Command).ChangeCanExecute();
            }
        }
        public string Subject
        {
            get { return subject; }
            set { SetProperty(ref subject, value);
                (SubmitContactCommand as Command).ChangeCanExecute();
            }
        }
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value);
                (SubmitContactCommand as Command).ChangeCanExecute();
            }
        }
        public ICommand SubmitContactCommand { get; private set; }
        public ICommand CallCommand { get; private set; }
        public ICommand MailCommand { get; private set; }
        public ICommand UrlCommand { get; private set; }

        public ContactUsViewModel()
        {
            //SubmitContactCommand = new Command(SubmitContactAsync);
            SubmitContactCommand = new Command(
                execute: () => { SubmitContactAsync(null); }
                ,
                canExecute: () =>
                {
                    return Validator.IsValidEmail(ContactEmail) &&
                    Validator.IsValidPhoneNumber(Mobile) &&
                    Validator.IsValidPhoneNumber(Landline) &&
                    !string.IsNullOrWhiteSpace(Subject) &&
                    !string.IsNullOrWhiteSpace(Message);
                }
                );
            CallCommand = new Command(OpenDialler);
            MailCommand = new Command(Mail);
            UrlCommand = new Command(OpenUrl);
        }

        public async void SubmitContactAsync(object sender)
        {
            if (!Network.IsNetworkAvailable())
            {
                await App.Current.MainPage.DisplayAlert(AppConstants.Messages.NetworkErrorTitle, AppConstants.Messages.NetworkError, AppConstants.Messages.OK);
            }

            var response = await HTTPHelper.SendPostRequest(AppConstants.WebURLs.ContactURL, new
            {
                mobileNumber = Mobile,
                subject = Subject,
                message = Message,
                email = ContactEmail
            }, false);
            
            var apiResponse = JsonConvert.DeserializeObject<BaseResponse>(response);
            if (apiResponse.Message == AppConstants.Messages.Success)
            {
                await App.Current.MainPage.DisplayAlert(AppConstants.Messages.GenericInfo, AppConstants.Messages.ResponseSent, AppConstants.Messages.OK);
                return;
            }
            await App.Current.MainPage.DisplayAlert(AppConstants.Messages.GenericError, AppConstants.Messages.ResponseFailed, AppConstants.Messages.OK);

        }

        public async void OpenDialler(object sender)
        {
            try
            {
                PhoneDialer.Open(sender.ToString());
            }
            catch (ArgumentNullException ex)
            {
                await App.Current.MainPage.DisplayAlert(AppConstants.Messages.GenericError, ex.Message, AppConstants.Messages.OK);
            }
            catch (FeatureNotSupportedException ex)
            {
                await App.Current.MainPage.DisplayAlert(AppConstants.Messages.GenericError, ex.Message, AppConstants.Messages.OK);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(AppConstants.Messages.GenericError, ex.Message, AppConstants.Messages.OK);
            }
        }

        public async void Mail(object sender)
        {
            await SendEmail(sender.ToString());
        }

        public async Task SendEmail(string emailAddress)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = "Test Subject",
                    To = new List<string>() { emailAddress },
                    Body = "Test Body"
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                await App.Current.MainPage.DisplayAlert(AppConstants.Messages.GenericError, ex.Message, AppConstants.Messages.OK);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(AppConstants.Messages.GenericError, ex.Message, AppConstants.Messages.OK);
            }
        }

        public async void OpenUrl(object sender)
        {
            await OpenBrowserLink(sender.ToString());
        }

        public async Task OpenBrowserLink(string url)
        {
            try
            {
                await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(AppConstants.Messages.GenericError, ex.Message, AppConstants.Messages.OK);
            }
        }
    }
}
