using System.Collections.Generic;

namespace Data
{

    public class Inventory : Dictionary<ISBN, int>

    {
        internal virtual new void Add(ISBN key, int value)
        {
            if (!base.ContainsKey(key))
            {
                base.Add(key, value);
            }
            else this[key] = this[key] + value;
        }

    }
}
