using System;
using System.Diagnostics;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;

namespace Toasts
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void ToastButton_Click(object sender, EventArgs e)
        {
            
            const string taskName = "AdoptionToast";
            var task = ScheduledActionService.Find(taskName) as PeriodicTask;
            if (task != null)
            {
                ScheduledActionService.Remove(taskName);
            }
            task = new PeriodicTask(taskName);
            task.Description = "Send a toast";
            try
            {
                ScheduledActionService.Add(task);
#if DEBUG
                ScheduledActionService.LaunchForTest(taskName, TimeSpan.FromSeconds(30));
#endif
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }
    }
}