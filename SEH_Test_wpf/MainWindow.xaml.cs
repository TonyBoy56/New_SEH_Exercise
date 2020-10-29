using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;


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
            // Logging "query" to ensure input is stored
            System.Diagnostics.Debug.WriteLine(query);
        }

        string query;

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            query = userInput.Text;
        }

        private void MainWindowUserControls_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}