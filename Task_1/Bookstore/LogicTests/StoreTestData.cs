using System.Collections.Generic;
using Logic;
using System;
using System.Collections;
using Data;

namespace LogicTests
{
    public class StoreTestData
    {
        static Func<IEnumerator, object> advance = enumerator => { enumerator.MoveNext(); return enumerator.Current; };

        public static IEnumerable<Store> GetStores()
        {
            StoreFactory storeFactory = new StoreFactory();

            yield return storeFactory.CreateStore(.0f);
            yield return storeFactory.CreateStore(1000f);
            yield return storeFactory.CreateStore(1000000f);
        }

        public static IEnumerable<Actor> GetActors()
        {
            yield return new Actor("John Smith");
            yield return new Actor("Maria Skłodowska-Curie");
            yield return new Actor("Los Nombres Españoles Son Demasiado Largos");
        }

        public static IEnumerable<Description> GetDescriptions()
        {
            yield return new Description("The Final Empire", "Brandon Sanderson");
            yield return new Description("Ostatnie Życzenie", "Andrzej Sapkowski");
            yield return new Description("Harry Potter and the Philosopher's Stone", "J.K. Rowling");
        }

        public static IEnumerable<object[]> GetStoresAndAffordableDeliveries()
        {
            using (IEnumerator<Store> stores = GetStores().GetEnumerator())
            using (IEnumerator<Actor> actors = GetActors().GetEnumerator())
            using (IEnumerator<Description> descriptions = GetDescriptions().GetEnumerator())
            {
                yield return new object[] { advance(stores), advance(actors), .0f, 1, new ISBN("1234567890123"), advance(descriptions) };

                yield return new object[] { advance(stores), advance(actors), 100f, 10, new ISBN("1234567890123"), advance(descriptions) };

                yield return new object[] { advance(stores), advance(actors), .01f, 10000, new ISBN("1234567890123"), advance(descriptions) };
            }
        }
    }
}
