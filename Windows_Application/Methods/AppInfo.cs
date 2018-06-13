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
    class AppInfo
    {
        protected const string sStringformattedVersion = "1.7.0.0";
        protected const long lLongFormattedVersion = 001007000000000; //1.2.3.4 ===> 001002003000004

        public string GetFormattedVersion() => sStringformattedVersion;
        public long GetChainFormattedVersion() => lLongFormattedVersion;
    }

}
