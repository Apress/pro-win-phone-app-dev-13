using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingToOtherElements
{
    public class Priorities: List<string>
    {
        public Priorities()
        {
            this.Add("High");
            this.Add("Medium");
            this.Add("Low");
        }
    }
}
