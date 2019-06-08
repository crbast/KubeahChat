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
using KChat.Objects;
using System.Linq;
using System.Threading.Tasks;

namespace ChatLocalClient
{
    public partial class FrmMain : Form
    {
        Socket _sck;
        private EndPoint _epLocal, _epRemote;
        private bool _bEtatDestinataire = false; //State recipient True/Actif False/Inactif
        bool _bNotificationsEnable = false;
        string _recipientIp = "";

        public FrmMain()
        {
            InitializeComponent();
        }

        // At start-up
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //==============================AtStartUp===================================================
            lblDescription2.Visible = false; //Hidden label
            _sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//Socket creation
            _sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            lblIPPersonnel.Text = GetLocalIp();//Show personnal Ip
            tbxMessageEnvoit.MaxLength = 72;//Limit max lenght
            pbxLogoPetit.Visible = false;//Don't show logo
            NomDestinataireToolStripMenuItem.Visible = false;
            NomDestinataireToolStripMenuItem.Text = lblIPPersonnel.Text;
            iPPersonnelToolStripMenuItem.Visible = false;
            MaximizeBox = false;//Don't show maximize button on form
            //GESTIONFOCUS====================================================================================
            timContrôleFocus.Enabled = true;//Start timer focus
            lblNomPCDest.Visible = false;
            lblEtatPing.Visible = false;
            
            //==============SearchUpdate================================================================
            UpdateApplication.VersionVerification(AppInfo.GetChainFormattedVersion());//ApplicationVersionWeb          
            //================================================================================================
            //UpdateAppYear===================================================================================
            lblDescription.Text = $"Kubeah! {DateTime.Now.Year.ToString()}";
            lblDescription2.Text = $"Kubeah! {DateTime.Now.Year.ToString()}";
            //Create and read config==========================================================================
            var recipientIp = XmlManipulation.GetValue("LastIpConnexion");
            if(recipientIp != "")
                IpSeparationString(recipientIp, true);
            else
                IpSeparationString(lblIPPersonnel.Text, false);
            var focusState = XmlManipulation.GetValue("FocusActivate");
            if(focusState != "ON")
                timContrôleFocus.Enabled = false;
            if (XmlManipulation.GetValue("EnableLastIpConnexion") != "ON")
                XmlManipulation.ModifyElementXml("LastIpConnexion", "");
            //================================================================================================
        }

