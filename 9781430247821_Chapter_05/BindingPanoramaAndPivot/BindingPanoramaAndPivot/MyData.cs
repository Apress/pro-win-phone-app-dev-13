using System.Collections.Generic;

namespace BindingPanoramaAndPivot
{
    public class MyItemData
    {
        public string HeadingText { get; set; }
        public List<string> ContentItems { get; set; }
    }

    public class MyData
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public List<MyItemData> ItemData { get; set; }

        public MyData()
        {
            Title = "TITLE";
            Subtitle = "subtitle";
            ItemData = new List<MyItemData>() 
        {
            new MyItemData() 
            { 
                HeadingText = "heading one", 
                ContentItems = new List<string>() 
                { 
                    "Content 1 A", "Content 1 B", "Content 1 C"
                }
            },
            new MyItemData() 
            { 
                HeadingText = "heading two", 
                ContentItems = new List<string>() 
                { 
                    "Content 2 A", "Content 2 B", "Content 2 C" 
                }
            },          
            new MyItemData() 
            { 
                HeadingText = "heading three", 
                ContentItems = new List<string>() 
                { 
                    "Content 3 A", "Content 3 B", "Content 3 C", 
                }
            }
        };
        }
    }
}
