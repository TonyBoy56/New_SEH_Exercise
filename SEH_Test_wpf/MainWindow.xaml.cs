using System.Net;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Web;
//using System.Drawing;
//using System.Drawing.Imaging;



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



            // The loop below will show returning images based on the user's search in the console //

            foreach (var item in jsonData.items)
            {
                Console.WriteLine(item.title);
                Console.WriteLine(item.link);
                Console.WriteLine(item.htmlSnippet);
            }

            // This is currently where my issues are. I'm encountering errors that parameters being passed to line 66 are not valid. //

            foreach (dynamic item in jsonData.items)
            {
                string url = item.link;
                // This is to show that I am actually storing item.link in a string var. All that's left is conversion to an image. //
                Console.WriteLine(url);

                // This is where my efforts in converting the string to an image begins. //

                var imgUrl = new Uri("http://images.google.com/hosted/life/3a92275521f486db.html");
                var imageData = new WebClient().DownloadData(imgUrl);
                var bitmapImage = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(imageData);
                bitmapImage.EndInit();

                Link.Source = bitmapImage;
                Title.Content = item.title;
                //Title.Content = item.link;
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