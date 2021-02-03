using CodeHollow.FeedReader;
using Console__Test_Task_Oleksiy_Arthur.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console__Test_Task_Oleksiy_Arthur.View
{
    public class DownloadFeedView
    {
        public void DownloadFeedConsole()
        {
            List<string> keysList = new List<string>();
            List<string> resultList = new List<string>();
            string inputFeed;
            try
            {
                DownloadFeedController downloadFeedController = new DownloadFeedController();
                var allFeeds = downloadFeedController.ReadAllFeeds();
                var allKeys = allFeeds.Keys;
                foreach (string key in allKeys)
                {
                    keysList.Add(key);
                }

                Console.WriteLine("How to download feed\n1.All feeds\n2.Specific feed");
                string choise = Console.ReadLine();
                if (Int32.TryParse(choise, out int feedChoise) && feedChoise == 0)
                {
                    MainView.MainMenu();

                }
                else if(feedChoise == 1)
                {
                    AllFeeds(downloadFeedController, resultList, allFeeds);
                }
                else if (feedChoise == 2)
                {
                    Console.WriteLine("Enter feeds name to be downloaded (0 to cancel): ");
                    inputFeed = Console.ReadLine();
                    if (Int32.TryParse(inputFeed, out int inputFeedInt) && inputFeedInt == 0)
                    {

                        MainView.MainMenu();
                    }
                    else if (String.IsNullOrWhiteSpace(inputFeed) || String.IsNullOrEmpty(inputFeed))
                    {
                        AllFeeds(downloadFeedController, resultList, allFeeds);
                    }
                    else if (keysList.Contains(inputFeed))
                    {
                        OneFeed(downloadFeedController, inputFeed, allFeeds);
                    } 
                }
                else
                {
                    Console.WriteLine("There are no such field");
                }
                Console.ReadLine();
                MainView.MainMenu();
            }
            catch (Exception)
            {
                Console.WriteLine("Error occured");
                MainView.MainMenu();
            }
        }

        public void OneFeed(DownloadFeedController downloadFeedController, string inputFeed, Dictionary<string, string> allFeeds)
        {
            var result = downloadFeedController.DownloadSpecificFeed(inputFeed, allFeeds);
            Output(result, inputFeed);
        }

        public void AllFeeds(DownloadFeedController downloadFeedController, List<string> resultList, Dictionary<string, string> allFeeds)
        {
            var result = downloadFeedController.DownloadAllFeeds(allFeeds);
            var keys = result.Keys;

            foreach (string key in keys)
            {
                resultList.Add(key);
            }
            Output(result, resultList);
        }
        public void Output(Dictionary<string, Feed> result, List<string> keys)
        {
            foreach (string key in keys)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(key);
                Console.WriteLine("-----------------------------------------------");
                if (result[key] != null)
                {
                    foreach (var item in result[key].Items)
                    {
                        Console.WriteLine(item.Title);
                    }
                }
                else
                {

                    Console.WriteLine("There are no news on this resource");
                }

            }
        }

        public void Output(Dictionary<string, Feed> result, string key)
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine(key);
            Console.WriteLine("-----------------------------------------------");
            if (result[key] != null)
            {
                foreach (var item in result[key].Items)
                {
                    Console.WriteLine(item.Title);
                }
            }
            else
            {

                Console.WriteLine("There are no news on this resource");
            }
        }
    }
}
