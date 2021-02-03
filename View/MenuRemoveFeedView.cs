using Console__Test_Task_Oleksiy_Arthur.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace Console__Test_Task_Oleksiy_Arthur.View
{
    public class MenuRemoveFeedView
    {

        public void RemoveFeedConsole()
        {
            string inputFeed;
            try
            {
                RemoveFeed removeFeed = new RemoveFeed();
                Console.WriteLine("Enter feeds name to be removed (0 to cancel): ");

                inputFeed = Console.ReadLine(); 
                if (Int32.TryParse(inputFeed, out int feedChoise) && feedChoise == 0)
                {
                    MainView.MainMenu();

                }
                var result = removeFeed.Remove(inputFeed);

                if(!result)
                    Console.WriteLine($"The feed {result} hasn't been removed");

                Console.WriteLine($"The feed {result} has been removed");

                MainView.MainMenu();
            } 
            catch (Exception)
            {
                Console.WriteLine("Error occured");
                MainView.MainMenu();
            }
        }
    }
}
