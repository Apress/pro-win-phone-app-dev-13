
namespace BaseVM
{
    public class InheritsBaseViewModel: BaseViewModel
    {
        private string _foo;
        public string Foo 
        {
            get
            {
                return _foo;
            }
            set
            {
                _foo = value;
                NotifyPropertyChanged("Foo");
            }
        }
    }
}
