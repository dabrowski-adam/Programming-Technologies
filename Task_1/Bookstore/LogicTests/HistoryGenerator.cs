using System.Collections.Generic;
using Data;

namespace LogicTests
{
    internal static class HistoryGenerator
    {
        internal static IHistory PrepareData()
        {
            return new History();
        }

        private class History : IHistory
        {
            public IList<IEvent> Events { get; }

            public History()
            {
                Events = new List<IEvent>();
            }

            public void LogSale(IActor customer, IInvoice invoice)
            {
                Events.Add(new SaleEvent(customer, new List<IInvoice> { invoice }));
            }

            public void LogStock(IActor seller, IInvoice invoice)
            {
                Events.Add(new StockEvent(seller, new List<IInvoice> { invoice }));
            }
        }

        private class Event : IEvent
        {
            public IActor Actor { get; }

            public List<IInvoice> Invoices { get; }

            public Event(IActor actor, List<IInvoice> invoices)
            {
                Actor = actor;
                Invoices = invoices;
            }
        }

        private class SaleEvent : Event, ISaleEvent
        {
            public SaleEvent(IActor actor, List<IInvoice> invoices) : base(actor, invoices)
            {
            }
        }

        private class StockEvent : Event, IStockEvent
        {
            public StockEvent(IActor actor, List<IInvoice> invoices) : base(actor, invoices)
            {
            }
        }
    }
}
