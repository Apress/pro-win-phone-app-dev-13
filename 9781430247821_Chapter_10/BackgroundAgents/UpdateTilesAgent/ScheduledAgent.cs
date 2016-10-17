using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;

namespace UpdateTilesAgent
{
    public class ScheduledAgent : ScheduledTaskAgent
    {


        /// <remarks>
        /// ScheduledAgent constructor, initializes the UnhandledException handler
        /// </remarks>
        static ScheduledAgent()
        {
            // Subscribe to the managed exception handler
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                Application.Current.UnhandledException += UnhandledException;
            });
        }

        /// Code to execute on Unhandled Exceptions
        private static void UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        /// <summary>
        /// Agent that runs a scheduled task
        /// </summary>
        /// <param name="task">
        /// The invoked task
        /// </param>
        /// <remarks>
        /// This method is called when a periodic or resource intensive task is invoked
        /// </remarks>
        protected override void OnInvoke(ScheduledTask task)
        {
            var pageUri = new Uri("/", UriKind.Relative);
            var smalUri = new Uri("Assets/Tiles/FlipCycleTileSmall.png", UriKind.Relative);
            var mediumUri = new Uri("Assets/Tiles/FlipCycleTileMedium.png", UriKind.Relative);
            var largeUri = new Uri("Assets/Tiles/FlipCycleTileLarge.png", UriKind.Relative);

            var tiles = ShellTile.ActiveTiles
                .Where(t => t.NavigationUri.Equals(pageUri));
            var tile = tiles.SingleOrDefault();

            if (tile != null)
            {
                var tileData = new FlipTileData()
                {
                    Title = "We're no trouble",
                    BackContent = "Adopt me!",
                    SmallBackgroundImage = smalUri,
                    BackgroundImage = mediumUri,
                    WideBackgroundImage = largeUri,
                    Count = 6,

                    BackTitle = "Do you haz kibbles?",
                    WideBackContent = "Pick a fluffball",
                    BackBackgroundImage = mediumUri,
                    WideBackBackgroundImage = largeUri
                };

                tile.Update(tileData);
            }

            //NotifyComplete();
            this.Abort(); 
        }
    }
}