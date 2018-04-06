namespace KChat
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chbFocusOn = new System.Windows.Forms.CheckBox();
            this.chbFocusOff = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chbLastIpRecipientOff = new System.Windows.Forms.CheckBox();
            this.chbLastIpRecipientOn = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chbSaveDiscussionOff = new System.Windows.Forms.CheckBox();
            this.chbSaveDiscussionOn = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDropDiscussion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(126, 181);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 34);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Focus";
            // 
            // chbFocusOn
            // 
            this.chbFocusOn.AutoSize = true;
            this.chbFocusOn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbFocusOn.Location = new System.Drawing.Point(201, 18);
            this.chbFocusOn.Name = "chbFocusOn";
            this.chbFocusOn.Size = new System.Drawing.Size(48, 21);
            this.chbFocusOn.TabIndex = 3;
            this.chbFocusOn.Text = "ON";
            this.chbFocusOn.UseVisualStyleBackColor = true;
            this.chbFocusOn.CheckedChanged += new System.EventHandler(this.chbFocusOn_CheckedChanged);
            // 
            // chbFocusOff
            // 
            this.chbFocusOff.AutoSize = true;
            this.chbFocusOff.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbFocusOff.Location = new System.Drawing.Point(257, 18);
            this.chbFocusOff.Name = "chbFocusOff";
            this.chbFocusOff.Size = new System.Drawing.Size(50, 21);
            this.chbFocusOff.TabIndex = 4;
            this.chbFocusOff.Text = "OFF";
            this.chbFocusOff.UseVisualStyleBackColor = true;
            this.chbFocusOff.CheckedChanged += new System.EventHandler(this.chbFocusOff_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "__________________________________________________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(307, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "__________________________________________________";
            // 
            // chbLastIpRecipientOff
            // 
            this.chbLastIpRecipientOff.AutoSize = true;
            this.chbLastIpRecipientOff.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbLastIpRecipientOff.Location = new System.Drawing.Point(257, 60);
            this.chbLastIpRecipientOff.Name = "chbLastIpRecipientOff";
            this.chbLastIpRecipientOff.Size = new System.Drawing.Size(50, 21);
            this.chbLastIpRecipientOff.TabIndex = 8;
            this.chbLastIpRecipientOff.Text = "OFF";
            this.chbLastIpRecipientOff.UseVisualStyleBackColor = true;
            this.chbLastIpRecipientOff.CheckedChanged += new System.EventHandler(this.chbLastIpRecipientOff_CheckedChanged);
            // 
            // chbLastIpRecipientOn
            // 
            this.chbLastIpRecipientOn.AutoSize = true;
            this.chbLastIpRecipientOn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbLastIpRecipientOn.Location = new System.Drawing.Point(201, 60);
            this.chbLastIpRecipientOn.Name = "chbLastIpRecipientOn";
            this.chbLastIpRecipientOn.Size = new System.Drawing.Size(48, 21);
            this.chbLastIpRecipientOn.TabIndex = 7;
            this.chbLastIpRecipientOn.Text = "ON";
            this.chbLastIpRecipientOn.UseVisualStyleBackColor = true;
            this.chbLastIpRecipientOn.CheckedChanged += new System.EventHandler(this.chbLastIpRecipientOn_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Save last IP recipient";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(307, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "__________________________________________________";
            // 
            // chbSaveDiscussionOff
            // 
            this.chbSaveDiscussionOff.AutoSize = true;
            this.chbSaveDiscussionOff.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSaveDiscussionOff.Location = new System.Drawing.Point(257, 101);
            this.chbSaveDiscussionOff.Name = "chbSaveDiscussionOff";
            this.chbSaveDiscussionOff.Size = new System.Drawing.Size(50, 21);
            this.chbSaveDiscussionOff.TabIndex = 12;
            this.chbSaveDiscussionOff.Text = "OFF";
            this.chbSaveDiscussionOff.UseVisualStyleBackColor = true;
            this.chbSaveDiscussionOff.CheckedChanged += new System.EventHandler(this.chbSaveDiscussionOff_CheckedChanged);
            // 
            // chbSaveDiscussionOn
            // 
            this.chbSaveDiscussionOn.AutoSize = true;
            this.chbSaveDiscussionOn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbSaveDiscussionOn.Location = new System.Drawing.Point(201, 101);
            this.chbSaveDiscussionOn.Name = "chbSaveDiscussionOn";
            this.chbSaveDiscussionOn.Size = new System.Drawing.Size(48, 21);
            this.chbSaveDiscussionOn.TabIndex = 11;
            this.chbSaveDiscussionOn.Text = "ON";
            this.chbSaveDiscussionOn.UseVisualStyleBackColor = true;
            this.chbSaveDiscussionOn.CheckedChanged += new System.EventHandler(this.chbSaveDiscussionOn_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Save discussion";
            // 
            // lblDropDiscussion
            // 
            this.lblDropDiscussion.AutoSize = true;
            this.lblDropDiscussion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDropDiscussion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDropDiscussion.Location = new System.Drawing.Point(12, 130);
            this.lblDropDiscussion.Name = "lblDropDiscussion";
            this.lblDropDiscussion.Size = new System.Drawing.Size(147, 16);
            this.lblDropDiscussion.TabIndex = 14;
            this.lblDropDiscussion.Text = "Delete all discussions";
            this.lblDropDiscussion.Click += new System.EventHandler(this.lblDropDiscussion_Click);
            this.lblDropDiscussion.MouseLeave += new System.EventHandler(this.lblDropDiscussion_MouseLeave);
            this.lblDropDiscussion.MouseHover += new System.EventHandler(this.lblDropDiscussion_MouseHover);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 221);
            this.ControlBox = false;
            this.Controls.Add(this.lblDropDiscussion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chbSaveDiscussionOff);
            this.Controls.Add(this.chbSaveDiscussionOn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chbLastIpRecipientOff);
            this.Controls.Add(this.chbLastIpRecipientOn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chbFocusOff);
            this.Controls.Add(this.chbFocusOn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.Text = "Config";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbFocusOn;
        private System.Windows.Forms.CheckBox chbFocusOff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbLastIpRecipientOff;
        private System.Windows.Forms.CheckBox chbLastIpRecipientOn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbSaveDiscussionOff;
        private System.Windows.Forms.CheckBox chbSaveDiscussionOn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDropDiscussion;
    }
}