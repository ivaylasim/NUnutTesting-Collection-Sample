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



    }
}