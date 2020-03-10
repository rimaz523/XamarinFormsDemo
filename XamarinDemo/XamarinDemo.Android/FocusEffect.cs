using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.Android;
using XamarinDemo.Droid;
using Android.Graphics;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.ComponentModel;
using Xamarin.Forms;

[assembly: ResolutionGroupName("ZeaEffect")]
[assembly: ExportEffect(typeof(FocusEffect), nameof(FocusEffect))]
namespace XamarinDemo.Droid
{
    public class FocusEffect : PlatformEffect
    {
        Android.Graphics.Color backgroundColor;

        protected override void OnAttached()
        {
            backgroundColor = Android.Graphics.Color.White;
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if ((Control.Background as Android.Graphics.Drawables.ColorDrawable).Color == backgroundColor)
                    {
                        Control.SetBackgroundColor(Android.Graphics.Color.Red);
                    }
                    else
                    {
                        Control.SetBackgroundColor(Android.Graphics.Color.White);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}