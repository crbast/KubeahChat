using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KChat.Methods
{
    class UpdateApplication
    {
        //Function verification update
        public static void VersionVerification(long iVersionApplication)
        {
            try
            {
                System.Net.WebClient webClientKubeah = new System.Net.WebClient();
                string sVersionWeb = webClientKubeah.DownloadString("http://kubeah.com/kchat/version.txt");//Affectation de */version.txt à sVersionWeb
                if (iVersionApplication >= Convert.ToInt64(sVersionWeb)) { }//Comparaison si nouvelle/ancienne version
                else
                {//Si ancienne version
                    string sInfoNewVersion = webClientKubeah.DownloadString("http://kubeah.com/kchat/info.txt");//Affectation de */version.txt à sInfoNewVersion
                    DialogResult dialogResultUser = MessageBox.Show(sInfoNewVersion, "Une nouvelle version est disponible", MessageBoxButtons.YesNo);//Message box avec YES/NO
                    if (dialogResultUser == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://sourceforge.net/projects/kubeah-chat/files/latest/download");//Ouvre le lien dans le navigateur par défault
                    }
                    else if (dialogResultUser == DialogResult.No) { }//Ne rien faire si NO
                }
            }
            catch { }//Pour gestion pas d'accès internet
        }
    }
}