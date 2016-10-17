using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using ConsumingXML.Classes;

namespace ConsumingXML.User_Controls
{
    public partial class XMLContent : UserControl
    {
        public XMLContent()
        {
            InitializeComponent();
            LoadFromXmlFile();
        }

        private void LoadFromXmlFile()
        {
            // Use this syntax for Build-Action = Resource
            var resourceStream =
                Application.GetResourceStream(
                    new Uri("/ConsumingXML;component/Data/Tweets.xml", UriKind.Relative));
            var document = XDocument.Load(resourceStream.Stream);

            // Use this syntax for Build-Action = Content
            //var document = XDocument.Load("Data/Tweets.xml");

            XNamespace ns = @"http://www.falafel.com/";

            var tweetElements = document.Element("Tweets").Elements("Tweet");

            var tweets = tweetElements
                .Select(t => new Tweet()
                {
                    Author = t.Element("Author").Value,
                    Content = t.Element("Content").Value,
                    Notes = t.Element(ns + "Notes").Value
                });
            TweetListBox.DataContext = tweets;
        }
    }
}
