using NUnit.Framework;

namespace CakeSessionLibrary.Test
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
            var c1 = new Class1();
            c1.DoStuff();
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            var c2 = new Class2();
            c2.DoStuff();
            Assert.Pass();
        }
    }
}