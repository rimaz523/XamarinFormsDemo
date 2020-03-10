using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDemo.ViewModels;

namespace XamarinDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            Title = "Login";
            InitializeComponent();
            BindingContext = new LoginViewModel();
            Button b = new Button();
            b.BackgroundColor = Color.Red;
        }

        //private void SubmitOnClicked(object sender, EventArgs e)
        //{
        //    //await Navigation.PushAsync(new QualitestFeedPage());
        //    App.Current.MainPage = new MasterDetailView();
        //}

        private async void CancelOnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}