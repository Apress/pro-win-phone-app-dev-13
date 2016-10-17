using System.Collections.Generic;
using System.Device.Location;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Services;
using Microsoft.Phone.Tasks;

namespace Directions
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

var wharf = new GeoCoordinate(36.96252, -122.023372);
var park = new GeoCoordinate(36.95172, -122.026783);
var lagoon = new GeoCoordinate(36.963365, -122.031932); 

var routeQuery = new RouteQuery()
{
    Waypoints = new List<GeoCoordinate>() { wharf, park, lagoon },
    InitialHeadingInDegrees = 90,
    RouteOptimization = RouteOptimization.MinimizeDistance,
    TravelMode = TravelMode.Driving
};
routeQuery.QueryCompleted += routeQuery_QueryCompleted;
routeQuery.QueryAsync();
        }

void routeQuery_QueryCompleted(object sender, QueryCompletedEventArgs<Route> e)
{
    if (e.Error == null)
    {
var mapRoute = new MapRoute(e.Result) 
{ 
    Color = Colors.Red, 
    RouteViewKind = RouteViewKind.UserDefined
}; 
this.WorldMap.AddRoute(mapRoute);
        this.WorldMap.SetView(e.Result.BoundingBox);

var sb = new StringBuilder();
var i = 0;

sb.AppendFormat("Estimated time: {0} minutes\n", 
    e.Result.EstimatedDuration.TotalMinutes.ToString()); 
foreach (var leg in e.Result.Legs)
{
    foreach (var maneuver in leg.Maneuvers)
    {
        sb.AppendFormat("{0}. {1}: {2}\n",
            ++i, maneuver.InstructionKind.ToString(), maneuver.InstructionText);
    }
}
MessageBox.Show(sb.ToString());
    }
}

        // run a directions task
        private static void RunTask()
        {
            var wharf = new LabeledMapLocation()
            {
                Label = "Wharf",
                Location = new GeoCoordinate(36.96252, -122.023372)
            };

            var park = new LabeledMapLocation()
            {
                Label = "Lighthouse Park",
                Location = new GeoCoordinate(36.95172, -122.026783)
            };

            var task = new MapsDirectionsTask() { Start = wharf, End = park };
            task.Show();
        }
    }
}