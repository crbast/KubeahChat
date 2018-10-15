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
using KChat.Methods;
using System.Diagnostics;
using System.IO;

namespace KChat.Objects
{
    /// <summary>
    /// Create beautiful notification
    /// </summary>
    public class KNotification
    {
        private string content = "";

        /// <summary>
        /// Create basic KNotification object
        /// </summary>
        /// <param name="content">Content of notification</param>
        KNotification(string content) => this.content = content;

        /// <summary>
        /// Show basic KNotification
        /// </summary>
        /// <param name="content"></param>
        public static void Show(string content) => ShowNotification(content);

        /// <summary>
        /// Show notification
        /// </summary>
        public void Show() => ShowNotification(content);

        /// <summary>
        /// Create notification - Private method
        /// </summary>
        /// <param name="content"></param>
        private static void ShowNotification(string content)
        {
            XMLManipulation.CreateNotifFile(content);
            var currentDirectory = Directory.GetCurrentDirectory();
            var executablePath = $@"{currentDirectory}\App\Windows_Notification.exe";
            var p = new Process { StartInfo = new ProcessStartInfo(executablePath) };
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(executablePath);
            p.Start();
        }
    }
}
