using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace HandlingApplicationBarEvents
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            MediaElement1.Play();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            MediaElement1.Pause();
        }

        private void ExternalUrlButton_Click(object sender, EventArgs e)
        {
            const string url = "/Assets/Video/Wildlife.wmv";
            MediaElement1.Source = new Uri(url, UriKind.Relative);
        }

    }
}