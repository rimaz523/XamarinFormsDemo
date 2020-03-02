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
    public partial class Engagements : ContentPage
    {
        public Engagements()
        {
            Title = "Engagements";
            InitializeComponent();
        }
    }
}