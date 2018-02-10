using System.Windows.Forms;

namespace KChat.Methods
{
    class AppInfoOnline
    {
        public static void GetDescription()
        {
            try
            {
                System.Net.WebClient webClientKubeah = new System.Net.WebClient();
                string sDescription = webClientKubeah.DownloadString("http://kubeah.com/kchat/description.txt");
                try
                {
                    string sVersionWeb = webClientKubeah.DownloadString("http://kubeah.com/kchat/formattedVersion.txt");//Affectation de */version.txt à sVersionWeb
                    DialogResult dialogResultUser = MessageBox.Show($"{sDescription} \r\n \r\nLast version : {sVersionWeb}", "A propos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    DialogResult dialogResultUser = MessageBox.Show(sDescription, "A propos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch { //Description par défaut
                MessageBox.Show(text: "Kubeah Chat - In Progress" + "\r\n" + "Kubeah! The Open Source Project" + "\r\n" + "www.kubeah.com" + "\r\n" + "\r\n" + "You want to join the developer team?" + "\r\n" + "Contact : support@kubeah.com", caption: "A propos", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
            }
        }
    }
}
