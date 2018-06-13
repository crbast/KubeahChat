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

        //Lors du chargement de la fenêtre
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //==============================LorsDuDémmarage===================================================
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
            string recipientIp = XMLManipulation.ReturnValue("LastIpConnexion");
            if(recipientIp != "")
                IPSeparationString(recipientIp, true);
            else
                IPSeparationString(lblIPPersonnel.Text, false);
            string focusState = XMLManipulation.ReturnValue("FocusActivate");
            if(focusState != "ON")
                timContrôleFocus.Enabled = false;
            if (XMLManipulation.ReturnValue("EnableLastIpConnexion") != "ON")
                XMLManipulation.ModifyElementXML("LastIpConnexion", "");
            //================================================================================================
        }

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

        //Fonction ENVOIDUMESSAGE===============================================================================================/
        //======================================================================================================================/
        // 1 = OUI
        // 0 = NON
        // Pour l'affichage dans la TBX
        public void EnvoiDuMessage(string lblTextEnvoi, int iAffichageTBX)
        {
            try
            {
                System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                byte[] msg = new byte[1500];
                msg = enc.GetBytes(lblTextEnvoi);

                sck.Send(msg);
                if(iAffichageTBX == 1)
                {
                    lbxTchat.Items.Add("Me : " + tbxMessageEnvoit.Text);
                    tbxMessageEnvoit.Clear();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error occured. \r\nPlease restart Kubeah Chat" + "\r\n" + "\r\n", "An error occurred");
                Application.Exit();
            }
        }
        //Fonction LABELTOINTTEST==============================================================================================/
        //====================================================================================================================/
        //Return : 1 = Error 2 = PASS
        //Control int
        public int LabelToIntTest(string sText, int i)
        {
            try
            {
                int iVerification = Convert.ToInt32(sText);
                return i = 2;
            }
            catch
            {
                return i = 1;
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
                                string sNameDestinataire = Ip.NameMachineWithIP(sIPDestinataire);
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
                                        if(XMLManipulation.ReturnValue("EnableLastIpConnexion") == "ON")
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
                                            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageEnvoi), buffer);

                                            btnSart.Text = "Connected";
                                            btnSart.Enabled = false;
                                            btnEnvoi.Enabled = true;
                                            tbxMessageEnvoit.Focus();
                                            EnvoiDuMessage("tuiFZCz56786casdcssdcvuivgboRTSDetre67Rz7463178", 0);//Clé Présent
                                        }
                                        catch (Exception exception)
                                        {
                                            MessageBox.Show("An error occured. \r\nPlease restart Kubeah Chat" + "\r\n" + "\r\n", "An error occurred");
                                            Application.Exit();
                                        }
                                        //Envoit la clé à l'autre client pour connecté

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
                if (tbxMessageEnvoit.Text == "")
                {
                  //Permet de ne rien envoyer si la texte box est vide
                }
                else
                {
                    if (bEtatDestinataire == false)
                    {
                        MessageBox.Show("Your recipient is not active." + "\r\n" + "The discussions are not saved." + "\r\n" + "Please wait for it to connect.", "Your recipient is not active");
                    }
                    else
                    {
                        EnvoiDuMessage(tbxMessageEnvoit.Text, 1);
                    }
                }
             }
        }
        //===============================================================================================

        //======================================GestionFocus==============================================
        private void timContrôleFocus_Tick(object sender, EventArgs e)
        {
            lbxTchat.SelectedIndex = lbxTchat.Items.Count - 1;
        }
        //=====================================FINGestionFocus==============================================

        //MENU================================================MENU==============================MENU========================================================
        private void arrêterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//Menu 
        }

        private void redémmarerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();//Redémmare le pc
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppInfoOnline.GetDescription();
        }

        private void siteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://sites.google.com/view/kubeahchat");//Ouvre le lien dans le navigateur par défault
            }
            catch { }
        }
        //FINMENU==============================================FIN============================================MENU===========================================

        //Gestion des informations utilisateur IP destinataire===============================================================================================
        private void tbxIP1_TextChanged(object sender, EventArgs e)
        {
            lblEtatPing.Visible = false;
            lblNomPCDest.Visible = false;
            int iTemp = LabelToIntTest(tbxIP1.Text, 1);//Utilise la fonction "LabelToIntTest"
            if (iTemp == 2){tbxIP1.BackColor = Color.Snow;} else{tbxIP1.BackColor = Color.Red;}
            if (tbxIP1.Text == "0") { tbxIP1.BackColor = Color.Red; }
            btnSart.Text = "Check IP";//Changement du texte dans le btn
            try { int iTemp2 = Convert.ToInt32(tbxIP1.Text); if (iTemp2 > 255 || iTemp2 == 0) { tbxIP1.BackColor = Color.Red; } } catch { } //Doit être supérieur à 0 mais inférieur à 256
            if (tbxIP1.Text.Contains("-") || tbxIP1.Text.Contains("+")) { tbxIP1.BackColor = Color.Red; } //Parcoure la chaine pour trouver le signe "-" ou "+" si présent tbx -> Rouge
        }
        private void tbxIP2_TextChanged(object sender, EventArgs e)
        {
            lblEtatPing.Visible = false;
            lblNomPCDest.Visible = false;
            int iTemp = LabelToIntTest(tbxIP2.Text, 1);//Utilise la fonction "LabelToIntTest"
            if (iTemp == 2) { tbxIP2.BackColor = Color.Snow; } else { tbxIP2.BackColor = Color.Red; }
            btnSart.Text = "Check IP";//Changement du texte dans le btn
            try { int iTemp2 = Convert.ToInt32(tbxIP2.Text); if (iTemp2 > 255) {tbxIP2.BackColor = Color.Red;}}catch { } //Doit être supérieur ou égal à 0 mais inférieur à 256
            if (tbxIP2.Text.Contains("-") || tbxIP2.Text.Contains("+")) { tbxIP2.BackColor = Color.Red; } //Parcoure la chaine pour trouver le signe "-" ou "+" si présent tbx -> Rouge
        }
        private void tbxIP3_TextChanged(object sender, EventArgs e)
        {
            lblEtatPing.Visible = false;
            lblNomPCDest.Visible = false;
            int iTemp = LabelToIntTest(tbxIP3.Text, 1);//Utilise la fonction "LabelToIntTest"
            if (iTemp == 2){tbxIP3.BackColor = Color.Snow;} else{tbxIP3.BackColor = Color.Red;}
            btnSart.Text = "Check IP";//Changement du texte dans le btn
            try { int iTemp2 = Convert.ToInt32(tbxIP3.Text); if (iTemp2 > 255) { tbxIP3.BackColor = Color.Red; } } catch { } //Doit être supérieur ou égal à 0 mais inférieur à 256
            if (tbxIP3.Text.Contains("-") || tbxIP3.Text.Contains("+")) { tbxIP3.BackColor = Color.Red; } //Parcoure la chaine pour trouver le signe "-" ou "+" si présent tbx -> Rouge
        }

        private void tbxIP4_TextChanged(object sender, EventArgs e)
        {
            lblEtatPing.Visible = false;
            lblNomPCDest.Visible = false;
            int iTemp = LabelToIntTest(tbxIP4.Text, 1);//Utilise la fonction "LabelToIntTest"
            if (iTemp == 2){tbxIP4.BackColor = Color.Snow;} else{tbxIP4.BackColor = Color.Red;}
            btnSart.Text = "Check IP";//Changement du texte dans le btn
            try { int iTemp2 = Convert.ToInt32(tbxIP4.Text); if (iTemp2 > 255 || iTemp2 == 0) { tbxIP4.BackColor = Color.Red; } } catch { } //Doit être supérieur à 0 mais inférieur à 256
            if (tbxIP4.Text.Contains("-") || tbxIP4.Text.Contains("+")) { tbxIP4.BackColor = Color.Red; } //Parcoure la chaine pour trouver le signe "-" ou "+" si présent tbx -> Rouge
        }
        //======================================FIN========================FIN===============================================================================
        private void tbxMessageEnvoit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//Quand appuie sur touche enter
            {
                e.SuppressKeyPress = true;
                if (btnSart.Visible != true)
                {
                    if (tbxMessageEnvoit.Text == "")
                    {
                        //Permet de ne rien envoyer si la texte box est vide
                    }
                    else
                    {
                        if (bEtatDestinataire == false)
                        {
                            MessageBox.Show("Your recipient is not active." + "\r\n" + "The discussions are not saved." + "\r\n" + "Please wait for it to connect.", "Your recipient is not active");
                        }
                        else
                        {
                            EnvoiDuMessage(tbxMessageEnvoit.Text, 1);
                        }
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
                EnvoiDuMessage("789ZCFZTiniwjZTUvjkas79012798", 0);//Clé Absent
            }
        }

        //=====================FonctionReceptionMessage=====================================================================
        // Le code pour la méthode(Destinataire connecté/Déconnecté) est intégré directement dans la fonction
        // d'envoi du message. Elle risque d'évoluer et de changer de place. 
        // Les clé sont utilisées dans ce cas comme moyen de comparaison. 
        private void MessageEnvoi(IAsyncResult aResult)
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
                        StatusDestinataire(bEtatDestinataire);
                    }
                    else
                    {
                        //Comparaison chaine de caractère reçu est regarde contenu lblStatutDestinataire
                        if (receivedMessage == "tuiFZCz56786casdcssdcvuivgboRTSDetre67Rz7463178\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0" && bEtatDestinataire == false)
                        {
                            bEtatDestinataire = true;
                            StatusDestinataire(bEtatDestinataire);
                        }
                        else
                        {
                            if (receivedMessage != "tuiFZCz56786casdcssdcvuivgboRTSDetre67Rz7463178\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0")
                            {
                                lbxTchat.Items.Add("Him :      " + receivedMessage);
                                if(bNotificationsEnable == true)
                                {
                                    XMLManipulation.CreateNotifFile(receivedMessage);
                                    try
                                    {
                                        Process.Start(".\\App\\Windows_Notification.exe");
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }

                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageEnvoi), buffer);
            }
            catch (Exception exception)
            {
                MessageBox.Show("An error occured. \r\nPlease restart Kubeah Chat" + "\r\n" + "\r\n", "An error occurred");
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
            string temp = XMLManipulation.ReturnValue("FocusActivate");
            if (temp == "ON")
                timContrôleFocus.Enabled = true;
            else
                timContrôleFocus.Enabled = false;
        }

        private void FrmMain_Deactivate(object sender, EventArgs e)
        {
            bNotificationsEnable = (XMLManipulation.ReturnValue("NotificationsEnable") == "ON") ? true : false;
        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            bNotificationsEnable = false;
        }

        //True : active
        //False : inactive
        private void StatusDestinataire(bool bEtat)
        {

            if (bEtat == true)
            {
                lblStatutDestinataire.Text = "Recipient : Active";//Changement du statut le la personne
                lblStatutDestinataire.ForeColor = Color.Green;//Changement de la couleur du text
                EnvoiDuMessage("tuiFZCz56786casdcssdcvuivgboRTSDetre67Rz7463178", 0);
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