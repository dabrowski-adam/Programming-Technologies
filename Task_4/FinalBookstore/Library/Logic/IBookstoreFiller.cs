using BookstoreLogic.Data;

namespace BookstoreLogic.Logic
{
    public interface IBookstoreFiller
    {
        void Fill(BookstoreState state);
    }
}
