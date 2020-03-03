using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinDemo.ViewModels
{
    public class ContactUsViewModel : BaseViewModel
    {
        string email = string.Empty;
        string mobile = string.Empty;
        string landline = string.Empty;
        string subject = string.Empty;
        string message = string.Empty;

        public string Email
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

        public ContactUsViewModel()
        {
            SubmitContactCommand = new Command(SubmitContact);
        }

        public void SubmitContact(object sender)
        {

        }
    }
}
