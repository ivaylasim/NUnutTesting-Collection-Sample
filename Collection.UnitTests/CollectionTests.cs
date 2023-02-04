using Collections;
using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;

namespace Collection.UnitTests
{
    public class CollectionTests
    {
        
        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            var coll = new Collection<int>();
            Assert.That(coll.ToString(), Is.EqualTo("[]"));
            Assert.That(coll.Count, Is.EqualTo(0));
            Assert.That(coll.Capacity, Is.EqualTo(16));
        }
        
        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var coll = new Collection<int>(5);
            Assert.That(coll.ToString(), Is.EqualTo("[5]"));
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var coll = new Collection<int>(5, 6);
            Assert.That(coll.ToString(), Is.EqualTo("[5, 6]"));
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var coll = new Collection<int>(5, 6);

            Assert.That(coll.Capacity, Is.GreaterThan(coll.Count));
            Assert.That(coll.Count, Is.EqualTo(2), "Check for Count:");
        }

        [Test]
        public void Test_Collection_Add()
        {
            //Arrange
            var coll = new Collection<string>("Ivan", "Peter");

            //Act
            coll.Add("Gosho");

            //Assert
            Assert.That(coll.ToString, Is.EqualTo("[Ivan, Peter, Gosho]"));
        }
        
        [Test]
        public void Test_Collection_GetByIndex()
        {
            var coll = new Collection<int>(5, 6, 7);
            var item = coll[1];

            Assert.That(item.ToString(), Is.EqualTo("6"));


        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var coll = new Collection<int>(5, 6, 7);
            coll[1] = 66;

            Assert.That(coll.ToString(), Is.EqualTo("[5, 66, 7]"));
        }


        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            //Arrange
            var names = new Collection<string>("Bob", "Joe");

            Assert.That(() => { var name = names[-1]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { var name = names[500]; },
              Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(names.ToString(), Is.EqualTo("[Bob, Joe]"));
        }

        [Test]
        public void Clear()
        {
            var coll = new Collection<int>(1, 2);
            coll.Clear();
            Assert.That(coll.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_AddRangeWithGrow()
        {
            Collection<int> coll = new Collection<int>(1, 2);

            Assert.That(coll.Count, Is.EqualTo(2), "Count");
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(1));

            for (int i = 0; i < 50; i++)
                {
                    coll.Add(i);
                }

            Assert.That(coll.Count, Is.EqualTo(52));
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(52));
            var expected = "[1, 2, " + String.Join(", ", Enumerable.Range(0, 50).ToArray()) + "]";
            Assert.That(expected, Is.EqualTo(coll.ToString()));
         }

            [Category ("DDTest")]
        [TestCase("Peter,Maria,Ivan", 0, "Peter")]
        [TestCase("Peter,Maria,Ivan", 1, "Maria")]
        [TestCase("Peter,Maria,Ivan", 2, "Ivan")]
        [TestCase("Peter", 0, "Peter")]
        public void Test_Collection_GetByValidIndex(string data, int index, string expected)
        {
            var coll = new Collection<string>(data.Split(","));
            var actual = coll[index];

            Assert.That(actual, Is.EqualTo(expected));
        }

            [Category("DDTest with lambda expression")]
        [TestCase("Peter", -1)]
        [TestCase("Peter,Maria,Ivan", -1)]
        [TestCase("Peter,Maria,Ivan", 3)]
        public void Test_Collection_GetByInvalidIndex(string data, int index)
        {
            var coll = new Collection<string>(data.Split(",",StringSplitOptions.RemoveEmptyEntries));
            
            Assert.That(() => coll[index], Throws.TypeOf<ArgumentOutOfRangeException>());
        }






    }
}