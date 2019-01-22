using System.Collections.Generic;
using Logic;
using System;
using System.Collections;
using Data;
using System.Linq;

namespace LogicTests
{
    public class StoreTestData
    {
        static Func<IEnumerator, object> advance = enumerator => { enumerator.MoveNext(); return enumerator.Current; };

        public static IEnumerable<Store> GetStores()
        {
            Store store1 = new Store(CatalogGenerator.PrepareData(), InventoryGenerator.PrepareData(), HistoryGenerator.PrepareData(), .0f);
            yield return store1;

            Store store2 = new Store(CatalogGenerator.PrepareData(), InventoryGenerator.PrepareData(), HistoryGenerator.PrepareData(), 1000f);
            yield return store2;

            Store store3 = new Store(CatalogGenerator.PrepareData(), InventoryGenerator.PrepareData(), HistoryGenerator.PrepareData(), 1000000f);
            yield return store3;
        }

        public static IEnumerable<object[]> GetStoresAndAffordableDeliveries()
        {
            using (IEnumerator<Store> stores = GetStores().GetEnumerator())
            using (IEnumerator<IActor> actors = ActorDataGenerator.PrepareData().GetEnumerator())
            using (IEnumerator<IBook> books = BookDataGenerator.PrepareData().GetEnumerator())
            using (IEnumerator<IDescription> descriptions = DescriptionDataGenerator.PrepareData().GetEnumerator())
            {
                yield return new object[] { advance(stores), advance(actors), .0f, 1, advance(books), advance(descriptions) };

                yield return new object[] { advance(stores), advance(actors), 100f, 10, advance(books), advance(descriptions) };

                yield return new object[] { advance(stores), advance(actors), .01f, 10000, advance(books), advance(descriptions) };
            }
        }

        public static IEnumerable<object[]> GetStoresAndTooExpensiveDeliveries()
        {
            using (IEnumerator<Store> stores = GetStores().GetEnumerator())
            using (IEnumerator<IActor> actors = ActorDataGenerator.PrepareData().GetEnumerator())
            using (IEnumerator<IBook> books = BookDataGenerator.PrepareData().GetEnumerator())
            using (IEnumerator<IDescription> descriptions = DescriptionDataGenerator.PrepareData().GetEnumerator())
            {
                yield return new object[] { advance(stores), advance(actors), .1f, 1, advance(books), advance(descriptions) };

                yield return new object[] { advance(stores), advance(actors), 100f, 11, advance(books), advance(descriptions) };

                yield return new object[] { advance(stores), advance(actors), 100000, 100, advance(books), advance(descriptions) };
            }
        }

        public static IEnumerable<object[]> GetStoresAndPossibleSales()
        {
            using (IEnumerator<IActor> actors = ActorDataGenerator.PrepareData().GetEnumerator())
            using (IEnumerator<IBook> books = BookDataGenerator.PrepareData().GetEnumerator())
            using (IEnumerator<IDescription> descriptions = DescriptionDataGenerator.PrepareData().GetEnumerator())
            {
                IActor customer = ActorDataGenerator.PrepareData().First();

                books.MoveNext();
                actors.MoveNext();
                descriptions.MoveNext();

                Store store = new Store(CatalogGenerator.PrepareData(), InventoryGenerator.PrepareData(), HistoryGenerator.PrepareData(), 1000000f);
                store.Stock(actors.Current, 100f, 2, books.Current, descriptions.Current);
                yield return new object[] { store, customer, books.Current, 1 };

                books.MoveNext();
                actors.MoveNext();
                descriptions.MoveNext();

                Store store2 = new Store(CatalogGenerator.PrepareData(), InventoryGenerator.PrepareData(), HistoryGenerator.PrepareData(), 1000000f);
                store2.Stock(actors.Current, 20f, 10, books.Current, descriptions.Current);
                yield return new object[] { store2, customer, books.Current, 2 };

                books.MoveNext();
                actors.MoveNext();
                descriptions.MoveNext();

                Store store3 = new Store(CatalogGenerator.PrepareData(), InventoryGenerator.PrepareData(), HistoryGenerator.PrepareData(), 1000000f);
                store3.Stock(actors.Current, 4.99f, 45, books.Current, descriptions.Current);
                yield return new object[] { store3, customer, books.Current, 15 };
            }
        }

        public static IEnumerable<object[]> GetStoresAndImpossibleSales()
        {
            using (IEnumerator<IActor> actors = ActorDataGenerator.PrepareData().GetEnumerator())
            using (IEnumerator<IBook> books = BookDataGenerator.PrepareData().GetEnumerator())
            using (IEnumerator<IDescription> descriptions = DescriptionDataGenerator.PrepareData().GetEnumerator())
            {
                IActor customer = ActorDataGenerator.PrepareData().First();

                books.MoveNext();
                actors.MoveNext();
                descriptions.MoveNext();

                Store store = new Store(CatalogGenerator.PrepareData(), InventoryGenerator.PrepareData(), HistoryGenerator.PrepareData(), 1000000f);
                store.Stock(actors.Current, 100f, 1, books.Current, descriptions.Current);
                yield return new object[] { store, customer, books.Current, 0 };

                books.MoveNext();
                actors.MoveNext();
                descriptions.MoveNext();

                Store store2 = new Store(CatalogGenerator.PrepareData(), InventoryGenerator.PrepareData(), HistoryGenerator.PrepareData(), 1000000f);
                store2.Stock(actors.Current, 20f, 3, books.Current, descriptions.Current);
                yield return new object[] { store2, customer, books.Current, 5 };

                IBook unavailableBook = books.Current;
                books.MoveNext();
                actors.MoveNext();
                descriptions.MoveNext();

                Store store3 = new Store(CatalogGenerator.PrepareData(), InventoryGenerator.PrepareData(), HistoryGenerator.PrepareData(), 1000000f);
                store3.Stock(actors.Current, 4.99f, 45, books.Current, descriptions.Current);
                yield return new object[] { store3, customer, unavailableBook, 500 };
            }
        }
    }
}
