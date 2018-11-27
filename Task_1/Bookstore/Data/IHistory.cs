using System.Collections.Generic;

namespace Data
{
    public interface IHistory
    {
        IList<IEvent> Events { get; }

        void LogStock(IActor seller, IInvoice invoice);

        void LogSale(IActor customer, IInvoice invoice);
    }
}
