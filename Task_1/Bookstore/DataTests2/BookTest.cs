using Xunit;
using Data;

namespace DataTests
{
    public class BookTest
    {
        #region BookTest
        [Theory]
        [InlineData("Mistborn", "Brandon Sanderson")]
        [InlineData("Ostatnie Życzenie", "Andrzej Sapkowski")]
        [InlineData("Harry Potter and the Philosopher's Stone", "J.K. Rowling")]
        public void BookConstructor(string title, string author)
        {
            Book book = new Book(title, author);
            Assert.Equal(title, book.Title);
            Assert.Equal(author, book.Author);
        }
        #endregion

    }
}
