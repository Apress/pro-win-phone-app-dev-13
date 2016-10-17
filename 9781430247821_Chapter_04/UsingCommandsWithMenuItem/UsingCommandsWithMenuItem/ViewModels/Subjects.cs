using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingCommandsWithMenuItem
{
    public class Subject
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class Subjects : List<Subject>
    {
        public Subjects()
        {
            this.Add(new Subject()
            {
                Title = "Stars",
                Description = "Hot Hydrogen Gas"
            });
            this.Add(new Subject()
            {
                Title = "Planets",
                Description = "Wandering stars"
            });
            this.Add(new Subject()
            {
                Title = "Comets",
                Description = "Icy Small Solar System Bodies"
            });
            this.Add(new Subject()
            {
                Title = "Nebulae",
                Description = "Interstellar Clouds"
            });
            this.Add(new Subject()
            {
                Title = "Galaxies",
                Description = "Gravitationally Bound Systems"
            });
        }
    }
}
