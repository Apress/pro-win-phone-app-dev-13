using System;
using System.IO;
using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Windows.Devices.Geolocation;

namespace Yeti
{
    public partial class MainPage : PhoneApplicationPage
    {
        private IMobileServiceTable<Sighting> sightingTable = App.MobileService.GetTable<Sighting>();
        private IMobileServiceTable<Channel> channelTable = App.MobileService.GetTable<Channel>();

        public MainPage()
        {
            InitializeComponent();

            App.CurrentChannel.HttpNotificationReceived +=
                CurrentChannel_HttpNotificationReceived;
        }

        void CurrentChannel_HttpNotificationReceived(object sender,
            Microsoft.Phone.Notification.HttpNotificationEventArgs e)
        {
            var json = new StreamReader(e.Notification.Body).ReadToEnd();
            var sighting = JsonConvert.DeserializeObject<Sighting>(json);
            Dispatcher.BeginInvoke(() =>
            {
                YetiButton.Text = sighting.Latitude.ToString("0.00") + "," +
                    sighting.Longitude.ToString("0.00");
            });
        }

        private async void CritterSpottedTap(object sender,
            System.Windows.Input.GestureEventArgs e)
        {
            var channel = new Channel()
            {
                ChannelUri = App.CurrentChannel.ChannelUri.ToString()
            };
            await channelTable.InsertAsync(channel);

            var position = await new Geolocator().GetGeopositionAsync();
            var sighting = new Sighting()
                            {
                                Latitude = position.Coordinate.Latitude,
                                Longitude = position.Coordinate.Longitude,
                                LastSeen = position.Coordinate.Timestamp
                            };
            await sightingTable.InsertAsync(sighting);
        }
    }
}