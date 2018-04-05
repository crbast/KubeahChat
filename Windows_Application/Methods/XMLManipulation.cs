using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace KChat.Methods
{
    class XMLManipulation
    {
        public static string ReturnValue(string AttributesName)
        {
            if (File.Exists("./App.config") == false)
            {
                CreateAppConfig();
            }
            string resultToReturn = "";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("./App.config");

            foreach (XmlNode xmlNode in xmlDoc.DocumentElement)
            {
                if (xmlNode.Attributes["name"].Value == AttributesName)
                {
                     resultToReturn = xmlNode.Attributes["value"].Value.ToString();
                }
            }
            return resultToReturn;
        }
        private static void CreateAppConfig()
        {
            XmlWriter xmlWriter = XmlWriter.Create("./App.config");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("param");
            xmlWriter.WriteStartElement("param");
            xmlWriter.WriteAttributeString("name", "EnableLastIpConnexion");
            xmlWriter.WriteAttributeString("value", "ON");
            xmlWriter.WriteAttributeString("info", "Not used yet");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("param");
            xmlWriter.WriteAttributeString("name", "SaveDiscussion");
            xmlWriter.WriteAttributeString("value", "ON");
            xmlWriter.WriteAttributeString("info", "Not used yet");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("param");
            xmlWriter.WriteAttributeString("name", "LastIpConnexion");
            xmlWriter.WriteAttributeString("value", "");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("param");
            xmlWriter.WriteAttributeString("name", "FocusActivate");
            xmlWriter.WriteAttributeString("value", "ON");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("./App.config");
            xmlDoc.Save("./App.config");
        }

        public static void ModifyElementXML(string name, string newValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("./App.config");

            foreach (XmlNode xmlNode in xmlDoc.DocumentElement)
            {
                if (xmlNode.Attributes["name"].Value == name)
                {
                    xmlNode.Attributes["value"].Value = newValue;
                }
            }
            xmlDoc.Save("./App.config");
        }
    }
}
