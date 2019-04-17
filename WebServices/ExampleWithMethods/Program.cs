using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWithMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Banana().Name);
            Console.ReadKey();
        }

        public static Fruit Banana()
        {
            return new Fruit()
            { Name = "Banana", Ounces = 7.8 };
        }
    }
}
