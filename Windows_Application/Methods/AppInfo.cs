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
        protected string sStringformattedVersion = "1.6.1.0";
        protected long lLongFormattedVersion = 001006001000000; //1.2.3.4 ===> 001002003000004

        public string GetFormattedVersion() => sStringformattedVersion;
        public long GetChainFormattedVersion() => lLongFormattedVersion;
    }

}
