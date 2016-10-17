using System;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Toolkit;
using Microsoft.Phone.Shell;

namespace StylingPushpins
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
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