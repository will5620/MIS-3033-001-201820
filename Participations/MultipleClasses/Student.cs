﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleClasses
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName {get;set;}
        public int StudentID   {get;set;}
        public List<Course> Courses    {get;}

        public Student()
        {
            //fill out normal default values
            Courses = new List<Course>();//create our new List
        }
    }
}
