using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KChat.Objects
{
    // To complete
    class KLogs
    {

        private void Write(string type, string content)
        {
            /*
             One line structure <date> | <type>     <content>

                example 01.01.2019 - 21:20:20 | Error       Recipient is not active ...
             */
            string line = DateTime.Now.ToString("dd.MM.yyyy - hh:mm:ss");
            if(type == "warning")
                line += $" | {type} \t {content}";
            else
                line += $" | {type} \t\t {content}";
            File.AppendAllText(logPath, line + Environment.NewLine);
        }

        public void WriteError(string message) => Write("error", message);

        public void WriteWarning(string message) => Write("warning", message);

        public void WriteInfo(string message) => Write("info", message);
    }
}
