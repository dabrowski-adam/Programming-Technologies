using Xunit;
using Data;

namespace DataTests
{
    public class ActorTest
    {
        #region ActorConstructor
        [Theory]
        [InlineData("John Smith")]
        [InlineData("Maria Skłodowska-Curie")]
        [InlineData("Los Nombres Españoles Son Demasiado Largos")]
        public void ActorConstructor(string name)
        {
            Actor actor = new Actor(name);
            Assert.Equal(name, actor.Name);
        }
        #endregion
    }
}
