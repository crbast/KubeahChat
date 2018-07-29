/*
 * Kubeah ! Open Source Project
 * 
 * Kubeah Chat
 * Just like Open Source
 * 
 * for more informations about Kubeah Chat
 * Please visit https://github.com/CrBast/KubeahChat
 * 
 * APPLICATION LICENSE
 * GNU General Public License v3.0
 * https://github.com/CrBast/KubeahChat/blob/master/LICENSE
 * */
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
            xmlWriter.WriteAttributeString("choice", "ON - OFF");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("param");
            xmlWriter.WriteAttributeString("name", "SaveDiscussion");
            xmlWriter.WriteAttributeString("value", "ON");
            xmlWriter.WriteAttributeString("choice", "ON - OFF");
            xmlWriter.WriteAttributeString("info", "Not used yet");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("param");
            xmlWriter.WriteAttributeString("name", "LastIpConnexion");
            xmlWriter.WriteAttributeString("value", "");
            xmlWriter.WriteAttributeString("choice", "Example : 192.168.0.2");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("param");
            xmlWriter.WriteAttributeString("name", "FocusActivate");
            xmlWriter.WriteAttributeString("value", "ON");
            xmlWriter.WriteAttributeString("choice", "ON - OFF");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("param");
            xmlWriter.WriteAttributeString("name", "NotificationsEnable");
            xmlWriter.WriteAttributeString("value", "ON");
            xmlWriter.WriteAttributeString("choice", "ON - OFF");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("./App.config");
            xmlDoc.Save("./App.config");
        }

        public static void ModifyElementXML(string name, string newValue)
        {
            if (File.Exists("./App.config") == false)
            {
                CreateAppConfig();
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("./App.config");

            bool verificationParameter = false;
            /* true : The parameter has been entered
             * false : The parameter has not been entered because it does not exist
             * */

            foreach (XmlNode xmlNode in xmlDoc.DocumentElement)
            {
                if (xmlNode.Attributes["name"].Value == name)
                {
                    xmlNode.Attributes["value"].Value = newValue;
                    verificationParameter = true;
                }
            }
            if(verificationParameter == false)
            {
                // TODO : create parameter and give the value 
            }
            xmlDoc.Save("./App.config");
        }
        public static void CreateNotifFile(string content)
        {
            try
            {
                string title = DateTime.Now.ToString("dd/MM/yyyy_HH:mm:ss");
                XmlWriter xmlWriter = XmlWriter.Create($"./App/notifications/{title}.xml");
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("param");
                xmlWriter.WriteStartElement("param");
                xmlWriter.WriteAttributeString("name", "content");
                xmlWriter.WriteAttributeString("value", $"{content}");
                xmlWriter.WriteEndElement();
                xmlWriter.Close();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load($"./App/notifications/{title}.xml");
                xmlDoc.Save($"./App/notifications/{title}.xml");
            }
            catch { }
            
        }
    }
}
