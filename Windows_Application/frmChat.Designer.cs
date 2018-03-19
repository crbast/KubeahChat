namespace ChatLocalClient
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tbxMessageEnvoit = new System.Windows.Forms.TextBox();
            this.btnEnvoi = new System.Windows.Forms.Button();
            this.lblIPDESTINATAIRE = new System.Windows.Forms.Label();
            this.btnSart = new System.Windows.Forms.Button();
            this.lbxTchat = new System.Windows.Forms.ListBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDescription2 = new System.Windows.Forms.Label();
            this.lblIPPersonnel = new System.Windows.Forms.Label();
            this.timContrôleFocus = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrêterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redémmarerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPPersonnelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.focusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NomDestinataireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNbrCaractRestants = new System.Windows.Forms.Label();
            this.timNbrCaractères = new System.Windows.Forms.Timer(this.components);
            this.pbxLogo1 = new System.Windows.Forms.PictureBox();
            this.pbxLogoPetit = new System.Windows.Forms.PictureBox();
            this.lblStatutDestinataire = new System.Windows.Forms.Label();
            this.lblFixeCePC = new System.Windows.Forms.Label();
            this.tbxIP1 = new System.Windows.Forms.TextBox();
            this.tbxIP2 = new System.Windows.Forms.TextBox();
            this.tbxIP3 = new System.Windows.Forms.TextBox();
            this.tbxIP4 = new System.Windows.Forms.TextBox();
            this.lblEtatPing = new System.Windows.Forms.Label();
            this.lblNomPCDest = new System.Windows.Forms.Label();
            this.lblPatience = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoPetit)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxMessageEnvoit
            // 
            this.tbxMessageEnvoit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMessageEnvoit.Location = new System.Drawing.Point(38, 341);
            this.tbxMessageEnvoit.Name = "tbxMessageEnvoit";
            this.tbxMessageEnvoit.Size = new System.Drawing.Size(445, 20);
            this.tbxMessageEnvoit.TabIndex = 1;
            this.tbxMessageEnvoit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxMessageEnvoit_KeyDown);
            // 
            // btnEnvoi
            // 
            this.btnEnvoi.Location = new System.Drawing.Point(489, 340);
            this.btnEnvoi.Name = "btnEnvoi";
            this.btnEnvoi.Size = new System.Drawing.Size(93, 21);
            this.btnEnvoi.TabIndex = 2;
            this.btnEnvoi.Text = "Envoyer";
            this.btnEnvoi.UseVisualStyleBackColor = true;
            this.btnEnvoi.Click += new System.EventHandler(this.btnEnvoi_Click);
            // 
            // lblIPDESTINATAIRE
            // 
            this.lblIPDESTINATAIRE.AutoSize = true;
            this.lblIPDESTINATAIRE.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPDESTINATAIRE.Location = new System.Drawing.Point(660, 137);
            this.lblIPDESTINATAIRE.Name = "lblIPDESTINATAIRE";
            this.lblIPDESTINATAIRE.Size = new System.Drawing.Size(78, 17);
            this.lblIPDESTINATAIRE.TabIndex = 6;
            this.lblIPDESTINATAIRE.Text = "IP Recipient";
            // 
            // btnSart
            // 
            this.btnSart.Location = new System.Drawing.Point(662, 224);
            this.btnSart.Name = "btnSart";
            this.btnSart.Size = new System.Drawing.Size(130, 43);
            this.btnSart.TabIndex = 9;
            this.btnSart.Text = "Vérifier l\'IP";
            this.btnSart.UseVisualStyleBackColor = true;
            this.btnSart.Click += new System.EventHandler(this.btnSart_Click);
            // 
            // lbxTchat
            // 
            this.lbxTchat.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxTchat.FormattingEnabled = true;
            this.lbxTchat.ItemHeight = 16;
            this.lbxTchat.Location = new System.Drawing.Point(21, 43);
            this.lbxTchat.Name = "lbxTchat";
            this.lbxTchat.Size = new System.Drawing.Size(561, 276);
            this.lbxTchat.TabIndex = 10;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Century Gothic", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(784, 378);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 13);
            this.lblDescription.TabIndex = 18;
            this.lblDescription.Text = "Kubeah! 2018";
            // 
            // lblDescription2
            // 
            this.lblDescription2.AutoSize = true;
            this.lblDescription2.Font = new System.Drawing.Font("Century Gothic", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription2.Location = new System.Drawing.Point(529, 378);
            this.lblDescription2.Name = "lblDescription2";
            this.lblDescription2.Size = new System.Drawing.Size(67, 13);
            this.lblDescription2.TabIndex = 19;
            this.lblDescription2.Text = "Kubeah! 2018";
            // 
            // lblIPPersonnel
            // 
            this.lblIPPersonnel.AutoSize = true;
            this.lblIPPersonnel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPPersonnel.Location = new System.Drawing.Point(713, 270);
            this.lblIPPersonnel.Name = "lblIPPersonnel";
            this.lblIPPersonnel.Size = new System.Drawing.Size(81, 16);
            this.lblIPPersonnel.TabIndex = 20;
            this.lblIPPersonnel.Text = "lblIPPersonnel";
            // 
            // timContrôleFocus
            // 
            this.timContrôleFocus.Tick += new System.EventHandler(this.timContrôleFocus_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.focusToolStripMenuItem,
            this.NomDestinataireToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(856, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arrêterToolStripMenuItem,
            this.redémmarerToolStripMenuItem,
            this.iPPersonnelToolStripMenuItem,
            this.aProposToolStripMenuItem,
            this.siteToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // arrêterToolStripMenuItem
            // 
            this.arrêterToolStripMenuItem.Name = "arrêterToolStripMenuItem";
            this.arrêterToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.arrêterToolStripMenuItem.Text = "Stop";
            this.arrêterToolStripMenuItem.Click += new System.EventHandler(this.arrêterToolStripMenuItem_Click);
            // 
            // redémmarerToolStripMenuItem
            // 
            this.redémmarerToolStripMenuItem.Name = "redémmarerToolStripMenuItem";
            this.redémmarerToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.redémmarerToolStripMenuItem.Text = "Restart";
            this.redémmarerToolStripMenuItem.Click += new System.EventHandler(this.redémmarerToolStripMenuItem_Click);
            // 
            // iPPersonnelToolStripMenuItem
            // 
            this.iPPersonnelToolStripMenuItem.Name = "iPPersonnelToolStripMenuItem";
            this.iPPersonnelToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.iPPersonnelToolStripMenuItem.Text = "IPPersonnel";
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.aProposToolStripMenuItem.Text = "About";
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.aProposToolStripMenuItem_Click);
            // 
            // siteToolStripMenuItem
            // 
            this.siteToolStripMenuItem.Name = "siteToolStripMenuItem";
            this.siteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.siteToolStripMenuItem.Text = "Site";
            this.siteToolStripMenuItem.Click += new System.EventHandler(this.siteToolStripMenuItem_Click);
            // 
            // focusToolStripMenuItem
            // 
            this.focusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oNToolStripMenuItem,
            this.oFFToolStripMenuItem});
            this.focusToolStripMenuItem.Name = "focusToolStripMenuItem";
            this.focusToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.focusToolStripMenuItem.Text = "Focus";
            // 
            // oNToolStripMenuItem
            // 
            this.oNToolStripMenuItem.Name = "oNToolStripMenuItem";
            this.oNToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.oNToolStripMenuItem.Text = "ON";
            this.oNToolStripMenuItem.Click += new System.EventHandler(this.oNToolStripMenuItem_Click);
            // 
            // oFFToolStripMenuItem
            // 
            this.oFFToolStripMenuItem.Name = "oFFToolStripMenuItem";
            this.oFFToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.oFFToolStripMenuItem.Text = "OFF";
            this.oFFToolStripMenuItem.Click += new System.EventHandler(this.oFFToolStripMenuItem_Click);
            // 
            // NomDestinataireToolStripMenuItem
            // 
            this.NomDestinataireToolStripMenuItem.Name = "NomDestinataireToolStripMenuItem";
            this.NomDestinataireToolStripMenuItem.Size = new System.Drawing.Size(210, 20);
            this.NomDestinataireToolStripMenuItem.Text = "NomDestinataireToolStripMenuItem";
            // 
            // lblNbrCaractRestants
            // 
            this.lblNbrCaractRestants.AutoSize = true;
            this.lblNbrCaractRestants.Location = new System.Drawing.Point(18, 344);
            this.lblNbrCaractRestants.Name = "lblNbrCaractRestants";
            this.lblNbrCaractRestants.Size = new System.Drawing.Size(19, 13);
            this.lblNbrCaractRestants.TabIndex = 26;
            this.lblNbrCaractRestants.Text = "72";
            // 
            // timNbrCaractères
            // 
            this.timNbrCaractères.Enabled = true;
            this.timNbrCaractères.Tick += new System.EventHandler(this.timNbrCaractères_Tick);
            // 
            // pbxLogo1
            // 
            this.pbxLogo1.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo1.Image = ((System.Drawing.Image)(resources.GetObject("pbxLogo1.Image")));
            this.pbxLogo1.Location = new System.Drawing.Point(637, 37);
            this.pbxLogo1.Name = "pbxLogo1";
            this.pbxLogo1.Size = new System.Drawing.Size(174, 67);
            this.pbxLogo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo1.TabIndex = 27;
            this.pbxLogo1.TabStop = false;
            // 
            // pbxLogoPetit
            // 
            this.pbxLogoPetit.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogoPetit.Image = ((System.Drawing.Image)(resources.GetObject("pbxLogoPetit.Image")));
            this.pbxLogoPetit.Location = new System.Drawing.Point(18, 362);
            this.pbxLogoPetit.Name = "pbxLogoPetit";
            this.pbxLogoPetit.Size = new System.Drawing.Size(82, 26);
            this.pbxLogoPetit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogoPetit.TabIndex = 28;
            this.pbxLogoPetit.TabStop = false;
            // 
            // lblStatutDestinataire
            // 
            this.lblStatutDestinataire.AutoSize = true;
            this.lblStatutDestinataire.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatutDestinataire.Location = new System.Drawing.Point(18, 26);
            this.lblStatutDestinataire.Name = "lblStatutDestinataire";
            this.lblStatutDestinataire.Size = new System.Drawing.Size(65, 16);
            this.lblStatutDestinataire.TabIndex = 29;
            this.lblStatutDestinataire.Text = "Recipient :";
            // 
            // lblFixeCePC
            // 
            this.lblFixeCePC.AutoSize = true;
            this.lblFixeCePC.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixeCePC.Location = new System.Drawing.Point(660, 270);
            this.lblFixeCePC.Name = "lblFixeCePC";
            this.lblFixeCePC.Size = new System.Drawing.Size(51, 16);
            this.lblFixeCePC.TabIndex = 30;
            this.lblFixeCePC.Text = "This PC :";
            // 
            // tbxIP1
            // 
            this.tbxIP1.BackColor = System.Drawing.Color.Snow;
            this.tbxIP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIP1.Location = new System.Drawing.Point(662, 156);
            this.tbxIP1.MaxLength = 3;
            this.tbxIP1.Name = "tbxIP1";
            this.tbxIP1.Size = new System.Drawing.Size(29, 20);
            this.tbxIP1.TabIndex = 31;
            this.tbxIP1.Text = "192";
            this.tbxIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxIP1.TextChanged += new System.EventHandler(this.tbxIP1_TextChanged);
            // 
            // tbxIP2
            // 
            this.tbxIP2.BackColor = System.Drawing.Color.Snow;
            this.tbxIP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIP2.Location = new System.Drawing.Point(695, 156);
            this.tbxIP2.MaxLength = 3;
            this.tbxIP2.Name = "tbxIP2";
            this.tbxIP2.Size = new System.Drawing.Size(29, 20);
            this.tbxIP2.TabIndex = 32;
            this.tbxIP2.Text = "168";
            this.tbxIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxIP2.TextChanged += new System.EventHandler(this.tbxIP2_TextChanged);
            // 
            // tbxIP3
            // 
            this.tbxIP3.BackColor = System.Drawing.Color.Snow;
            this.tbxIP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIP3.Location = new System.Drawing.Point(730, 156);
            this.tbxIP3.MaxLength = 3;
            this.tbxIP3.Name = "tbxIP3";
            this.tbxIP3.Size = new System.Drawing.Size(29, 20);
            this.tbxIP3.TabIndex = 33;
            this.tbxIP3.Text = "0";
            this.tbxIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxIP3.TextChanged += new System.EventHandler(this.tbxIP3_TextChanged);
            // 
            // tbxIP4
            // 
            this.tbxIP4.BackColor = System.Drawing.Color.PaleGreen;
            this.tbxIP4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxIP4.Location = new System.Drawing.Point(763, 156);
            this.tbxIP4.MaxLength = 3;
            this.tbxIP4.Name = "tbxIP4";
            this.tbxIP4.Size = new System.Drawing.Size(29, 20);
            this.tbxIP4.TabIndex = 34;
            this.tbxIP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxIP4.TextChanged += new System.EventHandler(this.tbxIP4_TextChanged);
            // 
            // lblEtatPing
            // 
            this.lblEtatPing.AutoSize = true;
            this.lblEtatPing.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtatPing.Location = new System.Drawing.Point(660, 178);
            this.lblEtatPing.Name = "lblEtatPing";
            this.lblEtatPing.Size = new System.Drawing.Size(65, 16);
            this.lblEtatPing.TabIndex = 35;
            this.lblEtatPing.Text = "lblEtatPing";
            // 
            // lblNomPCDest
            // 
            this.lblNomPCDest.AutoSize = true;
            this.lblNomPCDest.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomPCDest.Location = new System.Drawing.Point(660, 193);
            this.lblNomPCDest.Name = "lblNomPCDest";
            this.lblNomPCDest.Size = new System.Drawing.Size(84, 16);
            this.lblNomPCDest.TabIndex = 36;
            this.lblNomPCDest.Text = "lblNomPCDest";
            // 
            // lblPatience
            // 
            this.lblPatience.AutoSize = true;
            this.lblPatience.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatience.Location = new System.Drawing.Point(686, 208);
            this.lblPatience.Name = "lblPatience";
            this.lblPatience.Size = new System.Drawing.Size(82, 17);
            this.lblPatience.TabIndex = 37;
            this.lblPatience.Text = "Please wait";
            this.lblPatience.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 393);
            this.Controls.Add(this.lblPatience);
            this.Controls.Add(this.lblNomPCDest);
            this.Controls.Add(this.lblEtatPing);
            this.Controls.Add(this.tbxIP4);
            this.Controls.Add(this.tbxIP3);
            this.Controls.Add(this.tbxIP2);
            this.Controls.Add(this.tbxIP1);
            this.Controls.Add(this.lblFixeCePC);
            this.Controls.Add(this.lblStatutDestinataire);
            this.Controls.Add(this.pbxLogoPetit);
            this.Controls.Add(this.pbxLogo1);
            this.Controls.Add(this.lblNbrCaractRestants);
            this.Controls.Add(this.lblIPPersonnel);
            this.Controls.Add(this.lblDescription2);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lbxTchat);
            this.Controls.Add(this.btnSart);
            this.Controls.Add(this.lblIPDESTINATAIRE);
            this.Controls.Add(this.btnEnvoi);
            this.Controls.Add(this.tbxMessageEnvoit);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.Text = "Kubeah Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoPetit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbxMessageEnvoit;
        private System.Windows.Forms.Button btnEnvoi;
        private System.Windows.Forms.Label lblIPDESTINATAIRE;
        private System.Windows.Forms.Button btnSart;
        private System.Windows.Forms.ListBox lbxTchat;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDescription2;
        private System.Windows.Forms.Label lblIPPersonnel;
        private System.Windows.Forms.Timer timContrôleFocus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrêterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redémmarerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siteToolStripMenuItem;
        private System.Windows.Forms.Label lblNbrCaractRestants;
        private System.Windows.Forms.Timer timNbrCaractères;
        private System.Windows.Forms.PictureBox pbxLogo1;
        private System.Windows.Forms.PictureBox pbxLogoPetit;
        private System.Windows.Forms.Label lblStatutDestinataire;
        private System.Windows.Forms.Label lblFixeCePC;
        private System.Windows.Forms.ToolStripMenuItem NomDestinataireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem focusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oFFToolStripMenuItem;
        private System.Windows.Forms.TextBox tbxIP1;
        private System.Windows.Forms.TextBox tbxIP2;
        private System.Windows.Forms.TextBox tbxIP3;
        private System.Windows.Forms.TextBox tbxIP4;
        private System.Windows.Forms.Label lblEtatPing;
        private System.Windows.Forms.Label lblNomPCDest;
        private System.Windows.Forms.Label lblPatience;
        private System.Windows.Forms.ToolStripMenuItem iPPersonnelToolStripMenuItem;
    }
}

