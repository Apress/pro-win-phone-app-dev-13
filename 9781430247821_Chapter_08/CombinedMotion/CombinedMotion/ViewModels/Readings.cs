using System.Collections.Generic;
using System.Linq;

namespace CombinedMotion.ViewModels
{
    public class Readings
    {
        // pass in flat list of Reading, create grouped list
        public Readings(IEnumerable<Reading> readings)
        {
            this.Grouped =
                (from reading in readings
                 group reading by reading.SensorType into grouped
                 select new Group<SensorType, Reading>(grouped.Key, grouped)).ToList();
        }

        // bind presentation ItemsSource against this property
        public IList<Group<SensorType, Reading>> Grouped { get; set; }

        // update against this property
        public Reading this[SensorType sensorType, string name]
        {
            get
            {
                var group = this.Grouped
                    .Where(g => g.Key.Equals(sensorType))
                    .Single();
                return group.Where(r => r.Name.Equals(name)).Single();
            }
        }
    }
}
