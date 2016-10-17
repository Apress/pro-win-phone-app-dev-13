using System.Collections.Generic;

namespace CustomizingTheVisualStudioProject.Models
{
    public class PhonebookResult
    {
        public string UniqueId { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public double? UserRating { get; set; }
    }

    public class Phonebook
    {
        public List<PhonebookResult> Items { get; private set; }

        public Phonebook()
        {
            this.Items = new List<PhonebookResult>()
            {
                new PhonebookResult() { UniqueId = "1", Title = "Depot Hill Inn", 
                    PhoneNumber = "(831) 123-1324", UserRating = 8.7 },
                new PhonebookResult() { UniqueId = "2", Title = "City Hotel",     
                    PhoneNumber = "(831) 123-1324"  },
                new PhonebookResult() { UniqueId = "8", Title = "Venetian",       
                    PhoneNumber = "(831) 123-1324", UserRating = 9.8 },
                new PhonebookResult() { UniqueId = "4", Title = "Harbor Bay",     
                    PhoneNumber = "(831) 123-1324", UserRating = 5.2 },
                new PhonebookResult() { UniqueId = "5", Title = "Butterfly Cove", 
                    PhoneNumber = "(831) 123-1324"  },
                new PhonebookResult() { UniqueId = "6", Title = "El Grande",      
                    PhoneNumber = "(831) 123-1324", UserRating = 6 },
                new PhonebookResult() { UniqueId = "7", Title = "Beach House",    
                    PhoneNumber = "(831) 123-1324", UserRating = 7.7 },
                new PhonebookResult() { UniqueId = "9", Title = "By the Sea",     
                    PhoneNumber = "(831) 123-1324" },
                new PhonebookResult() { UniqueId = "3", Title = "Beach Hotel",  
                    PhoneNumber = "(831) 123-1324" }
            };
        }
    }
}
