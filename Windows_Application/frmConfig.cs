using KChat.Methods;
using ChatLocalClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KChat
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            //Display all settings with App.config
            string temp = "";
            temp = XMLManipulation.ReturnValue("FocusActivate");
            if (temp == "") { }
            else
            {
                if (temp == "ON")
                    chbFocusOn.Checked = true;
                else
                    chbFocusOff.Checked = true;
            }
            
            temp = XMLManipulation.ReturnValue("EnableLastIpConnexion");
            if (temp == "") { }
            else
            {
                if (temp == "ON")
                    chbLastIpRecipientOn.Checked = true;
                else
                    chbLastIpRecipientOff.Checked = true;
            }

            temp = XMLManipulation.ReturnValue("SaveDiscussion");
            if (temp == "") { }
            else
            {
                if (temp == "ON")
                    chbSaveDiscussionOn.Checked = true;
                else
                    chbSaveDiscussionOff.Checked = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chbFocusOn_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if(chbFocusOn.Checked == false && chbFocusOff.Checked == false)
            {
                chbFocusOff.Checked = true;
            }
            if(chbFocusOn.Checked == true)
            {
                chbFocusOff.Checked = false;
                //Change value on App.config
                XMLManipulation.ModifyElementXML("FocusActivate", "ON");
            }
        }

        private void chbFocusOff_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if (chbFocusOn.Checked == false && chbFocusOff.Checked == false)
            {
                chbFocusOn.Checked = true;
            }
            if (chbFocusOff.Checked == true)
            {
                chbFocusOn.Checked = false;
                //Change value on App.config
                XMLManipulation.ModifyElementXML("FocusActivate", "OFF");
            }
        }

        private void chbLastIpRecipientOn_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if (chbLastIpRecipientOn.Checked == false && chbLastIpRecipientOff.Checked == false)
            {
                chbLastIpRecipientOff.Checked = true;
            }
            if (chbLastIpRecipientOn.Checked == true)
            {
                chbLastIpRecipientOff.Checked = false;
                //Change value on App.config
                XMLManipulation.ModifyElementXML("EnableLastIpConnexion", "ON");
            }           
        }

        private void chbLastIpRecipientOff_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if (chbLastIpRecipientOn.Checked == false && chbLastIpRecipientOff.Checked == false)
            {
                chbLastIpRecipientOn.Checked = true;
            }
            if (chbLastIpRecipientOff.Checked == true)
            {
                chbLastIpRecipientOn.Checked = false;
                //Change value on App.config
                XMLManipulation.ModifyElementXML("EnableLastIpConnexion", "OFF");
            }
        }

        private void lblDropDiscussion_MouseHover(object sender, EventArgs e)
        {
            lblDropDiscussion.BackColor = Color.Red;
        }

        private void lblDropDiscussion_MouseLeave(object sender, EventArgs e)
        {
            lblDropDiscussion.BackColor = Color.Transparent;
        }

        private void lblDropDiscussion_Click(object sender, EventArgs e)
        {
            lblDropDiscussion.BackColor = Color.Transparent;
            if(Directory.Exists("./Discussions"))
            {
                //If the directory exist all file is deleted
                System.IO.DirectoryInfo di = new DirectoryInfo("./Discussions");
                foreach (FileInfo file in di.GetFiles())
                    file.Delete();
                foreach (DirectoryInfo dir in di.GetDirectories())
                    dir.Delete(true);
            }
        }

        private void chbSaveDiscussionOn_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if (chbSaveDiscussionOn.Checked == false && chbSaveDiscussionOff.Checked == false)
            {
                chbSaveDiscussionOff.Checked = true;
            }
            if (chbSaveDiscussionOn.Checked == true)
            {
                chbSaveDiscussionOff.Checked = false;
                //Change value on App.config
                XMLManipulation.ModifyElementXML("SaveDiscussion", "ON");
            }
        }

        private void chbSaveDiscussionOff_CheckedChanged(object sender, EventArgs e)
        {
            //Management Checked - not checked
            if (chbSaveDiscussionOn.Checked == false && chbSaveDiscussionOff.Checked == false)
            {
                chbSaveDiscussionOn.Checked = true;
            }
            if (chbSaveDiscussionOff.Checked == true)
            {
                chbSaveDiscussionOn.Checked = false;
                //Change value on App.config
                XMLManipulation.ModifyElementXML("SaveDiscussion", "OFF");
            }
        }
    }
}
