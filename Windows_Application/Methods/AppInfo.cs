//--------------------------------------------------------------------
//  Kubeah ! Open Source Project
//  
//  Kubeah Chat
//  Just like Open Source
//--------------------------------------------------------------------
namespace KChat.Methods
{
    class AppInfo
    {
        private string sStringformattedVersion = "1.6.0.0";
        private long lLongFormattedVersion = 001006000000000;

        public string GetFormattedVersion() => sStringformattedVersion;
        public long GetChainFormattedVersion() => lLongFormattedVersion;
    }

}
