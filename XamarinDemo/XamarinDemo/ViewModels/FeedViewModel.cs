using System;
using System.Collections.Generic;
using System.Text;
using XamarinDemo.Models;

namespace XamarinDemo.ViewModels
{
    public class FeedViewModel
    {
        public List<Feed> Feeds { get; set; }

        public FeedViewModel()
        {
            Feeds = new List<Feed>()
            {
                new Feed()
                {
                    Heading = "New Testing Show Podcast - Identifying Testing Talent and Being the Testing Talent",
                    Description = "Is you organization truly Agile, or is it stuck in the state of Scrummerfall-- going through bla bla bla",
                    ImageUrl = "image_1.jpg"
                },
                new Feed()
                {
                    Heading = "Converting to SAP S/4HANA? Dont Neglect These 8 Crucial Questions",
                    Description = "When facing what must be one of the biggest transformational endeavors your organization will bla bla bla",
                    ImageUrl = "image_2.jpg"
                }
            };

        }
    }
}
