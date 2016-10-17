using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;

namespace StylingPushpins.ViewModels
{
    public class Location
    {
        public string Title { get; set; }
        [TypeConverter(typeof(GeoCoordinateConverter))]
        public GeoCoordinate GeoCoordinate { get; set; }
    }

    public class LocationViewModel
    {
        public ObservableCollection<Location> Locations { get; set; }

        public LocationViewModel()
        {
            Locations = new ObservableCollection<Location>();
        }
    }
}
