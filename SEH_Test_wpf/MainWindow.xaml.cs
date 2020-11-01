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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyLabel.Content = MyTextBox.Text;
        }
    }
}