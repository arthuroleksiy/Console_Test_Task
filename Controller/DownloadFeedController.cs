using CodeHollow.FeedReader;
using Console__Test_Task_Oleksiy_Arthur.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace Console__Test_Task_Oleksiy_Arthur.Controller
{
    public class DownloadFeedController
    {

        Dictionary<string, Feed> feedNameNews = new Dictionary<string, Feed>();

        Dictionary<string, string> feedUrlDictionnary = new Dictionary<string, string>();
        

        public Dictionary<string, Feed> DownloadAllFeeds(Dictionary<string, string> feeds)
        {

            List<string> keysList = new List<string>();
            DownloadFeed downloadFeed = new DownloadFeed();
            var allFeeds = feeds; 
            var keys = allFeeds.Keys;


            foreach (string key in keys)
            {
                keysList.Add(key);
            }
            Task<(string, Feed)>[] tasks = new Task<(string, Feed)>[keysList.Count];

            int j = 0;
            foreach (var i in keysList)
            {
                tasks[j++] = Task<(string, Feed)>.Run(() => downloadFeed.Download(i, allFeeds[i]));
            }

            Task.WaitAll(tasks);
            for (int i = 0; i < keysList.Count; i++)
            {
                feedNameNews.Add(tasks[i].Result.Item1, tasks[i].Result.Item2);
            }

            return feedNameNews;
        }

        public Dictionary<string, Feed> DownloadSpecificFeed(string feed, Dictionary<string, string> feeds)
        {

            List<string> keysList = new List<string>();
            DownloadFeed downloadFeed = new DownloadFeed();
            var allFeeds = feeds;
            var keys = allFeeds.Keys;

            foreach (string key in keys)
            {
                keysList.Add(key);
            }

            if (keysList.Contains(feed))
            {
                Task<(string, Feed)> tasks = Task<(string, Feed)>.Run(() => downloadFeed.Download(feed, allFeeds[feed]));
                
                feedNameNews.Add(tasks.Result.Item1, tasks.Result.Item2);
                

                return feedNameNews;
            }

            return feedNameNews;
        }
        public Dictionary<string, string> ReadAllFeeds()
        {

            XmlTextReader reader = new XmlTextReader(Directories.AssemblyDirectory);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.ChildNodes;
            
            foreach(XmlNode n in nodes)
            {
                feedUrlDictionnary.Add(n.Name,n.InnerText);
            }

            return feedUrlDictionnary;
        }

    }
}
