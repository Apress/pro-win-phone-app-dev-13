using System.Collections.Generic;

namespace BindObjects
{
public class Item
{
    public string Title { get; set; }
    public string Description { get; set; }
}

public class MyData : List<Item>
{
    public string AppTitle { get; set; }
    public string PageName { get; set; }

    public MyData()
    {
        this.AppTitle = "Real Estate Explorer";
        this.PageName = "explorer";
        this.Add(new Item { 
            Title = "Open House", 
            Description = "Open Houses in your area" 
        });
        this.Add(new Item { 
            Title = "Price Reduction", 
            Description = "New deals this week" 
        });
        this.Add(new Item { 
            Title = "Recently Sold", 
            Description = "What's moving in the market" 
        });
    }
}
}
