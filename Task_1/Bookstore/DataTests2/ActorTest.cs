using Xunit;
using Data;

namespace DataTests
{
    public class ActorTest
    {
        #region NameTest
        [Theory]
        [InlineData("John Smith")]
        [InlineData("Maria Skłodowska-Curie")]
        [InlineData("Los Nombres Españoles Son Demasiado Largos")]
        public void NameTest(string name)
        {
            Actor actor = new Actor(name);
            Assert.Equal(name, actor.Name);
        }
        #endregion

    }
}
