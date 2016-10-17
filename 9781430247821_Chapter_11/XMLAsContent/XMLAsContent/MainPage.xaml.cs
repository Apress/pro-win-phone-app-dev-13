using System;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using Microsoft.Phone.Controls;
using XMLAsContent.Classes;

namespace XMLAsContent
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            var document = XDocument.Load("Data/Tweets.xml", LoadOptions.None);

            //var rs = Application.GetResourceStream(
            //    new Uri("/XMLAsContent;component/Data/Tweets.xml", UriKind.Relative));
            //var document = XDocument.Load(rs.Stream);

            XNamespace ns = @"http://www.falafel.com/";

            var tweetElements = document.Element(ns + "Tweets").Elements(ns + "Tweet");

            var tweets = tweetElements
                .Select(t => new Tweet()
                {
                    Author = t.Element(ns + "Author").Value,
                    Content = t.Element(ns + "Content").Value,
                    Notes = t.Element(ns + "Notes").Value
                });
            TweetListBox.DataContext = tweets;
        }
    }
}