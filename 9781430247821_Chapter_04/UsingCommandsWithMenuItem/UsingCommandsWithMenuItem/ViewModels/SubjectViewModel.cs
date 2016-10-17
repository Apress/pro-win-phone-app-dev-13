
namespace UsingCommandsWithMenuItem
{
    public class SubjectViewModel
    {
        public Subjects Subjects { get; set; }
        public SearchCommand SearchCommand { get; set; }
        public SubjectViewModel()
        {
            this.Subjects = new Subjects();
            this.SearchCommand = new SearchCommand();
        }
    }
}
