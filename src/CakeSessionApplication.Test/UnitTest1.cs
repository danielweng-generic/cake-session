using NUnit.Framework;

namespace CakeSessionApplication.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Program.DoEvenMoreStuff();
            Assert.Pass();
        }
    }
}