using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Classes
{
    class Student
    {
        public int SoonerID { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsOnProbation { get; set; }
        public double GPA { get; set; }
        private double BursarBalance;

        /// <summary>
        /// Default constructor for the Student class.
        /// Sets all the instance variables to their default values.
        /// </summary>
        public Student()
        {
            SoonerID = 0;
            FirstName = "";
            LastName = "";
            IsOnProbation = false;
            GPA = 0.0;
            BursarBalance = 0.0;
        }

        /// <summary>
        /// Overloaded constructor for the Student class that accepts the Sooner ID, FirstName, LastName and BursarBalance
        /// </summary>
        /// <param name="id">SoonerID</param>
        /// <param name="fName">FirstName</param>
        /// <param name="lName">LastName</param>
        /// <param name="BursarBalance">BursarBalance</param>
        public Student(int id, string fName, string lName, double BursarBalance)
        {
            SoonerID = id;
            FirstName = fName;
            LastName = lName;
            this.BursarBalance = BursarBalance;
        }

        public void MakePayment(double amount)
        {
            if (amount > 0 && BursarBalance > amount)
            {
                //if (BursarBalance > 0)
                //{

                //}
                BursarBalance = BursarBalance - amount;
            }
        }

        public double CheckBalance()
        {
            return BursarBalance;
        }
    }
}
