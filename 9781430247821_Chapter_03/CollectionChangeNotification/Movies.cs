using System.Collections.ObjectModel;

namespace CollectionChangeNotification
{
    public class Movie
    {
        public string Title { get; set; }
        public string Quote { get; set; }
        public int Year { get; set; }
    }

    public class Movies : ObservableCollection<Movie>
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
