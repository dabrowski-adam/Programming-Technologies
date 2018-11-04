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
        [ClassData(typeof(CatalogTestData))]
        public void CatalogInsert(ISBN isbn, Book book)
        {
            Catalog catalog = new Catalog();
            catalog.Add(isbn, book);
            Assert.Single(catalog);
            Assert.Equal(book, catalog[isbn]);
        }
        #endregion

        #region CatalogRemove
        [Theory]
        [ClassData(typeof(CatalogTestData))]
        public void CatalogRemove(ISBN isbn, Book book)
        {
            Catalog catalog = new Catalog { { isbn, book } };
            catalog.Remove(isbn);
            Assert.Empty(catalog);
        }
        #endregion
    }
}
