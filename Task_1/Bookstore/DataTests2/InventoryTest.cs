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

        #region InventoryAdd
        [Theory]
        [ClassData(typeof(InventoryTestData))]
        public void CanAddInventoryData(Book book)
        {
            Inventory inventory = new Inventory();
            inventory.Add(book);
            Assert.True(inventory.Contains(book));
            Assert.Single(inventory);
        }

        #endregion


        #region InventoryRemove
        [Theory]
        [ClassData(typeof(InventoryTestData))]
        public void CanRemoveInventoryData(Book book)
        {
            Inventory inventory = new Inventory();
            inventory.Add(book);
            inventory.Remove(book);
            Assert.False(inventory.Contains(book));
            Assert.Empty(inventory);
        }

        #endregion



    }
}
