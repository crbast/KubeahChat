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
namespace KChat.Methods
{
    /// <summary>
    /// Class containing the version information of the application
    /// </summary>
    class AppInfo
    {
        protected const string sStringformattedVersion = "1.7.2.0";
        protected const long lLongFormattedVersion = 001007002000000; //1.2.3.4 ===> 001002003000004


        /// <summary>
        /// Returns the version in a string.
        /// </summary>
        /// <returns>String : Example "1.7.0.0"</returns>
        public string GetFormattedVersion() => sStringformattedVersion;
        /// <summary>
        /// Returns the version in a int.
        /// </summary>
        /// <returns>Int : Example 001007000000000 (1.2.3.4 ===> 001002003000004)</returns>
        public long GetChainFormattedVersion() => lLongFormattedVersion;
    }

}
