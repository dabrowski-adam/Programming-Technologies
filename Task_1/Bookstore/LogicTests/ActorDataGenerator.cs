using System.Collections.Generic;
using Data;

namespace LogicTests
{
    public class ActorDataGenerator
    {
        internal static IEnumerable<IActor> PrepareData()
        {
            return new List<IActor>
            {
                new Actor("John Smith"),
                new Actor("Maria Skłodowska-Curie"),
                new Actor("Los Nombres Españoles Son Demasiado Largos"),
            };
        }

        private class Actor : IActor
        {
            public string Name { get; }

            public Actor(string name)
            {
                Name = name;
            }
        }
    }
}