using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementAndBindAConverter
{
    public enum Status { NotStarted, Deferred, InProgress, Complete };

    public class Project
    {
        public Status ProjectStatus { get; set; }
        public string ProjectTitle { get; set; }
        public string Description { get; set; }
    }

    public class Projects: List<Project>
    {
        public Projects()
        {
            this.Add(new Project() { ProjectTitle = "Implement TPS Reports", ProjectStatus = Status.InProgress, Description = "Verify that each one has a coversheet" });
            this.Add(new Project() { ProjectTitle = "Swingline Stapler Procurement", ProjectStatus = Status.NotStarted, Description = "Research and compare with the Boston Stapler" });
            this.Add(new Project() { ProjectTitle = "Design 'Jump to Conclusions' mat", ProjectStatus = Status.Deferred, Description = "This is horrible, this idea" });
            this.Add(new Project() { ProjectTitle = "Research Initech", ProjectStatus = Status.Complete, Description = "Out of business" });
        }
    }
}
