using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinDemo.Models;
using XamarinDemo.Views;

namespace XamarinDemo.ViewModels
{
    public class MenuViewModel
    {
        public List<QTMenuItem> Pages { get; set; }
        public MenuViewModel()
        {
            Pages = new List<QTMenuItem>()
            {
                new QTMenuItem() { Name = "QT Feed", PageType = typeof(QualitestFeedPage)},
                new QTMenuItem() { Name = "Engagements", PageType = typeof(Engagements)},
                new QTMenuItem() { Name = "Feedback", PageType = typeof(Feedback)},
                new QTMenuItem() { Name = "Logout"},
            };
        }
    }
}
