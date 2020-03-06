using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinDemo.Common;
using XamarinDemo.Helpers;
using XamarinDemo.Models;

namespace XamarinDemo.ViewModels
{
    public class FeedViewModel: BaseViewModel
    {
        ObservableCollection<Feed> feeds;
        public ObservableCollection<Feed> Feeds
        {
            get { return feeds; }
            set
            {
                SetProperty(ref feeds, value);
            }
        }

        public FeedViewModel()
        {
            Feeds = new ObservableCollection<Feed>();
            UpdateFeed();

        }

        private async void UpdateFeed()
        {
            var response = await HTTPHelper.SendGetRequest(AppConstants.WebURLs.QTFeedURL, null);
            Feeds = JsonConvert.DeserializeObject<ObservableCollection<Feed>>(response);
        }
    }
}
