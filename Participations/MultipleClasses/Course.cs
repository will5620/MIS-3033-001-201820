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
            CourseNumber = 0;
            CourseName = string.Empty;
            Subject    = string.Empty;
            Instructor = string.Empty;
        }

        public override string ToString()
        {
            //Return a string in here that describes your course
            // for the user to see
            // DO NOT USE CONSOLE.WRITELINES !!!!!!!!!!!!!
            return $"{CourseName} ({Subject}-{CourseNumber}) taught by {Instructor}";
        }
    }
}
