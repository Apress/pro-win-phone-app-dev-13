using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Geocoding.Resources;
using Microsoft.Phone.Maps.Services;
using Microsoft.Phone.Maps.Toolkit;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;
using System.Text;
using System.Reflection;

namespace Geocoding
{
    enum GeocodeType { Geocode, ReverseGeocode };


    public partial class MainPage : PhoneApplicationPage
    {

        private GeocodeType GeocodeType { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void InputPopup_Opened(object sender, EventArgs e)
        {
            this.InputTextBox.Text = "";
        }

        private void InputPopup_Closed(object sender, EventArgs e)
        {

        }

        private void GeocodeButton_Click_1(object sender, EventArgs e)
        {
            this.Title.Text = "Geocode";
            this.PromptText.Text = "Enter description:";
            this.GeocodeType = GeocodeType.Geocode;
            this.InputPopup.IsOpen = true;
        }

        private void ReverseGeocodeButton_Click_1(object sender, EventArgs e)
        {
            this.Title.Text = "Reverse Geocode";
            this.PromptText.Text = "Enter geocode:";
            this.GeocodeType = GeocodeType.ReverseGeocode;
            this.InputPopup.IsOpen = true;
        }

        private void OkButton_Click_1(object sender, RoutedEventArgs e)
        {
            switch (this.GeocodeType)
            {
                case GeocodeType.Geocode: Geocode(); break;
                case GeocodeType.ReverseGeocode: ReverseGeocode(); break;
            }
            this.InputPopup.IsOpen = false;
        }

        private void Geocode()
        {
            var geocodeQuery = new GeocodeQuery()
            {
                GeoCoordinate = new GeoCoordinate(),
                SearchTerm = InputTextBox.Text
            };
            geocodeQuery.QueryCompleted += queryCompleted;
            geocodeQuery.QueryAsync();
        }

        void queryCompleted(object sender, QueryCompletedEventArgs<IList<MapLocation>> e)
        {
            if ((e.Error == null) && (e.Result.Count > 0))
            {
                AddLocationPushpins(e.Result);
                SetLocationsView(e.Result);
            }
        }

        private void SetLocationsView(IList<MapLocation> locations)
        {
            var coordinates = locations.Select(l => l.GeoCoordinate);
            if (coordinates.Count() == 1)
            {
                Worldmap.SetView(coordinates.Single(), 13);
            }
            else
            {
                var locationRectangle = LocationRectangle.CreateBoundingRectangle(coordinates);
                Worldmap.SetView(locationRectangle);
            }
        }

        private void AddLocationPushpins(IList<MapLocation> locations)
        {
            var mapItemsControl = MapExtensions.GetChildren(this.Worldmap)
                .Where(c => c is MapItemsControl).Single() as MapItemsControl;
            foreach (var location in locations)
            {
                var pushpin = new Pushpin()
                {
                    GeoCoordinate = location.GeoCoordinate,
                    Content = GetAddressCaption(location.Information.Address)
                };

                mapItemsControl.Items.Add(pushpin);
            }
        }

        private void ReverseGeocode()
        {
            var numbersArray = this.InputTextBox.Text.Split(',');
            if (numbersArray.Count() == 2)
            {
                var latitude = Double.Parse(numbersArray[0]);
                var longitude = Double.Parse(numbersArray[1]);
                var coordinate = new GeoCoordinate(latitude, longitude);
                var reverseGeocodeQuery = new ReverseGeocodeQuery()
                {
                    GeoCoordinate = coordinate
                };
                reverseGeocodeQuery.QueryCompleted += queryCompleted;
                reverseGeocodeQuery.QueryAsync();
            }
        }

        private string GetAddressCaption(MapAddress address)
        {
            var result = new StringBuilder();

            foreach (PropertyInfo propertyInfo in typeof(MapAddress).GetProperties())
            {
                var value = (string)propertyInfo.GetValue(address, null);
                if (value != "")
                {
                    result.AppendLine(propertyInfo.Name + ": " + value);
                }
            }
            return result.ToString();
        }

        private void Worldmap_Hold_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GeoCoordinate coordinate =
                Worldmap.ConvertViewportPointToGeoCoordinate(e.GetPosition(Worldmap));
            var reverseGeocodeQuery = new ReverseGeocodeQuery()
            {
                GeoCoordinate = coordinate
            };
            reverseGeocodeQuery.QueryCompleted += queryCompleted;
            reverseGeocodeQuery.QueryAsync();
        }
    }
}