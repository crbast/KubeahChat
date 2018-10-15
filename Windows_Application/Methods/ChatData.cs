using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            List<string> verificationEmptyLine = new List<string>();
            string result = "";
            try
            {
                verificationEmptyLine = content.Split("\r\n".ToCharArray()).ToList(); 
                verificationEmptyLine.RemoveAll(string.IsNullOrWhiteSpace);//Delete empty line

                // Convert list verificationEmptyLine to string result
                foreach (var item in verificationEmptyLine)
                    result += $"{item.ToString()}\r\n";

                if (!Directory.Exists("./Discussions"))
                    Directory.CreateDirectory("./Discussions");
                string path = $"./Discussions/{ipRecipient}.chat";
                if (!File.Exists(path))
                {
                    var myFile = File.Create(path);
                    myFile.Close();
                }
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(result);
                tw.Close();
            }
            catch { }
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
                result.RemoveAll(string.IsNullOrWhiteSpace);//Delete empty line
                return result;
            }
            return result;
        }
    }
}
