using System.Collections.Generic;
using System.Linq;
using Microsoft.Phone.Controls;

namespace LongListSelector
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

var flatList = new List<MyObject>()
    {
        new MyObject() { Category = "A", Data = "some data 1" },
        new MyObject() { Category = "A", Data = "some data 2" },
        new MyObject() { Category = "B", Data = "some data 3" },
        new MyObject() { Category = "C", Data = "some data 4" },
        new MyObject() { Category = "C", Data = "some data 5" },
        new MyObject() { Category = "C", Data = "some data 6" },
        new MyObject() { Category = "D", Data = "some data 7" },
        new MyObject() { Category = "E", Data = "some data 8" },
        new MyObject() { Category = "E", Data = "some data 9" },
        new MyObject() { Category = "E", Data = "some data 10" },
    };

var groups =
    (from obj in flatList
        group obj by obj.Category into g
        orderby g.Key
        select new Group<string, MyObject>(g.Key, g));

LongListSelector1.ItemsSource = groups.ToList();
        }
    }
}