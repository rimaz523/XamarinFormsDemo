using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace XamarinDemo.Helpers
{
    class EmailValidationBehaviour : Behavior<Entry>
    {
        Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

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
            (sender as Entry).TextColor = IsValidEmail(e.NewTextValue.ToString()) ? Color.Black : Color.Red;
        }

        private bool IsValidEmail(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
                return false;
            return EmailRegex.IsMatch(emailAddress);
        }
    }
}
