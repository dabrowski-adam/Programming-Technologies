using Xunit;
using Logic;

namespace LogicTests
{
    public class StoreFactoryTest
    {
        #region StoreDefaultsToZeroCapital
        [Fact]
        public void StoreDefaultsToZeroCapital()
        {
            StoreFactory storeFactory = new StoreFactory();
            Store store = storeFactory.CreateStore();
            Assert.Equal(.0f, store.Money);
        }
        #endregion

        #region StoreWithProvidedCapital
        [Theory]
        [InlineData(.0f)]
        [InlineData(3.50f)]
        [InlineData(1000000f)]
        public void StoreWithProvidedCapital(float capital)
        {
            StoreFactory storeFactory = new StoreFactory();
            Store store = storeFactory.CreateStore(capital);
            Assert.Equal(capital, store.Money);
        }
        #endregion
    }
}
