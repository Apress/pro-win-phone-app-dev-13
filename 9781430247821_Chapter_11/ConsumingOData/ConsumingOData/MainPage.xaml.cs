using System;
using System.Data.Services.Client;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using ConsumingOData.StackOverflowReference;
using Microsoft.Phone.Controls;

namespace ConsumingOData
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var uri = new Uri("http://data.stackexchange.com/stackoverflow/atom",
                UriKind.Absolute);
            var entities = new Entities(uri);
            entities.Users.BeginExecute((asyncResult) =>
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    var query = asyncResult.AsyncState as DataServiceQuery<User>;
                    this.DataContext = query.EndExecute(asyncResult)
                        .ToList();

                });
            }, entities.Users);
        }
    }
}