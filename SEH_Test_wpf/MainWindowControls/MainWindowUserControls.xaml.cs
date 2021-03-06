﻿using System.Net;
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
    /// Interaction logic for MainWindowUserControls.xaml
    /// </summary>
    public partial class MainWindowUserControls : UserControl
    {
        public MainWindowUserControls()
        {
            InitializeComponent();
            this.DataContext = this;
            //RunAsync();
            // I am rate limited, but the console log below would show in the output a parsed json object based on the user's query //
            //System.Diagnostics.Debug.WriteLine(RunAsync());
            // This is to show that if I was not rate limited, user query results would show in the output as the test statement does //
        }

        public string Title { get; set; }
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

        //    //var results = new List<Result>();
        //    //foreach (var item in jsonData)
        //    //{
        //    //    Console.WriteLine(
        //    //        item.title,
        //    //        item.link,
        //    //        item.cacheId);
        //    //}
        //}

        public class Result
        {
            public string Link { get; set; }
            public string CachedId { get; set; }
        }
    }
}