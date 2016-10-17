using System;
using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.MobileServices;
using Windows.Devices.Geolocation;

namespace Yeti1
{
    public partial class MainPage : PhoneApplicationPage
    {
        private IMobileServiceTable<Sighting> sightingTable = App.MobileService.GetTable<Sighting>();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void CritterSpottedTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
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