using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;
using System.ComponentModel;
using Xamarin.Forms;
using XamarinDemo.iOS;

[assembly: ResolutionGroupName("ZeaEffect")]
[assembly: ExportEffect(typeof(FocusEffect), nameof(FocusEffect))]
namespace XamarinDemo.iOS
{
    public class FocusEffect : PlatformEffect
    {
        UIColor backgroundColor;

        public FocusEffect()
        { 
        
        }
        protected override void OnAttached()
        {
            backgroundColor = Control.BackgroundColor;
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
                    if (Control.BackgroundColor == backgroundColor)
                    {
                        Control.BackgroundColor = UIColor.Cyan;
                    }
                    else
                    {
                        Control.BackgroundColor = backgroundColor;
                    }
                }
            }
            catch (Exception ex)
            { 
                
            }
        }
    }
}