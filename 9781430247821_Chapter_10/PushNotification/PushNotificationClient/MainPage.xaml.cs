using System.Diagnostics;
using Microsoft.Phone;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Notification;

namespace PushNotificationClient
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            // unique name for the channel
            const string channelName = "AdoptABunny";

            // get existing channel or create a channel if it doesn't exist
            var channel = HttpNotificationChannel.Find(channelName) ??
                                                new HttpNotificationChannel(channelName);

            // hook up event handlers to know what the channel Uri is
            // and report any exceptions
            channel.ChannelUriUpdated += channel_ChannelUriUpdated;
            channel.ErrorOccurred += channel_ErrorOccurred;

            // open the channel
            if (channel.ChannelUri == null)
            {
                channel.Open();
            }
            else
            {
                Dispatcher.BeginInvoke(() =>
                    Debug.WriteLine(channel.ChannelUri.ToString()));
            }

            if (!channel.IsShellToastBound)
            {
                channel.BindToShellToast();
            }
            channel.ShellToastNotificationReceived += channel_ShellToastNotificationReceived;
            channel.HttpNotificationReceived += channel_HttpNotificationReceived;

            BindToast(); 
        }

        void channel_HttpNotificationReceived(object sender, HttpNotificationEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                Debug.WriteLine("Http notification received: " +
                                e.Notification.Channel.ToString());
                RawImage.Source = PictureDecoder.DecodeJpeg(e.Notification.Body);
            });
        }

        void channel_ShellToastNotificationReceived(object sender, NotificationEventArgs e)
        {
            foreach (var pair in e.Collection)
            {
                Debug.WriteLine(pair.Key + ": " + pair.Value);
            }
        }

        private void BindToast()
        {
            // unique name for the channel
            const string channelName = "AdoptABunny";

            // get existing channel or create a channel if it doesn't exist
            var channel = HttpNotificationChannel.Find(channelName) ??
                                                new HttpNotificationChannel(channelName);

            // hook up event handlers to know what the channel Uri is
            // and report any exceptions
            channel.ChannelUriUpdated += channel_ChannelUriUpdated;
            channel.ErrorOccurred += channel_ErrorOccurred;

            // open the channel
            if (channel.ChannelUri == null)
            {
                channel.Open();
            }
            else
            {
                Dispatcher.BeginInvoke(() =>
                    Debug.WriteLine(channel.ChannelUri.ToString()));
            }

            if (!channel.IsShellToastBound)
            {
                channel.BindToShellToast();
            }
        }

        private void BindTile()
        {
            // unique name for the channel
            const string channelName = "AdoptABunny";

            // get existing channel or create a channel if it doesn't exist
            var channel = HttpNotificationChannel.Find(channelName) ??
                                                new HttpNotificationChannel(channelName);

            // hook up event handlers to know what the channel Uri is
            // and report any exceptions
            channel.ChannelUriUpdated += channel_ChannelUriUpdated;
            channel.ErrorOccurred += channel_ErrorOccurred;

            // open the channel
            if (channel.ChannelUri == null)
            {
                channel.Open();
            }
            else
            {
                Dispatcher.BeginInvoke(() =>
                    Debug.WriteLine(channel.ChannelUri.ToString()));
            }

            if (!channel.IsShellTileBound)
            {
                channel.BindToShellTile();
            }
        }

        void channel_ErrorOccurred(object sender, NotificationChannelErrorEventArgs e)
        {
            Dispatcher.BeginInvoke(() => Debug.WriteLine("A push error occurred: " + e.Message));
        }

        void channel_ChannelUriUpdated(object sender, NotificationChannelUriEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
                Debug.WriteLine(e.ChannelUri.ToString()));
        }
    }
}