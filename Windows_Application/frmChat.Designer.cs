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
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ReadAppConfig = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoPetit)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxMessageEnvoit
            // 
            resources.ApplyResources(this.tbxMessageEnvoit, "tbxMessageEnvoit");
            this.tbxMessageEnvoit.Name = "tbxMessageEnvoit";
            this.tbxMessageEnvoit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxMessageEnvoit_KeyDown);
            // 
            // btnEnvoi
            // 
            resources.ApplyResources(this.btnEnvoi, "btnEnvoi");
            this.btnEnvoi.Name = "btnEnvoi";
            this.btnEnvoi.UseVisualStyleBackColor = true;
            this.btnEnvoi.Click += new System.EventHandler(this.btnEnvoi_Click);
            // 
            // lblIPDESTINATAIRE
            // 
            resources.ApplyResources(this.lblIPDESTINATAIRE, "lblIPDESTINATAIRE");
            this.lblIPDESTINATAIRE.Name = "lblIPDESTINATAIRE";
            // 
            // btnSart
            // 
            resources.ApplyResources(this.btnSart, "btnSart");
            this.btnSart.Name = "btnSart";
            this.btnSart.UseVisualStyleBackColor = true;
            this.btnSart.Click += new System.EventHandler(this.btnSart_ClickAsync);
            // 
            // lbxTchat
            // 
            resources.ApplyResources(this.lbxTchat, "lbxTchat");
            this.lbxTchat.FormattingEnabled = true;
            this.lbxTchat.Name = "lbxTchat";
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // lblDescription2
            // 
            resources.ApplyResources(this.lblDescription2, "lblDescription2");
            this.lblDescription2.Name = "lblDescription2";
            // 
            // lblIPPersonnel
            // 
            resources.ApplyResources(this.lblIPPersonnel, "lblIPPersonnel");
            this.lblIPPersonnel.Name = "lblIPPersonnel";
            // 
            // timContrôleFocus
            // 
            this.timContrôleFocus.Tick += new System.EventHandler(this.timContrôleFocus_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.NomDestinataireToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
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
            resources.ApplyResources(this.menuToolStripMenuItem, "menuToolStripMenuItem");
            // 
            // arrêterToolStripMenuItem
            // 
            this.arrêterToolStripMenuItem.Name = "arrêterToolStripMenuItem";
            resources.ApplyResources(this.arrêterToolStripMenuItem, "arrêterToolStripMenuItem");
            this.arrêterToolStripMenuItem.Click += new System.EventHandler(this.arrêterToolStripMenuItem_Click);
            // 
            // redémmarerToolStripMenuItem
            // 
            this.redémmarerToolStripMenuItem.Name = "redémmarerToolStripMenuItem";
            resources.ApplyResources(this.redémmarerToolStripMenuItem, "redémmarerToolStripMenuItem");
            this.redémmarerToolStripMenuItem.Click += new System.EventHandler(this.redémmarerToolStripMenuItem_Click);
            // 
            // iPPersonnelToolStripMenuItem
            // 
            this.iPPersonnelToolStripMenuItem.Name = "iPPersonnelToolStripMenuItem";
            resources.ApplyResources(this.iPPersonnelToolStripMenuItem, "iPPersonnelToolStripMenuItem");
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            resources.ApplyResources(this.aProposToolStripMenuItem, "aProposToolStripMenuItem");
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.aProposToolStripMenuItem_Click);
            // 
            // siteToolStripMenuItem
            // 
            this.siteToolStripMenuItem.Name = "siteToolStripMenuItem";
            resources.ApplyResources(this.siteToolStripMenuItem, "siteToolStripMenuItem");
            this.siteToolStripMenuItem.Click += new System.EventHandler(this.siteToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // NomDestinataireToolStripMenuItem
            // 
            this.NomDestinataireToolStripMenuItem.Name = "NomDestinataireToolStripMenuItem";
            resources.ApplyResources(this.NomDestinataireToolStripMenuItem, "NomDestinataireToolStripMenuItem");
            // 
            // lblNbrCaractRestants
            // 
            resources.ApplyResources(this.lblNbrCaractRestants, "lblNbrCaractRestants");
            this.lblNbrCaractRestants.Name = "lblNbrCaractRestants";
            // 
            // timNbrCaractères
            // 
            this.timNbrCaractères.Enabled = true;
            this.timNbrCaractères.Tick += new System.EventHandler(this.timNbrCaractères_Tick);
            // 
            // pbxLogo1
            // 
            this.pbxLogo1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pbxLogo1, "pbxLogo1");
            this.pbxLogo1.Name = "pbxLogo1";
            this.pbxLogo1.TabStop = false;
            // 
            // pbxLogoPetit
            // 
            this.pbxLogoPetit.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pbxLogoPetit, "pbxLogoPetit");
            this.pbxLogoPetit.Name = "pbxLogoPetit";
            this.pbxLogoPetit.TabStop = false;
            // 
            // lblStatutDestinataire
            // 
            resources.ApplyResources(this.lblStatutDestinataire, "lblStatutDestinataire");
            this.lblStatutDestinataire.Name = "lblStatutDestinataire";
            // 
            // lblFixeCePC
            // 
            resources.ApplyResources(this.lblFixeCePC, "lblFixeCePC");
            this.lblFixeCePC.Name = "lblFixeCePC";
            // 
            // tbxIP1
            // 
            this.tbxIP1.BackColor = System.Drawing.Color.Snow;
            resources.ApplyResources(this.tbxIP1, "tbxIP1");
            this.tbxIP1.Name = "tbxIP1";
            this.tbxIP1.TextChanged += new System.EventHandler(this.tbxIP1_TextChanged);
            // 
            // tbxIP2
            // 
            this.tbxIP2.BackColor = System.Drawing.Color.Snow;
            resources.ApplyResources(this.tbxIP2, "tbxIP2");
            this.tbxIP2.Name = "tbxIP2";
            this.tbxIP2.TextChanged += new System.EventHandler(this.tbxIP2_TextChanged);
            // 
            // tbxIP3
            // 
            this.tbxIP3.BackColor = System.Drawing.Color.Snow;
            resources.ApplyResources(this.tbxIP3, "tbxIP3");
            this.tbxIP3.Name = "tbxIP3";
            this.tbxIP3.TextChanged += new System.EventHandler(this.tbxIP3_TextChanged);
            // 
            // tbxIP4
            // 
            this.tbxIP4.BackColor = System.Drawing.Color.PaleGreen;
            resources.ApplyResources(this.tbxIP4, "tbxIP4");
            this.tbxIP4.Name = "tbxIP4";
            this.tbxIP4.TextChanged += new System.EventHandler(this.tbxIP4_TextChanged);
            // 
            // lblEtatPing
            // 
            resources.ApplyResources(this.lblEtatPing, "lblEtatPing");
            this.lblEtatPing.Name = "lblEtatPing";
            // 
            // lblNomPCDest
            // 
            resources.ApplyResources(this.lblNomPCDest, "lblNomPCDest");
            this.lblNomPCDest.Name = "lblNomPCDest";
            // 
            // lblPatience
            // 
            resources.ApplyResources(this.lblPatience, "lblPatience");
            this.lblPatience.Name = "lblPatience";
            // 
            // ReadAppConfig
            // 
            this.ReadAppConfig.Enabled = true;
            this.ReadAppConfig.Interval = 1000;
            this.ReadAppConfig.Tick += new System.EventHandler(this.ReadAppConfig_Tick);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Activated += new System.EventHandler(this.FrmMain_Activated);
            this.Deactivate += new System.EventHandler(this.FrmMain_Deactivate);
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrêterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redémmarerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siteToolStripMenuItem;
        private System.Windows.Forms.Label lblNbrCaractRestants;
        private System.Windows.Forms.PictureBox pbxLogo1;
        private System.Windows.Forms.PictureBox pbxLogoPetit;
        private System.Windows.Forms.Label lblFixeCePC;
        private System.Windows.Forms.ToolStripMenuItem NomDestinataireToolStripMenuItem;
        private System.Windows.Forms.TextBox tbxIP1;
        private System.Windows.Forms.TextBox tbxIP2;
        private System.Windows.Forms.TextBox tbxIP3;
        private System.Windows.Forms.TextBox tbxIP4;
        private System.Windows.Forms.Label lblEtatPing;
        private System.Windows.Forms.Label lblNomPCDest;
        private System.Windows.Forms.Label lblPatience;
        private System.Windows.Forms.ToolStripMenuItem iPPersonnelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        public System.Windows.Forms.Timer timContrôleFocus;
        private System.Windows.Forms.Timer timNbrCaractères;
        private System.Windows.Forms.Timer ReadAppConfig;
        private System.Windows.Forms.Label lblStatutDestinataire;
    }
}

