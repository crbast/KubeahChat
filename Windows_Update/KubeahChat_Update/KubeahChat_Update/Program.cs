using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubeahChat_Update
{
    class Program
    {
        static void Main(string[] args)
        {
            bool updateState = true;
            string OnlineUpdateInformation = "";
            System.Net.WebClient webClientKubeah = new System.Net.WebClient();
            string forceManuallyUpdate = "";

            try
            {
                forceManuallyUpdate = webClientKubeah.DownloadString("http://kubeah.com/kchat/ForceDownloadManually.config");
            }
            catch
            {
                Console.WriteLine("No connection to internet");
            }
            if (forceManuallyUpdate == "false")
            {
                try
                {
                    OnlineUpdateInformation = webClientKubeah.DownloadString("http://kubeah.com/kchat/Update_Information.onlineconfig");
                    
                }
                catch
                {
                    Console.Read();
                }
                List<string> listToDownload = new List<string>();
                foreach (string fileName in OnlineUpdateInformation.Split(";".ToCharArray()))
                {
                    listToDownload.Add(fileName);
                }
                listToDownload.RemoveAt(listToDownload.Count() - 1);
                foreach (string temp in listToDownload)
                {
                    try
                    {
                        webClientKubeah.DownloadFile($"https://kubeah.com/kchat/Update_App/{temp}", temp);
                        Console.WriteLine($"download : {temp}   ================>   OK");
                    }
                    catch
                    {
                        Console.WriteLine($"download : {temp}   ================>   FAIL");
                        updateState = false; 
                    }
                    
                }
                if (updateState == true)
                {
                    Console.WriteLine("\r\nThe new version is correctly installing");
                }
                else
                {
                    Console.WriteLine("\r\nAn error occurred please restart the update");
                }
                Console.Read();
            }
            else
            {
                Console.WriteLine("You need to install manually the new version of application");
                Console.WriteLine("Please go to \"https://sourceforge.net/projects/kubeah-chat/\"");
                Console.Read();
            }
        }
    }
}
