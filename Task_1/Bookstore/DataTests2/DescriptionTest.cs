using Xunit;
using Data;

namespace DataTests
{
    public class DescriptionTest
    {
        #region DescriptionConstructor
        [Theory]
        [InlineData("The Final Empire", "Brandon Sanderson")]
        [InlineData("Ostatnie Życzenie", "Andrzej Sapkowski")]
        [InlineData("Harry Potter and the Philosopher's Stone", "J.K. Rowling")]
        public void DescriptionConstructor(string title, string author)
        {
            Description book = new Description(title, author);
            Assert.Equal(title, book.Title);
            Assert.Equal(author, book.Author);
        }
        #endregion
    }
}
