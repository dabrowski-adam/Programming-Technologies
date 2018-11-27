using System.Collections.Generic;

namespace Data
{
    public interface IInventory
    {
        IDictionary<IBook, uint> State { get; }

        IInvoice Stock(IBook book, float price, uint count);

        IInvoice Sell(IBook book, float price, uint count);
    }
}
