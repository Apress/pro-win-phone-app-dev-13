using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MediaElement.Resources;
using Microsoft.Phone.Tasks;

namespace MediaElement
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            //MediaPlayerLauncher launcher = new MediaPlayerLauncher();
            //launcher.Media =
            //    new Uri(
            //"http://imgsrc.hubblesite.org/hu/gallery/db/video/hm_helix_twist/formats/hm_helix_twist_320x240.wmv");
            //launcher.Show();
        }
    }
}