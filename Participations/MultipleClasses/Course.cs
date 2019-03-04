using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleClasses
{
    class Course
    {
        public int CourseNumber { get; set; }
        public string CourseName{get;set;}
        public string Subject   {get;set;}
        public string Instructor { get; set; }


        public Course()
        {
            //Fill out default values
        }

        public override string ToString()
        {
            //Return a string in here that describes your course
            // for the user to see
            // DO NOT USE CONSOLE.WRITELINES !!!!!!!!!!!!!
        }
    }
}
