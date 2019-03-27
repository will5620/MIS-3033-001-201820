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

namespace CustomerInputData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnDoSomething_Click(object sender, RoutedEventArgs e)
        {
            DB_128040_practiceEntities db = new DB_128040_practiceEntities();

            //string path = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads";
            //var jsonFile = System.IO.Path.Combine(path, "MOCK_DATA.json");

            ////var jsonFile = @"C:\Users\acke9387\Downloads\MOCK_DATA.json";

            //var contents = File.ReadAllText(jsonFile);

            //var custs = JsonConvert.DeserializeObject<List<Customer>>(contents);

            //db.Customers.AddRange(custs);
            //db.SaveChanges();

            //MessageBox.Show("Hoooray");

            //var g = db.Customers.Where(x => x.CustomerID == 1);
            //var custWithID1 = db.Customers.Find(1);//find for PK's

            var cust = db.Customers.Where(x => x.State == "California").OrderBy(x => x.LastName);

            MessageBox.Show($"There are {cust.Count()} customers in California.");
            //List<Customer> q = new List<Customer>();
            //foreach (var x in db.Customers)
            //{
            //    if (x.CustomerID == 1)
            //    {
            //        q.Add(x);
            //    }
            //}
        }
    }
}
