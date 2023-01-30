using Collections;

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






    }
}