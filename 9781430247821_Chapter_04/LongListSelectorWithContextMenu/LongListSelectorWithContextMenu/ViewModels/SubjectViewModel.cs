using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LongListSelectorWithContextMenu.Commands;

namespace LongListSelectorWithContextMenu.ViewModels
{
    public class SubjectViewModel<T>
    {
        public SearchCommand SearchCommand { get; private set; }
        public ObservableCollection<T> Subjects { get; private set; }
        public string Title { get; private set; }

        public SubjectViewModel(string title)
        {
            this.Title = title;
            this.SearchCommand = new SearchCommand();
            this.Subjects = new ObservableCollection<T>();
        }

        public void AddSubjects(IEnumerable<T> subjects)
        {
            foreach (var subject in subjects)
            {
                this.Subjects.Add(subject);
            }
        }

        public void DeleteSubject(string searchOn)
        {
            var subject =
                this.Subjects.Single(s => s.ToString().Equals(searchOn));
            this.Subjects.Remove(subject);
        }
    }
}
