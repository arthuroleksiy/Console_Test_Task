using CodeHollow.FeedReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console__Test_Task_Oleksiy_Arthur.Controller
{
    public class DownloadFeed
    {
        public (string, Feed) Download(string name, string url)  
        {
            try
            {
                var urlsTask = FeedReader.GetFeedUrlsFromUrlAsync(url);
                var urls = urlsTask.Result;
                string feedUrl;
                if (urls == null || urls.Count() < 1)
                    feedUrl = url;
                else if (urls.Count() == 1)
                    feedUrl = urls.First().Url;
                else if (urls.Count() == 2)
                    feedUrl = urls.First().Url;
                else
                {
                    int i = 1;
                    Console.WriteLine("Found multiple feed, please choose:");
                    foreach (var feedurl in urls)
                    {
                        Console.WriteLine($"{i++.ToString()} - {feedurl.Title} - {feedurl.Url}");
                    }
                    var input = Console.ReadLine();

                    if (!int.TryParse(input, out int index) || index < 1 || index > urls.Count())
                    {
                        Console.WriteLine("Wrong input. Press key to exit");
                        Console.ReadKey();
                        return (name, Task.FromResult<Feed>(null).Result);
                    }
                    feedUrl = urls.ElementAt(index).Url;
                }
                return (name, FeedReader.ReadAsync(feedUrl).Result);
            }
            catch (Exception ex)
            {
                return (name, Task.FromResult<Feed>(null).Result);
            }
            
        }
    }
}
