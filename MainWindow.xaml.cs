using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WriteFileNames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WriteFileNames(FilesDir.Text, DestinationDir.Text);
        }

        private static void WriteFileNames(string from, string to)
        {
            try
            {
                string[] fullFileNames = Directory.GetFiles(@from, "*");
                Console.WriteLine("The number of files is {0}.", fullFileNames.Length);
                List<String> fileNames = new List<String>();

                foreach (string fullFileName in fullFileNames)
                {
                    fileNames.Add(System.IO.Path.GetFileNameWithoutExtension(fullFileName));
                }

                if (fileNames.Count() > 0)
                {
                    System.IO.File.WriteAllLines(@to, fileNames);
                }
                MessageBox.Show("File names successfully copied", "OK");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                MessageBox.Show("Failed to copy. Please check the path and try again", "OK");
            }
        }
    }
}
