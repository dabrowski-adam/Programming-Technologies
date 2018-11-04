using System;
using Data;

namespace Logic
{
    public class Process
    {

        public void Buy(Book book, int amount)
        {
            Invoice invoice = new Invoice(book, book.Price, amount);

        }

        public void Stock(Book book, int amount)
        {
            Invoice invoice = new Invoice(book, book.Price, amount);

        }
    }
}
