using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using XamarinDemo.Common;

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
            set { SetProperty(ref email, value); }
        }
        public string Mobile
        {
            get { return mobile; }
            set { SetProperty(ref mobile, value); }
        }
        public string Landline
        {
            get { return landline; }
            set { SetProperty(ref landline, value); }
        }
        public string Subject
        {
            get { return subject; }
            set { SetProperty(ref subject, value); }
        }
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }
        public ICommand SubmitContactCommand { get; private set; }
        public ICommand CallCommand { get; private set; }
        public ICommand MailCommand { get; private set; }
        public ICommand UrlCommand { get; private set; }

        public ContactUsViewModel()
        {
            SubmitContactCommand = new Command(SubmitContact);
            CallCommand = new Command(OpenDialler);
            MailCommand = new Command(Mail);
            UrlCommand = new Command(OpenUrl);
        }

        public void SubmitContact(object sender)
        {
            //TODO : Send contact information via api call
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
