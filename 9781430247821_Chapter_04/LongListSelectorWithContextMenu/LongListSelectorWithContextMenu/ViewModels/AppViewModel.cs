using System.Collections.ObjectModel;

namespace LongListSelectorWithContextMenu.ViewModels
{
    public class AppViewModel
    {
        public SubjectViewModel<string> Astronomy { get; private set; }
        public SubjectViewModel<string> Cooking { get; private set; }
        public SubjectViewModel<string> Languages { get; private set; }

        public AppViewModel()
        {
            this.Astronomy = new SubjectViewModel<string>("Astronomy");
            this.Astronomy.AddSubjects(new string[] { 
                "stars" , "planets", "comets", "nebulae", "galaxies", 
                "meteroids", "meteors", "asteroids"
            });

            this.Cooking = new SubjectViewModel<string>("Cooking");
            this.Cooking.AddSubjects(new string[] { 
                "baking" , "roasting", "grilling", "searing", "boiling", 
                "blanching", "smoking", "simmering", "stewing"
            });

            this.Languages = new SubjectViewModel<string>("Languages");
            this.Languages.AddSubjects(new string[] { 
                "arabic" , "afrikaans", "english", "french", "greek", 
                "urdu", "yiddish", "macedonian", "swedish", "tamil", "bengali"
            });

        }
    }
}
