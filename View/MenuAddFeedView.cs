using Console__Test_Task_Oleksiy_Arthur.Controller;
using Console__Test_Task_Oleksiy_Arthur.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Console__Test_Task_Oleksiy_Arthur.View
{
    public class MenuAddFeedView
    {
        public void AddFeedConsole()
        {
            string inputFeed;
            string inputUrl;
            try
            {
                AddFeedController addFeed = new AddFeedController();
                Console.WriteLine("Enter feeds name to be added (0 to cancel): ");

                inputFeed = Console.ReadLine(); 
                if (Int32.TryParse(inputFeed, out int feedChoise) && feedChoise == 0)
                {
                    MainView.MainMenu();

                }
                ReturnToMainMenu(inputFeed);

                Console.WriteLine("Enter feeds url (0 to cancel): ");

                inputUrl = Console.ReadLine();
                if (Int32.TryParse(inputUrl, out int inputUrlInt) && inputUrlInt == 0)
                {
                    MainView.MainMenu();

                }
                if (!Regex.IsMatch(inputUrl, Patterns.urlPattern))
                    throw new Exception();

                ReturnToMainMenu(inputUrl);

                var result = addFeed.AddFeed(inputFeed, inputUrl);

                if (!result)
                    Console.WriteLine($"The feed {result} hasn't been added");

                Console.WriteLine($"The feed {result} has been added");

                MainView.MainMenu();
            }
            catch
            {
                Console.WriteLine("Error occured");
                MainView.MainMenu();
            }
        }

            private void ReturnToMainMenu(string inputFeed)
            {

                if (inputFeed.Equals("0"))
                    MainView.MainMenu();
            }
        

        
    }
}
