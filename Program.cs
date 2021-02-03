using CodeHollow.FeedReader;
using Console__Test_Task_Oleksiy_Arthur.View;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.XPath;

namespace Console__Test_Task_Oleksiy_Arthur
{
    class Program
    {
        static void Main(string[] args)
        {
            //MainView mainMenu = new MainView();
            // mainMenu.MainMenu();
            MainView.MainMenu();

        }

        

        

        /*private static string ReadValueFromXML(string pstrValueToRead)
        {
                //settingsFilePath is a string variable storing the path of the settings file 
                XPathDocument doc = new XPathDocument(AssemblyDirectory + "\\Data.config");
                XPathNavigator nav = doc.CreateNavigator();
                // Compile a standard XPath expression
                XPathExpression expr;
                expr = nav.Compile(@"/configuration/" + pstrValueToRead);
                XPathNodeIterator iterator = nav.Select(expr);
                // Iterate on the node set
                while (iterator.MoveNext())
                {
                    return iterator.Current.Value;
                }
                return string.Empty;
        }*/
        

    }
}
