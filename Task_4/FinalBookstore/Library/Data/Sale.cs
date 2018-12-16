using System;
using System.Threading;

namespace BookstoreLogic.Data
{
    public class Sale
    {
        public static int SaleIDCounter = -1;

        public int ID { get; }
        public Book SoldBook { get; set; }
        public string InvoiceDate { get; set; }

        /* Creating Sale */
        public Sale(Book book)
        {
            ID = Interlocked.Increment(ref SaleIDCounter);
            SoldBook = book;            

            InvoiceDate = DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy hh:mm:ss");

            StartSale();
        }

        /* Called just after creating this Sale */
        private void StartSale()
        {
            SoldBook.SellBook();
        }

        /* Called just before removing this sale from the list */
        public void EndSale()
        {
            SoldBook.ChangeStatus();
        }


        public override string ToString()
        {
            return "[ID: " + ID + "]"
                    + ",  Sold book: " + SoldBook.Title
                    +", ISBN: " + SoldBook.ISBN
                    + ",  Invoice date: " + InvoiceDate;
        }
    }
}
