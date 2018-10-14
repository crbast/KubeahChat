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
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using KChat.Objects;

namespace KChat.Objects
{
    /// <summary>
    /// Create Message object
    /// Example message : string json = @"{""Type"":""0"",""Content"":""HEY""}"
    /// </summary>
    public class KMessage
    {
        /*  Example for test :
         *  
         *  string json = @"{""Type"":""0"",""Content"":""HEY""}";
         *  KMessage msg = new KMessage(json);
         *  string temp = msg.ReadyToSend();
         *  KMessage msg2 = new KMessage(temp);
         *  MessageBox.Show(msg2.GetMessageContent());
         */  

        private Dictionary<string, string> messageDict = new Dictionary<string, string>();

        /// <summary>
        /// Creates a new message from a string.
        /// To be used only when receiving a message
        /// </summary>
        /// <param name="global">String reception -> JSON Format</param>
        public KMessage(string global)
        {
            messageDict = JObject.Parse(global).ToObject<Dictionary<string, string>>();
        }

        /// <summary>
        /// Create a new message object. 
        /// To be used only for send this message
        /// </summary>
        /// <param name="content"></param>
        /// <param name="type"></param>
        public KMessage(string content, int type)
        {
            messageDict.Add("Content", content);
            messageDict.Add("Type", type.ToString());
        }

        /// <summary>
        /// Preparation of the message for the string sending
        /// </summary>
        /// <returns>String result</returns>
        public string ReadyToSend() => JObject.FromObject(messageDict).ToString();

        /// <summary>
        /// Return content of message
        /// </summary>
        /// <returns>Content</returns>
        public string GetMessageContent() => messageDict["Content"].ToString();

        /// <summary>
        /// Return type of message
        /// </summary>
        /// <returns>Type</returns>
        public string GetMessageType() => messageDict["Type"].ToString();

        /// <summary>
        /// Return Type of message. Type : Initialization
        /// </summary>
        /// <returns>Type (int)</returns>
        public static int TypeInit() => 1;
        /// <summary>
        /// Return Type of message. Type : Message
        /// </summary>
        /// <returns>Type (int)</returns>
        public static int TypeMsg() => 0;
    }
}
