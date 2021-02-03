using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Linq;
using Console__Test_Task_Oleksiy_Arthur.Model;

namespace Console__Test_Task_Oleksiy_Arthur.Controller
{
    public class RemoveFeed
    {
        

        public bool Remove(string ValueToRemove)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(Directories.AssemblyDirectory);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();
                XmlElement root = doc.DocumentElement;

                XmlNodeList nodes = doc.SelectNodes($"//{ValueToRemove}");
                for (int i = nodes.Count - 1; i >= 0; i--)
                {
                    nodes[i].ParentNode.RemoveChild(nodes[i]);
                }

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
