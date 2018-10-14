/*
 * Kubeah ! Open Source Project
 * 
 * Kubeah Chat
 * Just like Open Source
 * 
 * It is necessary to have the application Kubeah_SimpleNotification
 * https://crbast.github.io/Kubeah_SimpleNotification/
 * Documentation are available :
 * https://github.com/CrBast/Kubeah_SimpleNotification/blob/master/using-fr.md
 * 
 * !!!! Copy the content of ".\External_Applications" on "\bin\Debug" !!!!
 * 
 * 
 * 
 * for more informations about Kubeah Chat
 * Please visit https://github.com/CrBast/KubeahChat
 *
 * 
 * 
 * APPLICATION LICENSE
 * GNU General Public License v3.0
 * https://github.com/CrBast/KubeahChat/blob/master/LICENSE
 * */
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using KChat.Methods;
using System.Diagnostics;
using System.IO;
using KChat.Objects;

namespace ChatLocalClient
{
    public partial class FrmMain : Form
    {
        Socket sck;
        EndPoint epLocal, epRemote;
        bool bEtatDestinataire = false; //State recipient True/Actif False/Inactif
        AppInfo appInfo = new AppInfo();
        bool bNotificationsEnable = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        // At start-up
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //==============================AtStartUp===================================================
            lblDescription2.Visible = false; //Hidden label
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//Socket creation
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            lblIPPersonnel.Text = GetLocalIP();//Show personnal Ip
            tbxMessageEnvoit.MaxLength = 72;//Limit max lenght
            pbxLogoPetit.Visible = false;//Don't show logo
            NomDestinataireToolStripMenuItem.Visible = false;
            NomDestinataireToolStripMenuItem.Text = lblIPPersonnel.Text;
            iPPersonnelToolStripMenuItem.Visible = false;
            this.MaximizeBox = false;//Don't show maximize button on form
            //GESTIONFOCUS====================================================================================
            timContrôleFocus.Enabled = true;//Start timer focus
            lblNomPCDest.Visible = false;
            lblEtatPing.Visible = false;
            
            //==============SearchUpdate================================================================
            UpdateApplication.VersionVerification(appInfo.GetChainFormattedVersion());//ApplicationVersionWeb          
            //================================================================================================
            //UpdateAppYear===================================================================================
            lblDescription.Text = $"Kubeah! {DateTime.Now.Year.ToString()}";
            lblDescription2.Text = $"Kubeah! {DateTime.Now.Year.ToString()}";
            //Create and read config==========================================================================
            string recipientIp = XMLManipulation.GetValue("LastIpConnexion");
            if(recipientIp != "")
                IPSeparationString(recipientIp, true);
            else
                IPSeparationString(lblIPPersonnel.Text, false);
            string focusState = XMLManipulation.GetValue("FocusActivate");
            if(focusState != "ON")
                timContrôleFocus.Enabled = false;
            if (XMLManipulation.GetValue("EnableLastIpConnexion") != "ON")
                XMLManipulation.ModifyElementXML("LastIpConnexion", "");
            //================================================================================================
        }

