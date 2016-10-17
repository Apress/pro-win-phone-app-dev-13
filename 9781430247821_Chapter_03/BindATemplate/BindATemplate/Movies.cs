using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindATemplate
{
    public class Movie
    {
        public string Title { get; set; }
        public string Quote { get; set; }
        public int Year { get; set; }
    }

    public class Movies : List<Movie>
    {
        public Movies()
        {
            this.Add(new Movie()
            {
                Title = "A League of Their Own",
                Quote = "There's no crying in baseball!",
                Year = 1992
            }); this.Add(new Movie()
            {
                Title = " Les Misérables",
                Quote = "Those who do not weep, do not see.",
                Year = 2012
            });
            this.Add(new Movie()
            {
                Title = "Dirty Harry",
                Quote = "Do I feel lucky?' Well, do ya, punk?",
                Year = 1971
            });
        }
    }
}
