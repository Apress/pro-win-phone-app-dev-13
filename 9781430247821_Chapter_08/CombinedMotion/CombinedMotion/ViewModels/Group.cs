using System.Collections.Generic;

namespace CombinedMotion.ViewModels
{
    public class Group<TKey, T> : List<T>
    {
        public Group(TKey key, IEnumerable<T> items) :
            base(items)
        {
            this.Key = key;
        }
        public TKey Key
        {
            get;
            set;
        }
    }
}
