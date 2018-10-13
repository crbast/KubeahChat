using System;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine("Kubeah! Open Source\r\nKubeah Chat Update\r\nPlease visit \"https://sourceforge.net/projects/kubeah-chat/\"\r\n\r\nStarting update");
            try
            {
                forceManuallyUpdate = webClientKubeah.DownloadString("https://kubeah.com/kchat/ForceDownloadManually.config");
            }
            catch
            {
                Console.WriteLine("No connection to internet");
            }
            if (forceManuallyUpdate == "false")
            {
                try
                {
                    OnlineUpdateInformation = webClientKubeah.DownloadString("https://kubeah.com/kchat/Update_Information.onlineconfig");
                    
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
                        if (temp.Contains("/"))
                        {
                            if (!temp.Contains("."))
                                Directory.CreateDirectory($"./{temp}");
                            else
                            {
                                List<string> seperation = new List<string>();
                                seperation = temp.Split("/".ToCharArray()).ToList();
                                string localFolder = "./";

                                for (int i = 0; i < seperation.Count() - 1; i++)
                                {
                                    localFolder = seperation[i];
                                }
                                if(!Directory.Exists(localFolder))
                                    Directory.CreateDirectory(localFolder);
                                webClientKubeah.DownloadFile($"https://kubeah.com/kchat/Update_App/{temp}", $"./{temp}");
                            }
                        }
                        else
                            webClientKubeah.DownloadFile($"https://kubeah.com/kchat/Update_App/{temp}", temp);

                        Console.WriteLine($"download : {temp}\t\t   ================>   OK");
                    }
                    catch
                    {
                        Console.WriteLine($"download : {temp}   ================>   FAIL");
                        updateState = false; 
                    }
                    
                }
                if (updateState == true)
                {
                    Console.WriteLine("\r\nThe new version has been installed");
                }
                else
                {
                    Console.WriteLine("\r\nAn error occurred. Please restart the update or download manually the application.");
                }
                Console.Read();
                System.Diagnostics.Process.Start("https://sourceforge.net/projects/kubeah-chat/");
            }
            else
            {
                Console.WriteLine("\r\nYou need to install manually the new version of the application");
                Console.WriteLine("Please go to \"https://sourceforge.net/projects/kubeah-chat/\"");
                Console.Read();
                System.Diagnostics.Process.Start("https://sourceforge.net/projects/kubeah-chat/");
            }
        }
    }
}
