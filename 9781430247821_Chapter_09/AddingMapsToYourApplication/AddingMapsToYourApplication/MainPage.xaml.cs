using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AddingMapsToYourApplication.Resources;
using Microsoft.Phone.Tasks;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;

namespace AddingMapsToYourApplication
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void MapClick(object sender, EventArgs e)
        {
            var task = new MapsTask();
            var goldenGateBridge = new GeoCoordinate(37.8085880, -122.4770175);
            task.Center = goldenGateBridge;
            task.ZoomLevel = 9;
            task.SearchTerm = "Golden Gate Bridge";
            task.Show();
        }

        private void CartographicModeClick(object sender, EventArgs e)
        {
            var menuItem = sender as ApplicationBarMenuItem;
            var cartographicMode = (MapCartographicMode)Enum.Parse(typeof(MapCartographicMode), menuItem.Text);
            this.WorldMap.CartographicMode = cartographicMode;
        }

        private void ColorModeClick(object sender, EventArgs e)
        {
            this.WorldMap.ColorMode = this.WorldMap.ColorMode.Equals(MapColorMode.Light) ?
                MapColorMode.Dark : MapColorMode.Light;
        }

        private void PedestrianFeaturesClick(object sender, EventArgs e)
        {
            this.WorldMap.PedestrianFeaturesEnabled = !this.WorldMap.PedestrianFeaturesEnabled;
        }

        private void LandmarksClick(object sender, EventArgs e)
        {
            this.WorldMap.LandmarksEnabled = !this.WorldMap.LandmarksEnabled;
        }
    }
}