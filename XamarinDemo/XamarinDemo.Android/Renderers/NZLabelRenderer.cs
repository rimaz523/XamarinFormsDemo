using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinDemo.Droid.Renderers;

[assembly: ExportRenderer(typeof(Label), typeof(NZLabelRenderer))]
namespace XamarinDemo.Droid.Renderers
{
    public class NZLabelRenderer : LabelRenderer
    {
        public NZLabelRenderer(Context context) : base(context)
        { 
        
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
                SetFonts();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Label.FontFamilyProperty.PropertyName)
                SetFonts();
        }

        public void SetFonts()
        {
            var label = this.Element as Label;
            if (label != null)
            {
                var path = "";
                if (label.FontFamily.Contains("Black"))
                    path = "Fonts/Lobster-Regular.ttf";

                if (!String.IsNullOrEmpty(path))
                {
                    Typeface typeface = Typeface.CreateFromAsset(this.Context.Assets, path);
                    this.Control.Typeface = typeface;
                }
            }
        }
    }
}