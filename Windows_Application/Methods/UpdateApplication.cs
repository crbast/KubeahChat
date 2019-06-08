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
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace KChat.Methods
{
    class UpdateApplication
    {
        /// <summary>
        /// Search if updates exist. If so, it creates a messageBox().
        /// </summary>
        /// <param name="iVersionApplication">Actual software version</param>
        public static void VersionVerification(long iVersionApplication)
        {
            try
            {
                var webClientKubeah = new System.Net.WebClient();
                var sVersionWeb = webClientKubeah.DownloadString("http://kubeah.com/kchat/version.txt");//Affectation de */version.txt à sVersionWeb
                if (iVersionApplication >= Convert.ToInt64(sVersionWeb)) { }//Comparaison si nouvelle/ancienne version
                else
                {//Si ancienne version
                    var sInfoNewVersion = webClientKubeah.DownloadString("http://kubeah.com/kchat/info.txt");//Affectation de */version.txt à sInfoNewVersion
                    var dialogResultUser = MessageBox.Show(sInfoNewVersion, @"A new version is available", MessageBoxButtons.YesNo);//Message box avec YES/NO
                    if (dialogResultUser == DialogResult.Yes)
                    {
                        try
                        {
                            Process.Start(".\\KubeahChat_Update.exe");
                            Application.Exit();
                        }
                        catch
                        {
                            MessageBox.Show(@"KubeahChat_Update.exe not found!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch { }
        }
    }
}