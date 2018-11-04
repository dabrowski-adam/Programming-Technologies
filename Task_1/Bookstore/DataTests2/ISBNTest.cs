using Xunit;
using Data;

namespace DataTests
{
    public class ISBNTest
    {
        #region ISBNConstructor
        [Theory]
        [InlineData("9780765311788")]
        [InlineData("9788370540616")]
        [InlineData("9780439554930")]
        public void ISBNConstructor(string id)
        {
            ISBN isbn = new ISBN(id);
            Assert.Equal(id, isbn.Id);
        }
        #endregion

        #region ISBNSame
        [Theory]
        [InlineData("9780765311788", "9780765311788")]
        [InlineData("9788370540616", "9788370540616")]
        public void ISBNSame(string id1, string id2)
        {
            ISBN isbn1 = new ISBN(id1);
            ISBN isbn2 = new ISBN(id2);

            Assert.Equal(isbn1, isbn2);
        }
        #endregion

        #region ISBNDifferent
        [Theory]
        [InlineData("9780765311788", "9788370540616")]
        [InlineData("9788370540616", "9780765311788")]
        public void ISBNDifferent(string id1, string id2)
        {
            ISBN isbn1 = new ISBN(id1);
            ISBN isbn2 = new ISBN(id2);

            Assert.NotEqual(isbn1, isbn2);
        }
        #endregion
    }
}
