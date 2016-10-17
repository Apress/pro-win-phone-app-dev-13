using System.Collections.Generic;
using Microsoft.Phone.Controls;

namespace AutoCompleteBox
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            autoCompleteBox1.ItemsSource = new List<string>()  { "Monday",  "Tuesday", 
                    "Wednesday",  "Thursday", "Friday", "Saturday", "Sunday" }; ;
        }
    }
}