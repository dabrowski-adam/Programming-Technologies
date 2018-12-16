using BookstoreLogic.Logic;
using BookstoreLogic.Data;

namespace BookstoreLogic.LogicImplementations
{
    public class ConstantsBookstoreFiller : IBookstoreFiller
    {
        public void Fill(BookstoreState state)
        {
            FillBooks(state);
            FillInvoices(state);
        }

        

        private void FillBooks(BookstoreState state)
        {
            state.BookstoreBooks.Add(new Book("Ślepnąc od świateł", "Jakub Żulczyk", "Modern literature", 1));
            state.BookstoreBooks.Add(new Book("Tatuażysta z Auschwitz", "Heather Morris ", "Historic", 5));
            state.BookstoreBooks.Add(new Book("Myszy i ludzie", "John Steinbeck", "Modern literature", 3));
            state.BookstoreBooks.Add(new Book("Opowieść podręcznej", "Margaret Atwood", "Modern literature", 4));
            state.BookstoreBooks.Add(new Book("Wielki Gatsby", "F. Scott Fitzgerald", "Drama", 2));
            state.BookstoreBooks.Add(new Book("Pachnidło. Historia pewnego mordercy", "Patrick Süskind", "Drama", 2));
            state.BookstoreBooks.Add(new Book("Mój piękny syn", "David Sheff", "Biography", 2));
        }
        
        private void FillInvoices(BookstoreState state)
        {
            state.BookInvoices.Add(new Sale(state.BookstoreBooks[1]));
            state.BookInvoices.Add(new Sale(state.BookstoreBooks[3]));
            state.BookInvoices.Add(new Sale(state.BookstoreBooks[5]));
            state.BookInvoices.Add(new Sale(state.BookstoreBooks[0]));
            state.BookInvoices.Add(new Sale(state.BookstoreBooks[4]));
        }
    }
}
