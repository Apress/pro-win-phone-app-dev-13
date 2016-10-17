using System;
using System.Device.Location;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace StylingPushpins
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // invoking a map from a task
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

        private void PositionOnSingleCoordinate()
        {
            GeoCoordinate GoldenGateBridge =
                new GeoCoordinate(37.8085880, -122.4770175);
            this.WorldMap.SetView(GoldenGateBridge, 15);
        }

        private void PositionOnMultipleCoordinates()
        {
            // define coordinates
            GeoCoordinate GoldenGateBridge = new GeoCoordinate(37.8085880, -122.4770175);
            GeoCoordinate GoldenGatePark = new GeoCoordinate(37.7716645, -122.4545772);
            GeoCoordinate FishermansWharf = new GeoCoordinate(37.8085636, -122.4097141);

            // make an array of all coordinates
            var coordinates = new GeoCoordinate[] 
            {
                GoldenGateBridge, 
                GoldenGatePark,
                FishermansWharf
            };

            // zoom to include all coordinates in array
            var locationRectangle = LocationRectangle.CreateBoundingRectangle(coordinates);
            this.WorldMap.SetView(locationRectangle);
        }

        private void AddPushpinInCode()
        {
            // build this by starting with the innermost element and 
            // walking back to the Map Layers
            var textBlock = new TextBlock()
            {
                Text = "Golden Gate Bridge",
                Style = (Style)this.Resources["PhoneTextAccentStyle"]
            };

            var border = new Border()
            {
                Child = textBlock,
                Style = (Style)WorldMap.Resources["MapElementBorder"]
            };

            WorldMap.Layers.Add(new MapLayer() { 
                new MapOverlay() 
                    { 
                        GeoCoordinate = new GeoCoordinate(37.8085880,  -122.4770175), 
                        Content = border 
                    }
            });
        }

        private void WorldMap_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            PositionOnMultipleCoordinates();
            AddPushpinInCode();
        }
    }
}