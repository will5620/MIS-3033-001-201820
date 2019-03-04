using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultipleClasses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();
            var x = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Student.csv");
            string downloadsDirectory = @"‪C:\Users\acke9387\Downloads";
            string studentFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Student.csv");
            string courseFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Course.csv");

            if (File.Exists(studentFile) == false || File.Exists(courseFile) == false)
            {
                MessageBox.Show("Please put the Student.csv and Course.csv file in your " + downloadsDirectory);
                Close();
            }
            else
            {
                var courses = File.ReadAllLines(courseFile);

                for (int i = 1; i < courses.Length; i++)
                {
                    var course = courses[i].Split(',');//"1,3033,Programming 2,MIS,Ackerman"
                    Course c = new Course();
                    c.CourseNumber = Convert.ToInt32(course[1]);
                    c.CourseName = course[2];
                    c.Subject = course[3];
                    c.Instructor = course[4];
                    lstCourses.Items.Add(c);
                }

            }
        }
    }
}
