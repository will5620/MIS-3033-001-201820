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

namespace WPF___Files
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

        private void BtnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            var result = dlg.ShowDialog();

            txtFilePath.Text = dlg.FileName;
        }

        private void BtnReadFile_Click(object sender, RoutedEventArgs e)
        {

            if (File.Exists(txtFilePath.Text) == true)
            {
                var lines = File.ReadAllLines(txtFilePath.Text);
                var columnNames = lines[0].Split(',');
                foreach (var line in lines)
                {
                    txtOutput.Text += line + "\n";
                }
            }
        }
    }
}
