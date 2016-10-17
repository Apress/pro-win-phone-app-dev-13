using System.Linq;
using System.Windows.Input;
using Microsoft.Phone.Controls;

namespace Input
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            var fields = typeof(InputScopeNameValue)
                .GetFields()
                .Where(f => f.IsLiteral)
                .Select(f => f.Name);

            ListBoxInputScope.ItemsSource = fields;
        }
     
    }
}