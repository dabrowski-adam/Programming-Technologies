using System;
using System.Collections.Generic;

namespace Data
{
    public class Event
    {
        private List<Invoice> Invoices { get; private set; }

        public Event(List<Invoice> invoices)
        {
            this.Invoices = new List<Invoice>(invoices)
        }
    }
}