        /// <summary>
        /// Get localhost IP
        /// </summary>
        /// <returns>String : Example 192.168.0.2</returns>
        private static string GetLocalIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
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
        /// <param name="type">message | initialization</param>
        public void EnvoiDuMessage(string lblTextEnvoi, int type)
        {
            var kMessage = new KMessage(lblTextEnvoi, type);
            try
            {
                var enc = new UTF8Encoding();
                var msg = enc.GetBytes(kMessage.ReadyToSend());

                _sck.Send(msg);
                if(kMessage.GetMessageType() == KMessage.Type.Init().ToString())
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
                var int32 = Convert.ToInt32(sText);
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
        public void IpSeparationString(string sIp, bool withConfig)
        {
            if (withConfig)
            {
                var stringSeparators = new[] { "." };

                // ...
                var result = sIp.Split(stringSeparators, StringSplitOptions.None);

                var sIp1 = result[0];
                var sIp2 = result[1];
                var sIp3 = result[2];
                var sIp4 = result[3];

                tbxIP1.Text = sIp1;
                tbxIP2.Text = sIp2;
                tbxIP3.Text = sIp3;
                tbxIP4.Text = sIp4;
            }
            else
            {
                var stringSeparators = new[] { "." };

                // ...
                var result = sIp.Split(stringSeparators, StringSplitOptions.None);

                var sIp1 = result[0];
                var sIp2 = result[1];
                var sIp3 = result[2];

                tbxIP1.Text = sIp1;
                tbxIP2.Text = sIp2;
                tbxIP3.Text = sIp3;
            }
            
        }
        //=====================================================================================================================/
        //====================================================================================================================/

        //=====================BTNSTART=============================================================================
        private async void btnSart_ClickAsync(object sender, EventArgs e)
        {
            lblPatience.Visible = true;
            var sIpDestinataire = tbxIP1.Text + "." + tbxIP2.Text + "." + tbxIP3.Text + "." + tbxIP4.Text;
            if (sIpDestinataire == lblIPPersonnel.Text) { tbxIP4.BackColor = Color.Red; }
            if (tbxIP1.BackColor != Color.Red)
                if (tbxIP2.BackColor != Color.Red)
                {
                    if (tbxIP3.BackColor != Color.Red)
                    {
                        if (tbxIP4.BackColor != Color.Red)
                        {
                            if (tbxIP4.BackColor != Color.PaleGreen)
                            {
                                lblPatience.Visible = true;
                                lblEtatPing.Visible = false;
                                lblNomPCDest.Visible = false;
                                lblEtatPing.Visible = true;
                                var sNameDestinataire = Ip.GetHostName(sIpDestinataire);
                                var bResultPing = await Task.Run(() => Ip.PingDest(sIpDestinataire));
                                if (bResultPing)
                                {
                                    lblEtatPing.Text = @"Ping : OK";
                                    lblEtatPing.ForeColor = Color.Green;
                                    if (btnSart.Text == @"Check IP")
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
                                        if(XmlManipulation.GetValue("EnableLastIpConnexion") == "ON")
                                            XmlManipulation.ModifyElementXml("LastIpConnexion", sIpDestinataire);
                                        else
                                            XmlManipulation.ModifyElementXml("LastIpConnexion", "");
                                        _recipientIp = sIpDestinataire;
                                        try
                                        {
                                            _epLocal = new IPEndPoint(IPAddress.Parse(lblIPPersonnel.Text), 3056);//Use 3056 port
                                            _sck.Bind(_epLocal);

                                            _epRemote = new IPEndPoint(IPAddress.Parse(sIpDestinataire), 3056);
                                            _sck.Connect(_epRemote);

                                            var buffer = new byte[1500];
                                            _sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref _epRemote, MessageReceived, buffer);

                                            btnSart.Text = @"Connected";
                                            btnSart.Enabled = false;
                                            btnEnvoi.Enabled = true;
                                            tbxMessageEnvoit.Focus();
                                            EnvoiDuMessage("tuiFZCz56786casdcssdcvuivgboRTSDetre67Rz7463178", KMessage.Type.Init());
                                            if (XmlManipulation.GetValue("SaveDiscussion") == "ON")
                                            {
                                                var temp = ChatData.Import(_recipientIp);
                                                if (temp.Count() != 0)
                                                {
                                                    foreach (var element in temp)
                                                    {
                                                        lbxTchat.Items.Add(element);
                                                    }
                                                }        
                                            }
                                            
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
            lblPatience.Visible = false;
        }
        //==========================================================================================================================================================

        //====================================BTNEnvoi====================================================
        private void btnEnvoi_Click(object sender, EventArgs e)
        {
            if (!btnSart.Visible && tbxMessageEnvoit.Text != "")
            {
                if (_bEtatDestinataire == false)
                {
                    KNotification.Show(
                        "Your recipient is not active.\r\nThe discussions are not saved.\r\n Please wait for it to connect.");
                }
                else
                {
                    EnvoiDuMessage(tbxMessageEnvoit.Text, KMessage.Type.Message());
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

        //MENU========================================================
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
        //===========================================================
        
        private void tbxIP1_TextChanged(object sender, EventArgs e)
        {
            lblEtatPing.Visible = false;
            lblNomPCDest.Visible = false;
            tbxIP1.BackColor = LabelToIntTest(tbxIP1.Text) ? Color.Snow : Color.Red;
            if (tbxIP1.Text == "0") { tbxIP1.BackColor = Color.Red; }
            btnSart.Text = "Check IP";
            try { var ipInt32 = Convert.ToInt32(tbxIP1.Text); if (ipInt32 > 255 || ipInt32 == 0) { tbxIP1.BackColor = Color.Red; } } catch { } //Must be greater than 0 but less than 256
            if (tbxIP1.Text.Contains("-") || tbxIP1.Text.Contains("+")) { tbxIP1.BackColor = Color.Red; } //Browse the string to find the sign "-" or "+" if present tbx -> Red
        }
        private void tbxIP2_TextChanged(object sender, EventArgs e)
        {
            lblEtatPing.Visible = false;
            lblNomPCDest.Visible = false;
            tbxIP2.BackColor = LabelToIntTest(tbxIP2.Text) ? Color.Snow : Color.Red;
            btnSart.Text = "Check IP";
            try { if (Convert.ToInt32(tbxIP2.Text) > 255) {tbxIP2.BackColor = Color.Red;}}catch { } //Must be greater than or equal to 0 but less than 256
            if (tbxIP2.Text.Contains("-") || tbxIP2.Text.Contains("+")) { tbxIP2.BackColor = Color.Red; } //Browse the string to find the sign "-" or "+" if present tbx -> Red
        }
        private void tbxIP3_TextChanged(object sender, EventArgs e)
        {
            lblEtatPing.Visible = false;
            lblNomPCDest.Visible = false;
            tbxIP3.BackColor = LabelToIntTest(tbxIP3.Text) ? Color.Snow : Color.Red;
            btnSart.Text = "Check IP";
            try {  if (Convert.ToInt32(tbxIP3.Text) > 255) { tbxIP3.BackColor = Color.Red; } } catch { } //Must be greater than or equal to 0 but less than 256
            if (tbxIP3.Text.Contains("-") || tbxIP3.Text.Contains("+")) { tbxIP3.BackColor = Color.Red; } //Browse the string to find the sign "-" or "+" if present tbx -> Red
        }

        private void tbxIP4_TextChanged(object sender, EventArgs e)
        {
            lblEtatPing.Visible = false;
            lblNomPCDest.Visible = false;
            tbxIP4.BackColor = LabelToIntTest(tbxIP4.Text) ? Color.Snow : Color.Red;
            btnSart.Text = "Check IP";
            try { var ipInt32 = Convert.ToInt32(tbxIP4.Text); if (ipInt32 > 255 || ipInt32 == 0) { tbxIP4.BackColor = Color.Red; } } catch { } //Must be greater than or equal to 0 but less than 256
            if (tbxIP4.Text.Contains("-") || tbxIP4.Text.Contains("+")) { tbxIP4.BackColor = Color.Red; } //Browse the string to find the sign "-" or "+" if present tbx -> Red
        }
        //======================================FIN========================FIN===============================================================================
        private void tbxMessageEnvoit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (btnSart.Visible != true)
                {
                    if (tbxMessageEnvoit.Text != "")
                        if (_bEtatDestinataire == false)
                        {
                            KNotification.Show("Your recipient is not active.\r\nThe discussions are not saved.\r\n Please wait for it to connect.");
                        }
                        else
                        {
                            EnvoiDuMessage(tbxMessageEnvoit.Text, KMessage.Type.Message());
                        }
                }
            }
        }

        //GestionNbrCactèresRestants=======================================================================================
        private void timNbrCaractères_Tick(object sender, EventArgs e)
        {
            //Allows you to show the number of characters left
            var iNbrCaract = tbxMessageEnvoit.TextLength;
            iNbrCaract = 72 - iNbrCaract;
            lblNbrCaractRestants.Text = Convert.ToString(iNbrCaract);
        }
        //FINGestionNbrCaractères===================================================================FIN====================
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Envoi la clé pour dire à l'autre client qu'il est absent
            //Que si la conversation à démmarée
            if (!btnSart.Visible)
            {
                EnvoiDuMessage("789ZCFZTiniwjZTUvjkas79012798", KMessage.Type.Init());//Clé Absent

                var status = XmlManipulation.GetValue("SaveDiscussion");
                if (status == "ON")
                {
                    var text = "";
                    foreach (var item in lbxTchat.Items)
                    {
                        text += item + "\r\n";
                    }
                    ChatData.Export(_recipientIp, text);
                    // Why one line?
                }
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
                var size = _sck.EndReceiveFrom(aResult, ref _epRemote);
                if (size > 0)
                {
                    var receivedData = new byte[1464];

                    receivedData = (byte[])aResult.AsyncState;

                    var enc = new UTF8Encoding();
                    var kMessage = new KMessage(enc.GetString(receivedData));
                    //Comparaison chaine de caractère reçu
                    if (kMessage.GetMessageType() == KMessage.Type.Init().ToString())
                    {
                        switch (kMessage.GetMessageContent())
                        {
                            case "789ZCFZTiniwjZTUvjkas79012798":
                                FrmMain.CheckForIllegalCrossThreadCalls = false;
                                _bEtatDestinataire = false;
                                RecipientStatus(_bEtatDestinataire);
                                FrmMain.CheckForIllegalCrossThreadCalls = true;
                                break;
                            case "tuiFZCz56786casdcssdcvuivgboRTSDetre67Rz7463178":
                                if (!_bEtatDestinataire)
                                {
                                    FrmMain.CheckForIllegalCrossThreadCalls = false;
                                    _bEtatDestinataire = true;
                                    RecipientStatus(_bEtatDestinataire);
                                    FrmMain.CheckForIllegalCrossThreadCalls = true;
                                }
                                break;
                            default:
                                Console.WriteLine("Default case");
                                break;
                        }
                    }
                    else
                    {
                        FrmMain.CheckForIllegalCrossThreadCalls = false;
                        lbxTchat.Items.Add("Him :      " + kMessage.GetMessageContent());
                        FrmMain.CheckForIllegalCrossThreadCalls = true;
                        if (_bNotificationsEnable)
                        {
                            KNotification.Show(kMessage.GetMessageContent());
                        }
                    }
                }

                var buffer = new byte[1500];
                _sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref _epRemote, new AsyncCallback(MessageReceived), buffer);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                Application.Exit();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmConfig = new KChat.frmConfig();
            frmConfig.Show();
        }

        private void ReadAppConfig_Tick(object sender, EventArgs e)
        {
            var temp = XmlManipulation.GetValue("FocusActivate");
            if (temp == "ON")
                timContrôleFocus.Enabled = true;
            else
                timContrôleFocus.Enabled = false;
        }

        private void FrmMain_Deactivate(object sender, EventArgs e)
        {
            _bNotificationsEnable = (XmlManipulation.GetValue("NotificationsEnable") == "ON") ? true : false;
        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            _bNotificationsEnable = false;
        }


        /// <summary>
        /// State of recipient.
        /// </summary>
        /// <param name="bEtat">True : Active | False : Inactive</param>
        private void RecipientStatus(bool bEtat)
        {
            if (bEtat == true)
            {
                FrmMain.CheckForIllegalCrossThreadCalls = false;
                lblStatutDestinataire.Text = "Recipient : Active";//Changement du statut le la personne
                lblStatutDestinataire.ForeColor = Color.Green;//Changement de la couleur du text
                EnvoiDuMessage("tuiFZCz56786casdcssdcvuivgboRTSDetre67Rz7463178", KMessage.Type.Init());
                FrmMain.CheckForIllegalCrossThreadCalls = true;
            }
            else
            {
                lblStatutDestinataire.Text = $"Recipient : Last connection { DateTime.Now.ToString("HH:mm")}";
                lblStatutDestinataire.ForeColor = Color.Red;
            }
        }
    }
}
//==========================FIN========================INFOS==================================================
//tuiFZCz56786casdcssdcvuivgboRTSDetre67Rz7463178-> Clé Présent
//789ZCFZTiniwjZTUvjkas79012798-> Clé Absent
//© Kubeah !
