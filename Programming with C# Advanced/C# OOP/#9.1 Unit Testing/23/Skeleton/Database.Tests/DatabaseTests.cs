using System;
using System.Linq;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Initialize()
        {
            database = new Database();
        }

        [Test]
        public void ConstructorShouldAllItemsWhileTheyAreBelow16()
        {
            int[] elements = Enumerable.Range(1, 15).ToArray();
            database = new Database(elements);

            Assert.AreEqual(15, database.Count);
        }
        [Test]
        public void ConstructorShouldThrowExceptionWhenItemAreAbove16()
        {
            int[] elements = Enumerable.Range(1, 17).ToArray();
            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }
        [Test]
        public void AddMethodShouldAddNewElementWhileCountIsLessThan16()
        {
            database.Add(1);
            database.Add(1);
            database.Add(1);

            Assert.AreEqual(3, database.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenItemsAreAbove16()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(1);
            }

            Assert.That(() => database.Add(5),
                Throws.InvalidOperationException.With
                    .Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void RemoveMethodShouldRemoveElementsWhenTheyAreAbove16()
        {
            int[] elements = Enumerable.Range(1, 16).ToArray();
            database = new Database(elements);
            database.Remove();

            Assert.AreEqual(15, database.Count);
        }
        [Test]
        public void RemoveMethodShouldThrowExceptionWhenCountIsLessThan0()
        {
            Assert.That(() => database.Remove(),
                Throws.InvalidOperationException.With
                    .Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void FetchMethodShouldReturnAllValidItems()
        {
            database = new Database(1, 2, 3);

            database.Add(4);
            database.Add(5);

            database.Remove();
            database.Remove();
            database.Remove();

            int[] fetchedData = database.Fetch();
            int[] expectedData = new int[] { 1, 2 };
            Assert.AreEqual(expectedData, fetchedData);
        }
    }
}
