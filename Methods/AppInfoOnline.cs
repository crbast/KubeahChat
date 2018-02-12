//--------------------------------------------------------------------
//  Kubeah ! Open Source Project
//  
//  Kubeah Chat
//  Just like Open Source
//--------------------------------------------------------------------
using System.Windows.Forms;

namespace KChat.Methods
{
    class AppInfoOnline
    {
        public static void GetDescription()
        {
            int iMode = 1;
            string sDescription = "";
            string sVersionWeb = "";
            try
            {
                System.Net.WebClient webClientKubeah = new System.Net.WebClient();
                sDescription = webClientKubeah.DownloadString("http://kubeah.com/kchat/description.txt");
                try
                {
                    sVersionWeb = webClientKubeah.DownloadString("http://kubeah.com/kchat/formattedVersion.txt");//Affectation de */version.txt à sVersionWeb
                    iMode = 1;
                }
                catch{ iMode = 2; }
            }
            catch { iMode = 3; }
            switch (iMode)
            {
                case 1:
                    MessageBox.Show($"{sDescription} \r\n \r\nApplication version : \t{AppInfo.sStringformattedVersion}\r\nLast version : \t\t{sVersionWeb} ", "A propos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show($"{sDescription} \r\n \r\nApplication version : \t{AppInfo.sStringformattedVersion}", "A propos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3: //Description par défaut
                    MessageBox.Show($"Kubeah Chat - In Progress \r\nKubeah! Open Source Project \r\nwww.kubeah.com \r\n\r\nDo you want to join Kubeah Chat team? \r\nhttps://github.com/CrBast/KubeahChat \r\n\r\nsupport@kubeah.com \r\n\r\nApplication version : \t{AppInfo.sStringformattedVersion}", "A propos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
    }
}
