using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace NavigationToExternalURIs
{
    public partial class MainPage : PhoneApplicationPage
    {
        const string html =
                "<html><head>" +
                "<script type='text/javascript'>" +
                "function sendNotify(incoming) " +
                "{ window.external.notify(incoming + ' - sending back to phone'); }" +
                "</script></head><body></body></html>";

        public MainPage()
        {
            InitializeComponent();
        }

        private void TaskButton_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri =
                new Uri("http://www.falafel.com");
            webBrowserTask.Show();
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            Browser.Navigate(new Uri(AddressTextBox.Text));
        }

        private void Browser_Navigated(object sender,
            System.Windows.Navigation.NavigationEventArgs e)
        {
            StatusText.Text = Browser.IsScriptEnabled ? 
                "Navigated to script" : "Navigated to " + e.Uri.AbsoluteUri;
        }

        private void Browser_Navigating(object sender, NavigatingEventArgs e)
        {
            StatusText.Text = "Navigating to " + e.Uri.AbsoluteUri;
        }

        private void Browser_NavigationFailed(object sender,
            System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            MessageBox.Show("Navigation failed");
        }

        private void JavaScriptButton_Click(object sender, RoutedEventArgs e)
        {
            Browser.IsScriptEnabled = true;
            Browser.NavigateToString(html);
        }

        private void Browser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (Browser.IsScriptEnabled)
            {
                Browser.InvokeScript("sendNotify", new string[] { "invoked from phone" });
                Browser.IsScriptEnabled = false;
            }
        }

        private void Browser_ScriptNotify(object sender, NotifyEventArgs e)
        {
            MessageBox.Show("ScriptNotify: " + e.Value);
        }
    }
}