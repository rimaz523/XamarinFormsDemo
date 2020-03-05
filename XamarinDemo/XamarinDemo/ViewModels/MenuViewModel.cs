using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinDemo.Common;
using XamarinDemo.Dto;
using XamarinDemo.Models;
using XamarinDemo.Views;

namespace XamarinDemo.ViewModels
{
    public class MenuViewModel
    {
        public List<QTMenuItem> Pages { get; set; }
        public string UserFullName { get; set; }

        public MenuViewModel()
        {
            Pages = new List<QTMenuItem>()
            {
                new QTMenuItem() { Name = "QT Feed", PageType = typeof(QualitestFeedPage)},
                new QTMenuItem() { Name = "Engagements", PageType = typeof(Engagements)},
                new QTMenuItem() { Name = "Feedback", PageType = typeof(Feedback)},
                new QTMenuItem() { Name = "Logout"},
            };
            var client = JsonConvert.DeserializeObject<Client>(Preferences.Get(AppConstants.Constants.Client, "{}"));
            UserFullName = client.User.FirstName + " " + client.User.LastName;
        }
    }
}
