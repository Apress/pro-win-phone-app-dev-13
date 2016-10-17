using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Toolkit;
using Windows.Devices.Geolocation;

namespace GettingYourLocation
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private Geolocator _locator;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _locator = new Geolocator()
            {
                // set either ReportInterval (milliseconds) or MovementThreshold (meters)
                ReportInterval = 5000,
                //DesiredAccuracy = PositionAccuracy.High
                DesiredAccuracyInMeters = 1
            };
            _locator.PositionChanged += _locator_PositionChanged;
            _locator.StatusChanged += _locator_StatusChanged;
        }

        void _locator_StatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            this.Dispatcher.BeginInvoke(() =>
                {
                    var textBlock = this.FindName("StatusText") as TextBlock;
                    textBlock.Text = "Status: " + args.Status.ToString();
                });
        }

        void _locator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            this.Dispatcher.BeginInvoke(() =>
                {
                    var geoCoordinate = args.Position.Coordinate.ToGeoCoordinate();
                    var locationMarker = this.FindName("locationMarker") as UserLocationMarker;
                    if (locationMarker != null)
                    {
                        locationMarker.Visibility = System.Windows.Visibility.Visible;
                        locationMarker.GeoCoordinate = geoCoordinate;
                        WorldMap.SetView(geoCoordinate, 15);
                    }
                });
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _locator.PositionChanged -= _locator_PositionChanged;
            _locator = null;
            base.OnNavigatedFrom(e);
        }

        private async void WhereAmIButton_Click_1(object sender, EventArgs e)
        {
            // get the current location
            var geoLocator = new Geolocator();
            geoLocator.DesiredAccuracy = PositionAccuracy.High;
            var position = await geoLocator.GetGeopositionAsync();
            // use toolkit extension ToGeoCoordinate get usable type
            var geoCoordinate = position.Coordinate.ToGeoCoordinate();
            // get the UserLocationMarker element, make visible and position
            var locationMarker = this.FindName("locationMarker") as UserLocationMarker;
            locationMarker.Visibility = System.Windows.Visibility.Visible;
            locationMarker.GeoCoordinate = geoCoordinate;
            // center the map on the coordinate
            WorldMap.SetView(geoCoordinate, 13);
        }
    }
}