//--------------------------------------------------------------------
//  Kubeah ! Open Source Project
//  
//  Kubeah Chat
//  Just like Open Source
//--------------------------------------------------------------------
using System.Net;
using System.Net.NetworkInformation;

namespace KChat.Methods
{
    class Ip
    {
        //Function NAMEMACHINTEWITHIP========================================================================================/
        //===================================================================================================================/
        //Return : Detinataire Name
        public static string NameMachineWithIP(string ipAdress)
        {
            string machineName = string.Empty;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAdress);
                machineName = hostEntry.HostName;
            }
            catch
            {
                //MessageBox.Show("Destinataire introuvable");
            }
            return machineName;
        }

        //FUNCTION PING====================================================================================================/
        //=====================================================================================================================/
        //Ping with ip
        public static bool PingDest(string sIpAdress)
        {
            Ping ping = new Ping();
            PingReply pingresult = ping.Send(sIpAdress, 60);
            if (pingresult.Status.ToString() == "Success")
            {
                bool bResult = true;
                return bResult;
            }
            else
            {
                bool bResult = false;
                return bResult;
            }
        }
    }
}