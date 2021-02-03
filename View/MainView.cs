using System;
using System.Collections.Generic;
using System.Text;

namespace Console__Test_Task_Oleksiy_Arthur.View
{
    public class MainView
    {
        string[] MenuChoises;
        
        public static void MainMenu()
        {
            int choise  = 0;
            while(choise != 4)
            {
                
                Console.WriteLine("Select options:\n1. Add feed;\n2. Remove feed;\n3. Download feed;\n4. Exit.");
                try
                {
                    string usersChoise = Console.ReadLine();
                    if(Int32.TryParse(usersChoise, out int ch) && ch > 0 && ch <= 4)
                    {
                        switch(ch)
                        {
                            case 1:
                                MenuAddFeedView menuAddFeedView = new MenuAddFeedView();
                                menuAddFeedView.AddFeedConsole();
                                break;
                            case 2:
                                MenuRemoveFeedView menuRemoveFeedView = new MenuRemoveFeedView();
                                menuRemoveFeedView.RemoveFeedConsole();
                                break;
                            case 3:
                                DownloadFeedView downloadFeedView = new DownloadFeedView();
                                downloadFeedView.DownloadFeedConsole();
                                break;
                            case 4:
                                Environment.Exit(1);
                                break;

                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong choise");
                    MainMenu();

                }
            }

        }
    }
}
