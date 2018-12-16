using System.Threading;

namespace BookstoreLogic.Data
{
    public class Book
    {
        public static int BookISBNCounter = -1;

        public int ISBN { get; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Count = 0;
        public BookState State { get; set; }

        /* Creating book */
        public Book (string title, string author, string genre, int count)
        {
            ISBN = Interlocked.Increment(ref BookISBNCounter);
            Title = title;
            Author = author;
            Genre = genre;
            Count = count;

            State = BookState.Available;
        }

        /* Editing book */
        public void UpdateBookData (BookUpdateData data)
        {
            Title = data.title;
            Author = data.author;
            Genre = data.genre;
        }



        /* Selling book */
        public void SellBook ()
        {
            if (Count<=0)
            {
                State = BookState.Unavailable;
            }
            if (Count ==1)
            {
                State = BookState.Unavailable;
                Count = Count - 1;

            }
            else {  Count = Count - 1;
            }
           
        }

        public void ChangeStatus ()
        {
            if (State == BookState.Available)
            {
                State = BookState.Unavailable;

            }
            else
            { 
            State = BookState.Available;
            }
        }



        public override string ToString()
        {
            string bookStatus = State == BookState.Available ? ",   Status: Available " : ",    Status: unavailable ";
            return "[ISBN: " + ISBN + "],  Title: " + Title + ",  Author: " + Author + ",  Genre: " + Genre + bookStatus + "Count: " + Count;
        }
    }



    public enum BookState
    {
        Available,
        Unavailable,
    }



    public class BookUpdateData
    {
        public int bookId;
        public string title;
        public string author;
        public string genre;

        public BookUpdateData(int bookId, string title, string author, string genre)
        {
            this.bookId = bookId;
            this.title = title;
            this.author = author;
            this.genre = genre;
        }
    }
}
