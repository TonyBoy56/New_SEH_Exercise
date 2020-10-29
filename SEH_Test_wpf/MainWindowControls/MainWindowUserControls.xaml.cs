using System;
using System.Net;
using System.IO;
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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using SEH_Test_wpf;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using System.Net;
using Newtonsoft.Json;

namespace SEH_Test_wpf.MainWindowControls
{
    /// <summary>
    /// Interaction logic for MainWindowUserControls.xaml
    /// </summary>
    public partial class MainWindowUserControls : UserControl
    {
        public MainWindowUserControls()
        {
            InitializeComponent();
            this.DataContext = this;
            RunAsync();
            // I am rate limited, but the console log below would show in the output a parsed json object based on the user's query //
            System.Diagnostics.Debug.WriteLine(RunAsync());
            // This is to show that if I was not rate limited, user query results would show in the output as the test statement does //
            System.Diagnostics.Debug.WriteLine("Test");
        }

        public string Title { get; set; }
        public int MaxLength { get; set; }

        static async Task RunAsync()
        {
            const string apiKey = "AIzaSyCyqAm432caVHD6ycUEWTbCNtg4rD_ao8Y";
            const string cx = "f45637bb92df9b998";
            const string query = "suits";
            var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + query);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);

            var results = new List<Result>();
            foreach (var item in jsonData.items)
            {
                results.Add(new Result
                {
                    Title = item.title,
                    Link = item.link,
                });
            }
        }

        public class Result
        {
            public string Title { get; set; }
            public string Link { get; set; }
        }
    }
}