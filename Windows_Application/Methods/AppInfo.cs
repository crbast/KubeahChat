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
        protected string sStringformattedVersion = "1.7.0.0";
        protected long lLongFormattedVersion = 001007000000000; //1.2.3.4 ===> 001002003000004

        public string GetFormattedVersion() => sStringformattedVersion;
        public long GetChainFormattedVersion() => lLongFormattedVersion;
    }

}
