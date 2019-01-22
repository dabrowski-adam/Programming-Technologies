using System.Collections.Generic;

namespace Data
{
    public interface IEvent
    {
        IActor Actor { get; }
        List<IInvoice> Invoices { get; }
    }
}
