using Xunit;

namespace DataTests2
{
    public class UnitTest1
    {
        #region Test1
        [Theory]
        [InlineData(2, 0)]
        [InlineData(1, 1)]
        [InlineData(0, 2)]
        public void Test1(int a, int b)
        {
            Assert.Equal(2, a + b);
        }
        #endregion

    }
}
