using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_ConditionalsLooopsCollections
{
    class Program
    {
        static void Main(string[] args)
        {

            //Conditionals
            //int age = 0;
            //string messageForUser = "Please enter yo age >>";

            //Console.WriteLine(messageForUser); // Ask the user to input their age
            //age = Convert.ToInt32(Console.ReadLine());

            //if (age == 18)
            //{
            //    Console.WriteLine("Congratz, you are 18");
            //}
            //else if (age == 16)
            //{
            //    Console.WriteLine("vroom vroom, you can drive.");
            //}
            //else
            //{
            //    Console.WriteLine("I don't know your age");
            //}
            //Console.WriteLine("Your age is " + age.ToString("N0")); //Concatenate a string with the value of our variable 'age' formated as a number with 0 decimal places


            //Loop

            //for (int i = 100; i >= 0; i--)
            //{
            //    if (i == 0)
            //    {
            //        Console.WriteLine("BLAST OFF ");
            //    }
            //    else
            //    {
            //        Console.WriteLine(i);

            //    }
            //}

            int i = 100;
            do
            {
                Console.WriteLine(i);
                i--;
            } while (i >= 0);

            while (i >= 0)
            {
                Console.WriteLine(i);
                i--;
            }

            Console.ReadKey();
        }
    }
}
