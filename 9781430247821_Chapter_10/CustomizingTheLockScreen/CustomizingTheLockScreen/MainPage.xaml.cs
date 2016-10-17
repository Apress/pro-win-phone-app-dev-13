using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CustomizingTheLockScreen.Resources;
using Windows.Phone.System.UserProfile;

namespace CustomizingTheLockScreen
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string value = String.Empty;

            if (NavigationContext.QueryString.TryGetValue("WallpaperSettings", out value))
            {
                // navigate to a settings page in your application.
            }


            var isLockscreenProvider =
                LockScreenManager.IsProvidedByCurrentApplication;

            // if the app is already a provider, carry on, 
            // otherwise, request access from the user.
            if (!isLockscreenProvider)
            {
                var access = await LockScreenManager.RequestAccessAsync();
                isLockscreenProvider = access == LockScreenRequestResult.Granted;
            }

            // the user has granted access at some point
            // so create a path to the image for the lockscreen and set it.
            if (isLockscreenProvider)
            {
                // in app folder: "ms-appx:///"  
                // in isolated storage: "ms-appdata:///Local/";
                // lockedscreen image is marked as content
                var uri = new Uri("ms-appx:///Assets/lockscreen.jpg",
                    UriKind.Absolute);
                LockScreen.SetImageUri(uri);
            }
        }

        private async void SettingsButton_Click_1(object sender, EventArgs e)
        {
            // launch the settings page
            await Windows.System.Launcher.LaunchUriAsync(
                new Uri("ms-settings-lock:"));
        }
    }
}