using Xamarin.Forms;
using XamarinDemo.Common;

namespace XamarinDemo.Helpers
{
    public class MobileValidationTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            sender.TextColor = sender.Text.Length < 10 ? Colors.QTRed : Colors.QTBlack;
        }
    }
}
