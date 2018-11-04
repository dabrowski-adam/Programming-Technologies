using Xunit;
using Data;

namespace DataTests
{
    public class InventoryTest
    {
        #region InventoryConstructor
        [Fact]
        public void InventoryConstructor()
        {
            Inventory inventory = new Inventory();
            Assert.Empty(inventory);
        }
        #endregion

        #region InventoryInsert
        [Theory]
        [ClassData(typeof(InventoryTestData))]
        public void CatalogInsert(ISBN isbn, int count)
        {
            Inventory inventory = new Inventory();
            inventory.Add(isbn, count);
            Assert.Single(inventory);
            Assert.Equal(count, inventory[isbn]);
        }
        #endregion

        #region InventoryInsertMultiple
        [Theory]
        [ClassData(typeof(InventoryTestData))]
        public void CatalogInsertMultiple(ISBN isbn, int count)
        {
            Inventory inventory = new Inventory();
            inventory.Add(isbn, count);
            inventory.Add(isbn, count);
            Assert.Single(inventory);
            Assert.Equal(count * 2, inventory[isbn]);
        }
        #endregion

        #region InventoryRemove
        [Theory]
        [ClassData(typeof(InventoryTestData))]
        public void InventoryRemove(ISBN isbn, int count)
        {
            Inventory inventory = new Inventory { { isbn, count } };
            inventory.Remove(isbn);
            Assert.Empty(inventory);
        }
        #endregion

        #region InventoryInsertThenRemove
        [Theory]
        [ClassData(typeof(InventoryTestData))]
        public void CatalogInsertThenRemove(ISBN isbn, int count)
        {
            Inventory inventory = new Inventory();
            inventory.Add(isbn, count);
            inventory.Add(isbn, count);
            inventory.Remove(isbn, count);
            Assert.Single(inventory);
            Assert.Equal(count, inventory[isbn]);
        }
        #endregion
    }
}
