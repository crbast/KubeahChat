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
            string temp = "";
            temp = XMLManipulation.ReturnValue("FocusActivate");
            if (temp == "")
            {

            }
            else
            {
                if (temp == "ON")
                    chbFocusOn.Checked = true;
                else
                    chbFocusOff.Checked = true;
            }
            
            temp = XMLManipulation.ReturnValue("EnableLastIpConnexion");
            if (temp == "")
            {

            }
            else
            {
                if (temp == "ON")
                    chbLastIpRecipientOn.Checked = true;
                else
                    chbLastIpRecipientOff.Checked = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chbFocusOn_CheckedChanged(object sender, EventArgs e)
        {
            if(chbFocusOn.Checked == true)
            {
                chbFocusOff.Checked = false;
                XMLManipulation.ModifyElementXML("FocusActivate", "ON");
            }
        }

        private void chbFocusOff_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFocusOff.Checked == true)
            {
                chbFocusOn.Checked = false;
                XMLManipulation.ModifyElementXML("FocusActivate", "OFF");
            }
        }

        private void chbLastIpRecipientOn_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLastIpRecipientOn.Checked == true)
            {
                chbLastIpRecipientOff.Checked = false;
                XMLManipulation.ModifyElementXML("EnableLastIpConnexion", "ON");
            }           
        }

        private void chbLastIpRecipientOff_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLastIpRecipientOff.Checked == true)
            {
                chbLastIpRecipientOn.Checked = false;
                XMLManipulation.ModifyElementXML("EnableLastIpConnexion", "OFF");
            }
        }
    }
}
