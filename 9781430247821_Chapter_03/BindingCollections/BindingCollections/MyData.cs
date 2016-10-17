using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingCollections
{
public class Item
{
    public string Title { get; set; }
    public string Description { get; set; }
}

public class MyData : List<Item>
{
    public int ID { get; set; }
    public string AppTitle { get; set; }
    public string PageName { get; set; }

    public MyData()
    {
        this.ID = 1;
        this.AppTitle = "Real Estate Explorer";
        this.PageName = "Explorer";
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
