using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KChat
{
    public partial class Notification : Form
    {
        public Notification(string Content, string Title)
        {
            InitializeComponent();
            this.Opacity = 0.8;
            this.BackColor = Color.LightGray;
            tbxContent.BackColor = Color.LightGray;
            lblTitle.Text = Title;
            tbxContent.Text = Content;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
        }

        private void timerCloseApp_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
