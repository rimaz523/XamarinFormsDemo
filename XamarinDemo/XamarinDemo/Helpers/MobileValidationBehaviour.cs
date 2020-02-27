using Xamarin.Forms;

namespace XamarinDemo.Helpers
{
    class MobileValidationBehaviour: Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            (sender as Entry).TextColor = e.NewTextValue.ToString().Length < 10 ? Color.Red : Color.Black;
        }
    }
}
