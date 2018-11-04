using Xunit;
using Data;

namespace DataTests
{
    public class BookTest
    {
        #region DescriptionConstructor
        [Theory]
        [ClassData(typeof(BookTestData))]
        public void DescriptionConstructor(Description description, float price)
        {
            Book book = new Book(description, price);
            Assert.Equal(description, book.Description);
            Assert.Equal(price, book.Price);
        }
        #endregion
    }
}
