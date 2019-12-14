using System;
using CakeSessionLibrary;

namespace CakeSessionApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Class1();
            var c2 = new Class2();
            var c3 = new Class3();

            c1.DoStuff();
            c2.DoStuff();
            c3.DoStuff();

            DoEvenMoreStuff();
        }

        public static void DoEvenMoreStuff()
        {
            Console.WriteLine("Done more stuff!");
        }
    }
}
