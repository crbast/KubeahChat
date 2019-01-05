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
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace KChat.Methods
{
    /// <summary>
    /// IP handling class
    /// </summary>
    class Ip
    {
        /// <summary>
        /// Get the host name using the ip.
        /// </summary>
        /// <param name="ipAdress">Host ip</param>
        /// <returns>String : Host name</returns>
        public static string GetHostName(string ipAdress)
        {
            string machineName = string.Empty;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAdress);
                machineName = hostEntry.HostName;
            }
            catch { }
            return machineName;
        }

        /// <summary>
        /// Ping host
        /// </summary>
        /// <param name="sIpAdress">Host ip</param>
        /// <returns>Boolean : true(OK) | false(NOT OK)</returns>
        public static async Task<bool> PingDest(string sIpAdress)
        {
            Ping ping = new Ping();
            PingReply pingresult = ping.Send(sIpAdress, 60);
            if (pingresult.Status.ToString() == "Success")
                return true;
            else
                return false;

        }
    }
}