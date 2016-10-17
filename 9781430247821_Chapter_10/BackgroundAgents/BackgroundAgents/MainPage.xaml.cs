using System;
using System.Diagnostics;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;

namespace BackgroundAgents
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

    private void BackgroundButton_Click(object sender, EventArgs e)
    {
        const string taskName = "AdoptionTask";
        var task = ScheduledActionService.Find(taskName) as PeriodicTask;
        if (task != null)
        {
            ScheduledActionService.Remove(taskName);
        }
        task = new PeriodicTask(taskName);
        task.Description = "Update bunny adoptions tiles";
        try
        {
            ScheduledActionService.Add(task);
#if DEBUG
            ScheduledActionService.LaunchForTest(taskName, TimeSpan.FromSeconds(1));
#endif

        }
        catch (InvalidOperationException ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
}