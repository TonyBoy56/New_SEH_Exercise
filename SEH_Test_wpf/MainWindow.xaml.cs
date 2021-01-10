using System.Net;
using System.Windows;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;


namespace SEH_Test_wpf.MainWindowControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            // The below code shows in the console
            Console.WriteLine("This is a test");
        }

        public string Title { get; set; }
        public int MaxLength { get; set; }
        public string Text { get; internal set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyLabel.Content = MyTextBox.Text;
        }
    }
}