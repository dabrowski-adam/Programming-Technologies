using System;
using System.Collections.Generic;
using System.Text;
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
            Inventory inventory = new Inventory { { isbn, count } };
            Assert.Single(inventory);
            Assert.Equal(count, inventory[isbn]);
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

        #region InventoryAdd
        [Theory]
        [ClassData(typeof(InventoryTestData))]
        public void InventoryAdd(ISBN isbn, int count)
        {
            Inventory inventory = new Inventory { { isbn, count } };
            inventory.Add(isbn, count);
            inventory.Add(isbn, 2);
            Assert.Equal(inventory[isbn],count+2);
        }
        #endregion

    }
}
