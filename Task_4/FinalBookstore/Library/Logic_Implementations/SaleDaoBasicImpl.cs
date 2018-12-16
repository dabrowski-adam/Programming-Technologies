using System;
using System.Collections.Generic;
using System.Linq;
using BookstoreLogic.Logic;
using BookstoreLogic.Data;

namespace BookstoreLogic.LogicImplementations
{
    public class SaleDaoBasicImpl : ISaleDao
    {
        private BookstoreState BookstoreData;

        public SaleDaoBasicImpl(BookstoreState bookstoreData)
        {
            BookstoreData = bookstoreData;
        }




        public void AddSale(Sale sale)
        {
            BookstoreData.BookInvoices.Add(sale);
        }

        public void RemoveSale(int saleISBN)
        {
            Sale sale = GetSale(saleISBN);
                
            if (sale != null)
            {
                sale.EndSale();
                BookstoreData.BookInvoices.Remove(sale);
            }
            else
                throw new InvalidOperationException("RemoveSale: Cannot find specified sale");
        }

        public void RemoveSale(Book soldBook)
        {
            for (int i = 0; i < BookstoreData.BookInvoices.Count; i++)
            {
                if (BookstoreData.BookInvoices[i].SoldBook.ISBN == soldBook.ISBN)
                {
                    RemoveSale(BookstoreData.BookInvoices[i].ID);
                }
            } 
        }


        public Sale GetSale(int saleISBN)
        {
            for (int i = 0; i < BookstoreData.BookInvoices.Count; i++)
            {
                if (BookstoreData.BookInvoices[i].ID == saleISBN)
                {
                    return BookstoreData.BookInvoices[i];
                }
            }
            return null;
        }

        public List<Sale> GetAllInvoices()
        {
            return BookstoreData.BookInvoices;
        }
    }
}
