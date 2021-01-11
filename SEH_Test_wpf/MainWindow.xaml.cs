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
        }

        public int MaxLength { get; set; }
        public string Text { get; internal set; }

        //static async Task RunAsync()
        //{
        //    const string apiKey = "AIzaSyCyqAm432caVHD6ycUEWTbCNtg4rD_ao8Y";
        //    const string cx = "f45637bb92df9b998";
        //    const string query = "suits";
        //    var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + query);
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    Stream dataStream = response.GetResponseStream();
        //    StreamReader reader = new StreamReader(dataStream);
        //    string responseString = reader.ReadToEnd();
        //    dynamic jsonData = JsonConvert.DeserializeObject(responseString);
        //    Console.WriteLine(jsonData);

        //    foreach (var item in jsonData.items)
        //    {
        //        Console.WriteLine(item.title);
        //        Console.WriteLine(item.link);
        //        Console.WriteLine(item.htmlSnippet);
        //    }


        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MyLabel.Content = MyTextBox.Text;
            const string apiKey = "AIzaSyCyqAm432caVHD6ycUEWTbCNtg4rD_ao8Y";
            const string cx = "f45637bb92df9b998";
            string query = MyTextBox.Text;
            var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + query);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);
            Console.WriteLine(jsonData);

            foreach (var item in jsonData.items)
            {
                Console.WriteLine(item.title);
                Console.WriteLine(item.link);
                Console.WriteLine(item.htmlSnippet);
            }
        }

        public class ObjectList
        {
            public string kind { get; set; }
            public string title { get; set; }
            public string htmlTitle { get; set; }
            public string link { get; set; }
            public string displayLink { get; set; }
            public string snippet { get; set; }
            public string htmlSnippet { get; set; }
            public string cacheId { get; set; }
            public string formattedUrl { get; set; }
            public string htmlFormattedUrl { get; set; }
        }

        //public class RootObj
        //{
        //    public string objectType { get; set; }
        //    public List<Items> items { get; set; }
        //}
    }
}