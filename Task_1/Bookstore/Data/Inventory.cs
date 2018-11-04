using System.Collections.Generic;

namespace Data
{

    public class Inventory : Dictionary<ISBN, int>

    {
        internal new virtual void Add(ISBN key, int value)
        {
            if (!base.ContainsKey(key))
            {
                base.Add(key, value);
            }
            else;
        }
        /*
                internal new virtual void Add(ISBN key)
                 {
                      if (!base.ContainsKey(key))
                    {
                        base.Add(key);
                    }
                 }

            }
            */
    }
}
