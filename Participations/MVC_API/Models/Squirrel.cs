using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class Squirrel
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public double Weight { get; set; }

        public double Speed { get; set; }

        public string FavoriteColor { get; set; }

        public string Image { get; set; }

        public Student Stud { get; set; }

    }
}