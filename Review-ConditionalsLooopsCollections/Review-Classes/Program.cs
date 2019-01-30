using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Console.ReadKey();
            Student adam = new Student();
            adam.FirstName = "Adam";
            adam.LastName = "Ackerman";
            adam.SoonerID = 1;
           
            Student tim = new Student(3, "Timothy", "Fisher", 80000.5);
            tim.IsOnProbation = true;
            Console.ReadKey();
        }
    }
}