        /// <summary>
        /// Get localhost IP
        /// </summary>
        /// <returns>String : Example 192.168.0.2</returns>
        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "172.0.0.1";
        }


        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="lblTextEnvoi">String : Text to send</param>
        /// <param name="showOnTextBox">if it should display the result in the textBox</param>
        public void EnvoiDuMessage(string lblTextEnvoi, Boolean showOnTextBox)
        {
            try
            {
                System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                byte[] msg = new byte[1500];
                msg = enc.GetBytes(lblTextEnvoi);

                sck.Send(msg);
                if(showOnTextBox)
                {
                    lbxTchat.Items.Add("Me : " + tbxMessageEnvoit.Text);
                    tbxMessageEnvoit.Clear();
                }
            }
            catch
            {
                MessageBox.Show("An error occured. \r\nPlease restart Kubeah Chat" + "\r\n" + "\r\n", "An error occurred");
                Application.Exit();
            }
        }
        /// <summary>
        /// Checks the string to see if it is compatible
        /// </summary>
        /// <param name="sText">Text to verify</param>
        /// <returns>Boolean : true = Pass | false = Error</returns>
        public Boolean LabelToIntTest(string sText)
        {
            try
            {
                int iVerification = Convert.ToInt32(sText);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        //Fonction SPLITSTRING=================================================================================================/
        //=====================================================================================================================/
        //Permet l'affichage de l'IP séparé dans les textbox
        public void IPSeparationString(string sIP, bool withConfig)
        {
            if (withConfig)
            {
                string[] stringSeparators = new string[] { "." };
                string[] result;

                // ...
                result = sIP.Split(stringSeparators, StringSplitOptions.None);

                string sIp1 = result[0];
                string sIp2 = result[1];
                string sIp3 = result[2];
                string sIp4 = result[3];

                tbxIP1.Text = sIp1;
                tbxIP2.Text = sIp2;
                tbxIP3.Text = sIp3;
                tbxIP4.Text = sIp4;
            }
            else
            {
                string[] stringSeparators = new string[] { "." };
                string[] result;

                // ...
                result = sIP.Split(stringSeparators, StringSplitOptions.None);

                string sIp1 = result[0];
                string sIp2 = result[1];
                string sIp3 = result[2];

                tbxIP1.Text = sIp1;
                tbxIP2.Text = sIp2;
                tbxIP3.Text = sIp3;
            }
            
        }
        //=====================================================================================================================/
        //====================================================================================================================/

        //=====================BTNSTART=============================================================================
        private void btnSart_Click(object sender, EventArgs e)
        {
            lblPatience.Visible = true;
            string sIPDestinataire = tbxIP1.Text + "." + tbxIP2.Text + "." + tbxIP3.Text + "." + tbxIP4.Text;
            if (sIPDestinataire == lblIPPersonnel.Text) { tbxIP4.BackColor = Color.Red; }
            if (tbxIP1.BackColor != Color.Red)
                if (tbxIP2.BackColor != Color.Red)
                {
                    if (tbxIP3.BackColor != Color.Red)
                    {
                        if (tbxIP4.BackColor != Color.Red)
                        {
                            if (tbxIP4.BackColor != Color.PaleGreen)
                            {
                                this.Enabled = false;
                                lblPatience.Visible = true;
                                lblEtatPing.Visible = false;
                                lblNomPCDest.Visible = false;
                                lblEtatPing.Visible = true;
                                string sNameDestinataire = Ip.GetHostName(sIPDestinataire);
                                bool bResultPing = Ip.PingDest(sIPDestinataire);
                                if (bResultPing == true)
                                {
                                    lblEtatPing.Text = "Ping : OK";
                                    lblEtatPing.ForeColor = Color.Green;
                                    if (btnSart.Text == "Check IP")
                                    {
                                        if (sNameDestinataire == "")
                                        {
                                            lblNomPCDest.Text = "Name :" + "\r\n" + "Not found";
                                            lblNomPCDest.ForeColor = Color.Red;
                                            lblNomPCDest.Visible = true;
                                            tbxIP4.BackColor = Color.Red;
                                        }
                                        else
                                        {
                                            btnSart.Text = "Start";
                                            lblNomPCDest.Visible = true;
                                            lblNomPCDest.Text = "Name :" + "\r\n" + sNameDestinataire;
                                            lblNomPCDest.ForeColor = Color.Black;
                                            bResultPing = Ip.PingDest(sIPDestinataire);
                                        }
                                    }
                                    else
                                    {
                                        //___________MinimiserLaFenetre________________
                                        this.Width = 620;
                                        lblDescription.Visible = false;
                                        btnSart.Visible = false;
                                        lblDescription2.Visible = true;
                                        lblIPDESTINATAIRE.Visible = false;
                                        pbxLogo1.Visible = false;
                                        pbxLogoPetit.Visible = true;
                                        lblIPPersonnel.Visible = false;
                                        lblFixeCePC.Visible = false;
                                        NomDestinataireToolStripMenuItem.Visible = true;
                                        tbxIP1.Visible = false;
                                        tbxIP2.Visible = false;
                                        tbxIP3.Visible = false;
                                        tbxIP4.Visible = false;
                                        NomDestinataireToolStripMenuItem.Text = "Recipient : " + sNameDestinataire;
                                        lblNomPCDest.Visible = false;
                                        iPPersonnelToolStripMenuItem.Text = "My IP : " + lblIPPersonnel.Text;
                                        iPPersonnelToolStripMenuItem.Visible = true;
                                        //______________________________________________
                                        //FichierConfig---------------------------------
                                        if(XMLManipulation.GetValue("EnableLastIpConnexion") == "ON")
                                            XMLManipulation.ModifyElementXML("LastIpConnexion", sIPDestinataire);
                                        else
                                            XMLManipulation.ModifyElementXML("LastIpConnexion", "");
                                        try
                                        {
                                            epLocal = new IPEndPoint(IPAddress.Parse(lblIPPersonnel.Text), 3056);//Use 3056 port
                                            sck.Bind(epLocal);

                                            epRemote = new IPEndPoint(IPAddress.Parse(sIPDestinataire), 3056);
                                            sck.Connect(epRemote);

                                            byte[] buffer = new byte[1500];
                                            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageReceived), buffer);

                                            btnSart.Text = "Connected";
                                            btnSart.Enabled = false;
                                            btnEnvoi.Enabled = true;
                                            tbxMessageEnvoit.Focus();
                                            EnvoiDuMessage("tuiFZCz56786casdcssdcvuivgboRTSDetre67Rz7463178", false);//Clé Présent
                                        }
                                        catch
                                        {
                                            MessageBox.Show("An error occured. \r\nPlease restart Kubeah Chat" + "\r\n" + "\r\n", "An error occurred");
                                            Application.Exit();
                                        }
                                        //Send the key to the other client to connect

                                    }
                                }
                                else
                                {
                                    lblEtatPing.Text = "Ping : Fail";
                                    lblEtatPing.ForeColor = Color.Red;
                                    lblNomPCDest.Visible = false;
                                    tbxIP4.BackColor = Color.Red;
                                }
                            }
                        }
                    }
                }
            this.Enabled = true;
            lblPatience.Visible = false;
        }
        //==========================================================================================================================================================

        //====================================BTNEnvoi====================================================
        private void btnEnvoi_Click(object sender, EventArgs e)
        {
            if (btnSart.Visible == true)
            {

            }
            else
            {
                if (tbxMessageEnvoit.Text != "")
                    if (bEtatDestinataire == false)
                    {
                        CreateNotification("Your recipient is not active.\r\nThe discussions are not saved.\r\n Please wait for it to connect.");
                    }
                    else
                    {
                        EnvoiDuMessage(tbxMessageEnvoit.Text, true);
                    }
             }
        }
        //===============================================================================================

        /// <summary>
        /// Focus management
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timContrôleFocus_Tick(object sender, EventArgs e)
        {
            // Always keeps the last record as selected
            lbxTchat.SelectedIndex = lbxTchat.Items.Count - 1;
        }

        //MENU================================================MENU==============================MENU========================================================
        private void arrêterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void redémmarerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppInfoOnline.GetDescription();
        }

        private void siteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://sites.google.com/view/kubeahchat");
            }
            catch { }
        }
        //FINMENU==============================================FIN============================================MENU===========================================

        //Gestion des informations utilisateur IP destinataire===============================================================================================
        private void tbxIP1_TextChanged(object sender, EventArgs e)
        {
            lblEtatPing.Visible = false;
            lblNomPCDest.Visible = false;
            Boolean temp = LabelToIntTest(tbxIP1.Text);//Utilise la fonction "LabelToIntTest"
            if (temp){tbxIP1.BackColor = Color.Snow;} else{tbxIP1.BackColor = Color.Red;}
            if (tbxIP1.Text == "0") { tbxIP1.BackColor = Color.Red; }
            btnSart.Text = "Check IP";
            try { int iTemp2 = Convert.ToInt32(tbxIP1.Text); if (iTemp2 > 255 || iTemp2 == 0) { tbxIP1.BackColor = Color.Red; } } catch { } //Must be greater than 0 but less than 256
            if (tbxIP1.Text.Contains("-") || tbxIP1.Text.Contains("+")) { tbxIP1.BackColor = Color.Red; } //Browse the string to find the sign "-" or "+" if present tbx -> Red
        }
        private void tbxIP2_TextChanged(object sender, EventArgs e)
        {
            lblEtatPing.Visible = false;
            lblNomPCDest.Visible = false;
            Boolean temp = LabelToIntTest(tbxIP2.Text);
            if (temp) { tbxIP2.BackColor = Color.Snow; } else { tbxIP2.BackColor = Color.Red; }
            btnSart.Text = "Check IP";
            try { int iTemp2 = Convert.ToInt32(tbxIP2.Text); if (iTemp2 > 255) {tbxIP2.BackColor = Color.Red;}}catch { } //Must be greater than or equal to 0 but less than 256
            if (tbxIP2.Text.Contains("-") || tbxIP2.Text.Contains("+")) { tbxIP2.BackColor = Color.Red; } //Browse the string to find the sign "-" or "+" if present tbx -> Red
        }
        private void tbxIP3_TextChanged(object sender, EventArgs e)
        {
            lblEtatPing.Visible = false;
            lblNomPCDest.Visible = false;
            bool temp = LabelToIntTest(tbxIP3.Text);
            if (temp){tbxIP3.BackColor = Color.Snow;} else{tbxIP3.BackColor = Color.Red;}
            btnSart.Text = "Check IP";
            try { int iTemp2 = Convert.ToInt32(tbxIP3.Text); if (iTemp2 > 255) { tbxIP3.BackColor = Color.Red; } } catch { } //Must be greater than or equal to 0 but less than 256
            if (tbxIP3.Text.Contains("-") || tbxIP3.Text.Contains("+")) { tbxIP3.BackColor = Color.Red; } //Browse the string to find the sign "-" or "+" if present tbx -> Red
        }

        private void tbxIP4_TextChanged(object sender, EventArgs e)
        {
            lblEtatPing.Visible = false;
            lblNomPCDest.Visible = false;
            bool temp = LabelToIntTest(tbxIP4.Text);
            if (temp){tbxIP4.BackColor = Color.Snow;} else{tbxIP4.BackColor = Color.Red;}
            btnSart.Text = "Check IP";
            try { int iTemp2 = Convert.ToInt32(tbxIP4.Text); if (iTemp2 > 255 || iTemp2 == 0) { tbxIP4.BackColor = Color.Red; } } catch { } //Must be greater than or equal to 0 but less than 256
            if (tbxIP4.Text.Contains("-") || tbxIP4.Text.Contains("+")) { tbxIP4.BackColor = Color.Red; } //Browse the string to find the sign "-" or "+" if present tbx -> Red
        }
        //======================================FIN========================FIN===============================================================================
        private void tbxMessageEnvoit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//Quand appuie sur touche enter
            {
                e.SuppressKeyPress = true;
                if (btnSart.Visible != true)
                {
                    if (tbxMessageEnvoit.Text != "")
                        if (bEtatDestinataire == false)
                        {
                            CreateNotification("Your recipient is not active.\r\nThe discussions are not saved.\r\n Please wait for it to connect.");
                        }
                        else
                        {
                            EnvoiDuMessage(tbxMessageEnvoit.Text, true);
                        }
                }
            }
        }

        //GestionNbrCactèresRestants=======================================================================================
        private void timNbrCaractères_Tick(object sender, EventArgs e)
        {
            //Permet de montrer le nombre de caractères restants
            int iNbrCaract = tbxMessageEnvoit.TextLength;//.TextLength permet de donner le nombre de caractères
            iNbrCaract = 72 - iNbrCaract;//Calcul pour donner le nombre de caractères restants
            lblNbrCaractRestants.Text = Convert.ToString(iNbrCaract);//Permet l'affichage de iNbrCract
        }
        //FINGestionNbrCaractères===================================================================FIN====================
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)//Quand l'utilisateur ferme la fenêtre
        {
            //Envoi la clé pour dire à l'autre client qu'il est absent
            //Que si la conversation à démmarée
            if (btnSart.Visible == false)
            {
                EnvoiDuMessage("789ZCFZTiniwjZTUvjkas79012798", false);//Clé Absent
            }
        }

        /// <summary>
        /// The code for the method (Recipient connected/Disconnected) is integrated directly into the message sending function. 
        /// It is likely to evolve and change place.
        /// The keys are used in this case as a means of comparison. 
        /// </summary>
        /// <param name="aResult">Type IAsyncResult</param>
        private void MessageReceived(IAsyncResult aResult)
        {
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);
                if (size > 0)
                {
                    byte[] receivedData = new byte[1464];

                    receivedData = (byte[])aResult.AsyncState;

                    UTF8Encoding enc = new UTF8Encoding();
                    string receivedMessage = enc.GetString(receivedData);
                    //Comparaison chaine de caractère reçu
                    if (receivedMessage == "789ZCFZTiniwjZTUvjkas79012798\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0")
                    {
                        bEtatDestinataire = false;
                        RecipientStatus(bEtatDestinataire);
                    }
                    else
                    {
                        //Comparaison chaine de caractère reçu est regarde contenu lblStatutDestinataire
                        if (receivedMessage == "tuiFZCz56786casdcssdcvuivgboRTSDetre67Rz7463178\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" && bEtatDestinataire == false)
                        {
                            bEtatDestinataire = true;
                            RecipientStatus(bEtatDestinataire);
                        }
                        else
                        {
                            if (receivedMessage != "tuiFZCz56786casdcssdcvuivgboRTSDetre67Rz7463178\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0")
                            {
                                lbxTchat.Items.Add("Him :      " + receivedMessage);
                                
                                if (bNotificationsEnable)
                                {
                                    CreateNotification(receivedMessage);
                                }
                            }
                        }
                    }
                }

                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageReceived), buffer);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                Application.Exit();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KChat.frmConfig frmConfig = new KChat.frmConfig();
            frmConfig.Show();
        }

        private void ReadAppConfig_Tick(object sender, EventArgs e)
        {
            string temp = XMLManipulation.GetValue("FocusActivate");
            if (temp == "ON")
                timContrôleFocus.Enabled = true;
            else
                timContrôleFocus.Enabled = false;
        }

        private void FrmMain_Deactivate(object sender, EventArgs e)
        {
            bNotificationsEnable = (XMLManipulation.GetValue("NotificationsEnable") == "ON") ? true : false;
        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            bNotificationsEnable = false;
        }


        /// <summary>
        /// State of recipient.
        /// </summary>
        /// <param name="bEtat">True : Active | False : Inactive</param>
        private void RecipientStatus(bool bEtat)
        {
            if (bEtat == true)
            {
                lblStatutDestinataire.Text = "Recipient : Active";//Changement du statut le la personne
                lblStatutDestinataire.ForeColor = Color.Green;//Changement de la couleur du text
                EnvoiDuMessage("tuiFZCz56786casdcssdcvuivgboRTSDetre67Rz7463178", false);
            }
            else
            {
                lblStatutDestinataire.Text = $"Recipient : Last connection { DateTime.Now.ToString("HH:mm")}";
                lblStatutDestinataire.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Create notification file and execute Kubeah_SimpleNotification
        /// </summary>
        /// <param name="Content">Content of the notification</param>
        public void CreateNotification(string Content)
        {
            XMLManipulation.CreateNotifFile(Content);
            var currentDirectory = Directory.GetCurrentDirectory();
            var executablePath = $@"{currentDirectory}\App\Windows_Notification.exe";
            var p = new Process { StartInfo = new ProcessStartInfo(executablePath) };
            p.StartInfo.WorkingDirectory = Path.GetDirectoryName(executablePath);
            p.Start();
        }
    }
}
//==========================FIN========================INFOS==================================================
//tuiFZCz56786casdcssdcvuivgboRTSDetre67Rz7463178-> Clé Présent
//789ZCFZTiniwjZTUvjkas79012798-> Clé Absent
//© Kubeah !
