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
    public partial class MenuView : ContentPage
    {
        public ListView MenuList { get { return MenuListView; } }

        public MenuView()
        {
            InitializeComponent();
            Title = "Menu";
            IconImageSource = "hamburger.png";
            BindingContext = new MenuViewModel();
        }
    }
}