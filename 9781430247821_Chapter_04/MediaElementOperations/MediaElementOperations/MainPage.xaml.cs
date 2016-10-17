using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Linq;
using System.Windows.Media;

namespace MediaElementOperations
{
    public partial class MainPage : PhoneApplicationPage
    {

        private ApplicationBarIconButton playButton = null;
        private ApplicationBarIconButton pauseButton = null;
        private ApplicationBarIconButton fastForwardButton = null;
        private ApplicationBarIconButton rewindButton = null;

        public MainPage()
        {
            InitializeComponent();
            MediaWindow.MediaFailed += new EventHandler<ExceptionRoutedEventArgs>(MediaWindow_MediaFailed);
            MediaWindow.CurrentStateChanged += new RoutedEventHandler(MediaWindow_CurrentStateChanged);

            var buttons = this.ApplicationBar.Buttons
                .Cast<ApplicationBarIconButton>();

            playButton = buttons
                .Where(b => b.Text.ToLower().Equals("play"))
                .Single();

            pauseButton = buttons
                .Where(b => b.Text.ToLower().Equals("pause"))
                .Single();

            fastForwardButton = buttons
                    .Where(b => b.Text.ToLower().Equals("fast forward"))
                    .Single();

            rewindButton = buttons
                .Where(b => b.Text.ToLower().Equals("rewind"))
                .Single();
        }

        void MediaWindow_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            if (MediaWindow.CurrentState != MediaElementState.Closed)
            {
                fastForwardButton.IsEnabled = true;
                rewindButton.IsEnabled = true;
            }

            playButton.IsEnabled = MediaWindow.CurrentState != MediaElementState.Playing;
            pauseButton.IsEnabled = MediaWindow.CanPause ?
                MediaWindow.CurrentState != MediaElementState.Paused : false;
        }

        void MediaWindow_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show(e.ErrorException.Message);
        }

        private void RewindButton_Click(object sender, EventArgs e)
        {
            MediaWindow.Position = new TimeSpan(0);
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            MediaWindow.Play();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            MediaWindow.Pause();
        }

        private void FastForwardButton_Click(object sender, EventArgs e)
        {
            TimeSpan current = MediaWindow.Position;
            MediaWindow.Position =
                current.Add(new TimeSpan(0, 0, 1));
        }

        private void CurrentMedia_Click(object sender, EventArgs e)
        {
            ApplicationBarMenuItem item = sender as ApplicationBarMenuItem;
            MediaWindow.Source = new Uri("/Assets/Media/" + item.Text, UriKind.Relative);
        }

        private void ExternalUrlButton_Click(object sender, EventArgs e)
        {
            const string url =
                "http://imgsrc.hubblesite.org/hu/explore_astronomy/" +
                "hubbles_universe/db/47/hu_tonights_sky_02_2010_320x240.wmv";
            MediaWindow.Source = new Uri(url);
        }

    }
}