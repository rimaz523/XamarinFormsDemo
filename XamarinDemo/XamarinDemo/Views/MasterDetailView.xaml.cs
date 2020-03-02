using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDemo.Models;

namespace XamarinDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailView : MasterDetailPage
    {
        MenuView master;

        public MasterDetailView()
        {
            InitializeComponent();
            master = new MenuView();
            Master = master;
            Detail = new NavigationPage(new QualitestFeedPage());
            master.MenuList.ItemTapped += MenuList_ItemTapped;
        }

        private async void MenuList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as QTMenuItem;
            if (item.PageType == null)
            {
                if (await DisplayAlert("Caution", "Are you sure you want to logout", "YES", "Cancel"))
                    App.Current.MainPage = new NavigationPage(new Home());
                return;
            }
            var page = (Page)Activator.CreateInstance(item.PageType);
            Detail = new NavigationPage(page);
            IsPresented = false;
        }
    }
}