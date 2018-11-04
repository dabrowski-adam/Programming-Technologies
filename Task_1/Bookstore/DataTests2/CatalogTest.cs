using Xunit;
using Data;

namespace DataTests
{
    public class CatalogTest
    {
        #region CatalogConstructor
        [Fact]
        public void CatalogConstructor()
        {
            Catalog catalog = new Catalog();
            Assert.Empty(catalog);
        }
        #endregion

        #region CatalogInsert
        [Theory]
        [ClassData(typeof(BookTestData))]
        public void CatalogInsert(Book book)
        {
            Catalog catalog = new Catalog();
            ISBN isbn = new ISBN("0123456789123");
            catalog.Add(isbn, book);
            Assert.Single(catalog);
            Assert.Equal(book, catalog[isbn]);
        }
        #endregion

        #region CatalogRemove
        [Theory]
        [ClassData(typeof(BookTestData))]
        public void CatalogRemove(Book book)
        {
            Catalog catalog = new Catalog();
            ISBN isbn = new ISBN("0123456789123");
            catalog.Add(isbn, book);
            catalog.Remove(isbn);
            Assert.Empty(catalog);
        }
        #endregion
    }
}
