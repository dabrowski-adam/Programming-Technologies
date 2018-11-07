using System.Collections.Generic;
using Data;

namespace Logic
{
    public class StoreFactory
    {
        public Store CreateStore()
        {
            return new Store(new Catalog(), new Inventory(), new List<Event>(), .0f);
        }

        public Store CreateStore(float capital)
        {
            return new Store(new Catalog(), new Inventory(), new List<Event>(), capital);
        }
    }
}
