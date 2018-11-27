using System.Collections.Generic;
using Data;

namespace LogicTests
{
    internal static class InventoryGenerator
    {
        internal static IInventory PrepareData()
        {
            return new Inventory();
        }

        private class Inventory : IInventory
        {
            public IDictionary<IBook, uint> State { get; }

            public Inventory()
            {
                State = new Dictionary<IBook, uint>();
            }

            public IInvoice Sell(IBook book, float price, uint count)
            {
                if (State.ContainsKey(book))
                {
                    uint total = State[book];

                    if (total > count)
                    {
                        State[book] -= count;
                    }
                    else if (total == count)
                    {
                        State.Remove(book);
                    }
                    else
                    {
                        throw new System.ArgumentOutOfRangeException(nameof(count));
                    }

                    return new Invoice(book, price, count);
                }

                return null;
            }

            public IInvoice Stock(IBook book, float price, uint count)
            {
                if (State.ContainsKey(book))
                {
                    State[book] += count;
                }
                else
                {
                    State.Add(book, count);
                }

                return new Invoice(book, price, count);
            }
        }

        private class Invoice : IInvoice
        {
            public IBook Book { get; }

            public float Price { get; }

            public int Number { get; }

            public Invoice(IBook book, float price, uint number)
            {
                Book = book;
                Price = price;
                Number = (int)number;
            }
        }
    }
}
