using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDemo.ViewModels;

namespace XamarinDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QualitestFeedPage : ContentPage
    {
        public QualitestFeedPage()
        {
            Title = "Feed";
            InitializeComponent();
            BindingContext = new FeedViewModel();
        }
    }
}