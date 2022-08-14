using System;
using System.Collections.Generic;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        [TestCaseSource("TestCaseConstructorData")]
        public void ConstructorShouldCreateDatabasePositiveTest(Person[] people, int expectedCount)
        {
            Database database = new Database(people);
            Assert.AreEqual(expectedCount, database.Count);
        }
        [Test]
        [TestCaseSource("TestCaseAddData")]
        public void AddMethodShouldAddDatabasePositiveTest(Person[] peopleCtor, Person[] peopleAdd, int expectedCount)
        {
            Database database = new Database(peopleCtor);
            foreach (var person in peopleAdd)
            {
                database.Add(person);
            }
            Assert.AreEqual(expectedCount, database.Count);
        }
        [Test]
        [TestCaseSource("TestCaseAddInvalidData")]
        public void AddShouldThrowException(
            Person[] peopleCtor,
            Person[] peopleAdd,
            Person person)
        {
            Database database = new Database(peopleCtor);
            foreach (var item in peopleAdd)
            {
                database.Add(item);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [Test]
        [TestCaseSource("TestCaseRemoveData")]
        public void RemoveShouldRemoveWithValidData(Person[] personCtor, Person[] personAdd, int expectedCount)
        {
            Database database = new Database(personCtor);
            foreach (var person in personAdd)
            {
                database.Add(person);
            }

            for (int i = 0; i < 3; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedCount, database.Count);
        }
        [Test]
        public void RemoveShouldThrowException()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        [TestCaseSource("TestCaseFindByUsernameIsNull")]
        public void FindByUsernameIsNullShouldThrowException(Person[] personCtor, string name)
        {

            Database database = new Database(personCtor);
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name));
        }
        [Test]
        [TestCaseSource("TestCaseFindByUsernameIsInvalid")]
        public void FindByUsernameIsInvalidShouldThrowException(Person[] personCtor, string name)
        {

            Database database = new Database(personCtor);
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(name));
        }
        [Test]
        [TestCaseSource("TestCaseFindByUsernameIsValid")]
        public void FindByUsernameIsValid(Person[] personCtor, Person person)
        {

            Database database = new Database(personCtor);
            Assert.AreEqual(person.UserName, database.FindByUsername(person.UserName).UserName);
        }

        [Test]
        [TestCaseSource("TestCaseFindByIdNegativeNumberException")]
        public void FindByIdShouldThrowExceptionWhenIsLessThan0(Person[] personCtor, long id)
        {
            Database database = new Database(personCtor);
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }
        [Test]
        [TestCaseSource("TestCaseFindByIdWithNoUser")]
        public void FindByIdWithNoUser(Person[] personCtor, long id)
        {
            Database database = new Database(personCtor);
            Assert.Throws<InvalidOperationException>(() => database.FindById(id));
        }

        [Test]
        [TestCaseSource("TestCaseFindByIdWithValidData")]
        public void FindByIdWithValidData(Person[] personCtor, long id)
        {
            Database database = new Database(personCtor);
            Assert.AreEqual(id, database.FindById(id).Id);
        }

        public static IEnumerable<TestCaseData> TestCaseFindByIdWithValidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(2,"marko"),
                        new Person(25,"varku"),
                        new Person(5,"mitio"),
                    },
                    2
                ),
            };
            foreach (var item in testCases)
            {
                yield return item;
            }
        }
        public static IEnumerable<TestCaseData> TestCaseFindByIdWithNoUser()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(2,"marko"),
                        new Person(25,"varku"),
                        new Person(5,"mitio"),
                    },
                    6
                ),
            };
            foreach (var item in testCases)
            {
                yield return item;
            }
        }
        public static IEnumerable<TestCaseData> TestCaseFindByIdNegativeNumberException()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(2,"marko"),
                        new Person(25,"varku"),
                        new Person(5,"mitio"),
                    },
                    -5
                ),
            };
            foreach (var item in testCases)
            {
                yield return item;
            }
        }
        public static IEnumerable<TestCaseData> TestCaseFindByUsernameIsValid()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(15,"marko"),
                        new Person(25,"varku"),
                        new Person(5,"mitio"),
                    },
                    new Person(23,"marko")
                ),
            };
            foreach (var item in testCases)
            {
                yield return item;
            }
        }
        public static IEnumerable<TestCaseData> TestCaseFindByUsernameIsInvalid()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(15,"marko"),
                        new Person(25,"varku"),
                        new Person(5,"mitio"),
                    },
                    "garga"
                ),
            };
            foreach (var item in testCases)
            {
                yield return item;
            }
        }
        public static IEnumerable<TestCaseData> TestCaseFindByUsernameIsNull()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                       new Person(15,""),
                    },
                    ""
                ),
            };
            foreach (var item in testCases)
            {
                yield return item;
            }
        }
        public static IEnumerable<TestCaseData> TestCaseRemoveData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "ivadasn"),
                        new Person(2, "gergreterter"),
                        new Person(3, "ma24234234rio"),
                    },
                    new Person[]
                    {
                        new Person(14, "ivwqasn"),
                        new Person(15, "geqfr"),
                        new Person(16, "margio"),
                    },
                    3
                ),
                new TestCaseData(
                    new Person[]
                    {
                    },
                    new Person[]
                    {
                        new Person(5, "ivan"),
                        new Person(6, "ger"),
                        new Person(7, "mario"),
                        new Person(8, "lu4o")
                    },
                    1
                ),
            };
            foreach (var item in testCases)
            {
                yield return item;
            }
        }
        public static IEnumerable<TestCaseData> TestCaseAddInvalidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "ivadasn"),
                        new Person(2, "gergreterter"),
                        new Person(3, "ma24234234rio"),
                        new Person(4, "da12sd"),
                        new Person(5, "mar22io"),
                        new Person(6, "d555a"),
                        new Person(7, "marwwswsgghhio"),
                        new Person(8, "marddio"),
                        new Person(9, "mariw4o"),
                        new Person(10, "mafaario"),
                        new Person(11, "maraaaio"),
                        new Person(12, "maaahjhjdrio"),
                        new Person(13, "mardwedio"),
                    },
                    new Person[]
                    {
                        new Person(14, "ivwqasn"),
                        new Person(15, "geqfr"),
                        new Person(16, "margio"),
                    },
                    new Person(17,"kir4u89")
                    ),
                new TestCaseData(
                    new Person[]
                    {
                    },
                    new Person[]
                    {
                        new Person(5, "ivan"),
                        new Person(6, "ger"),
                        new Person(7, "mario"),
                        new Person(8, "lu4o")
                    },
                    new Person(6,"ger")
                    ),
                new TestCaseData(
                    new Person[]
                    {
                    },
                    new Person[]
                    {
                        new Person(5, "ivan"),
                        new Person(6, "ger"),
                        new Person(7, "mario"),
                        new Person(8, "lu4o")
                    },
                    new Person(6,"ge22r")
                )
            };
            foreach (var item in testCases)
            {
                yield return item;
            }
        }
        public static IEnumerable<TestCaseData> TestCaseAddData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "ivan"),
                        new Person(2, "ger"),
                        new Person(3, "mario"),
                    },
                    new Person[]
                    {
                        new Person(51, "ivasn"),
                        new Person(62, "gefr"),
                        new Person(23, "margio"),
                    },
                    6),
                new TestCaseData(
                    new Person[]
                    {
                    },
                    new Person[]
                    {
                        new Person(5, "ivan"),
                        new Person(6, "ger"),
                        new Person(7, "mario"),
                        new Person(8, "lu4o")
                    },
                    4)
            };
            foreach (var item in testCases)
            {
                yield return item;
            }
        }
        public static IEnumerable<TestCaseData> TestCaseConstructorData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                    new Person[]
                    {
                        new Person(1, "ivan"),
                        new Person(2, "ger"),
                        new Person(3, "mario"),
                    },
                    3),
                new TestCaseData(
                    new Person[]
                    {
                        new Person(5, "ivan"),
                        new Person(6, "ger"),
                        new Person(7, "mario"),
                        new Person(8, "lu4o")
                    },
                    4)
            };
            foreach (var item in testCases)
            {
                yield return item;
            }
        }
    }
}