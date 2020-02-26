using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private async void LoginOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Login());
        }

        private async void ContactUsOnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ContactUs());
        }
    }
}