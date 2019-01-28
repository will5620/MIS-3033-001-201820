//Adam Ackerman
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Methods
{
    class Program
    {
        //static double sum = 0; Class level variable
        static void Main(string[] args)
        {
            double result = Addition(5.5,2);
            Console.WriteLine(result);
            double val1 = 10.5;
            double val2 = 1.5;

            Subtraction(val1, val2);

            Console.ReadKey();
        }

        private static void Subtraction(double val1, double val2)
        {
            Console.WriteLine($"{val1 - val2}");
        }

        static double Addition(double value1, double value2)
        {
            double sum = value1 + value2;
            return sum;
        }

    }
}
