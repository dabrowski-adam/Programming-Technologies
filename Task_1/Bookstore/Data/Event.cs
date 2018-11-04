using System.Collections.Generic;

namespace Data
{
    public class Event
    {
        public Actor Actor { get; private set; }
        public List<Invoice> Invoices { get; private set; }

        public Event(Actor actor, List<Invoice> invoices)
        {
            this.Actor = actor;
            this.Invoices = new List<Invoice>(invoices);
        }
    }
}
