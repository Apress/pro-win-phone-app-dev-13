using System;
using System.Diagnostics;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;

namespace AlarmsAndReminders
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AlarmButton_Click(object sender, EventArgs e)
        {
            var uniqueName = Guid.NewGuid().ToString();
            var alarm = new Alarm(uniqueName)
            {
                BeginTime = DateTime.Now.AddSeconds(20),
                Content = "Gather tax documents",
                Sound = new Uri(@"assets\sounds\windows notify.wav", UriKind.Relative)
            };

            try
            {
                ScheduledActionService.Add(alarm);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void ReminderButton_Click(object sender, EventArgs e)
        {
            var uniqueName = Guid.NewGuid().ToString();
            var reminder = new Reminder(uniqueName)
            {
                BeginTime = DateTime.Now.AddSeconds(20),
                Title = "Taxes",
                Content = "View tax check list",
                NavigationUri = new Uri("/TaxChecklist.xaml?Param1=One", UriKind.Relative)
            };
            try
            {
                ScheduledActionService.Add(reminder);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}