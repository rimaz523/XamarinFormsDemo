using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDemo.ViewModels;

namespace XamarinDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactUs : ContentPage
    {
        public ContactUs()
        {
            Title = "Contact Us";
            InitializeComponent();
            BindingContext = new ContactUsViewModel();
        }
    }
}