using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinDemo.iOS.Renderers;

[assembly: ExportRenderer(typeof(Label), typeof(NZLabelRenderer))]
namespace XamarinDemo.iOS.Renderers
{
    public class NZLabelRenderer : LabelRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                SetFonts();
            }

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Label.FontFamilyProperty.PropertyName)
            {
                SetFonts();
            }
        }

        public void SetFonts()
        {
            var label = this.Element as Label;
            if (label != null)
            {
                string fontName = "";
                if (label.FontFamily.Contains("Black"))
                {
                    fontName = "Lobster Regular";
                }
                if (!String.IsNullOrEmpty(fontName))
                {
                    var font = UIKit.UIFont.FromName(fontName, (nfloat)label.FontSize);
                    if (font != null)
                        this.Control.Font = font;
                }
            }
        }
    }
}