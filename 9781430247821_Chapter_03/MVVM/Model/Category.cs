using System.Collections.Generic;

namespace Model
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class Categories : List<Category>
    {
        public Categories()
        {
            this.Add(new Category()
            {
                ID = 1,
                Title = "Appliances",
                Description = "Great deals on refrigerators, stoves and air conditioners"
            });
            this.Add(new Category()
            {
                ID = 2,
                Title = "Bed and Bath",
                Description = "Mattresses, pillows, home decor"
            });
            this.Add(new Category()
            {
                ID = 3,
                Title = "Clothing",
                Description = "Mens, womens, kids and work apparel"
            });
            this.Add(new Category()
            {
                ID = 4,
                Title = "Electronics",
                Description = "Home theater, home office, phone accessories"
            });
        }
    }

}
