using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KChat.Methods
{
    /// <summary>
    /// Import and export discussion.
    /// This is useful for loading a discussion.
    /// </summary>
    class ChatData
    {
        /// <summary>
        /// Export discussion to file.
        /// </summary>
        /// <param name="ipRecipient">(string) ip of recipient</param>
        /// <param name="content">(string) content of discussion</param>
        public static void Export(string ipRecipient, string content)
        {
            if (!Directory.Exists("./Discussions"))
                Directory.CreateDirectory("./Discussions");
            string path = $"./Discussions/{ipRecipient}.chat";
            if (!File.Exists(path))
                File.Create(path);
            TextWriter tw = new StreamWriter(path);
            tw.WriteLine(content);
            tw.Close();
        }

        /// <summary>
        /// Import discussion. Depends on the recipient's ip
        /// </summary>
        /// <param name="ipRecipient">(string) ip of recipient</param>
        /// <returns></returns>
        public static List<string> Import(string ipRecipient)
        {
            List<string> result = new List<string>();
            string path = $"./Discussions/{ipRecipient}.chat";
            if (File.Exists(path))
            {
                string contentFile = File.ReadAllText(path);
                result = contentFile.Split("\n".ToCharArray()).ToList();
                return result;
            }
            return result;
        }
    }
}
