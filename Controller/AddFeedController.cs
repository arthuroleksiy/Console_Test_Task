using Console__Test_Task_Oleksiy_Arthur.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Console__Test_Task_Oleksiy_Arthur.Controller
{
    class AddFeedController
    {
        

        public bool AddFeed(string nodeToWrite, string urlToWrite)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(Directories.AssemblyDirectory);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();
                XmlElement root = doc.DocumentElement;
                XmlNode node = doc.CreateNode(XmlNodeType.Element, nodeToWrite, null);
                node.InnerText += urlToWrite;
                doc.DocumentElement.AppendChild(node);
                doc.Save(Directories.AssemblyDirectory);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
