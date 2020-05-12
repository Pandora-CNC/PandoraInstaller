namespace PandoraInstaller
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.grayPanel = new System.Windows.Forms.Panel();
            this.forumImage = new System.Windows.Forms.PictureBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.logoImage = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.versionBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.versionCbox = new System.Windows.Forms.ComboBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.installButton = new System.Windows.Forms.Button();
            this.driveBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.driveCbox = new System.Windows.Forms.ComboBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.formatButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.grayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.forumImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoImage)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.versionBox.SuspendLayout();
            this.driveBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grayPanel
            // 
            this.grayPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(47)))), ((int)(((byte)(56)))));
            this.grayPanel.Controls.Add(this.forumImage);
            this.grayPanel.Controls.Add(this.versionLabel);
            this.grayPanel.Controls.Add(this.logoImage);
            this.grayPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grayPanel.Location = new System.Drawing.Point(0, 0);
            this.grayPanel.Name = "grayPanel";
            this.grayPanel.Size = new System.Drawing.Size(464, 58);
            this.grayPanel.TabIndex = 2;
            // 
            // forumImage
            // 
            this.forumImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.forumImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forumImage.Image = global::PandoraInstaller.Properties.Resources.Forum;
            this.forumImage.Location = new System.Drawing.Point(409, 8);
            this.forumImage.Name = "forumImage";
            this.forumImage.Size = new System.Drawing.Size(46, 41);
            this.forumImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.forumImage.TabIndex = 2;
            this.forumImage.TabStop = false;
            this.forumImage.Click += new System.EventHandler(this.forumImage_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.versionLabel.AutoSize = true;
            this.versionLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.versionLabel.Location = new System.Drawing.Point(136, 15);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(191, 26);
            this.versionLabel.TabIndex = 7;
            this.versionLabel.Text = "Installer v1.7\r\nSoftware © 2017-2020, Pandora-CNC";
            // 
            // logoImage
            // 
            this.logoImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoImage.Image = ((System.Drawing.Image)(resources.GetObject("logoImage.Image")));
            this.logoImage.Location = new System.Drawing.Point(12, 14);
            this.logoImage.Name = "logoImage";
            this.logoImage.Size = new System.Drawing.Size(118, 33);
            this.logoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoImage.TabIndex = 1;
            this.logoImage.TabStop = false;
            this.logoImage.Click += new System.EventHandler(this.logoImage_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.versionBox);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Controls.Add(this.installButton);
            this.mainPanel.Controls.Add(this.driveBox);
            this.mainPanel.Controls.Add(this.infoLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 58);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(464, 363);
            this.mainPanel.TabIndex = 0;
            // 
            // versionBox
            // 
            this.versionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.versionBox.Controls.Add(this.label1);
            this.versionBox.Controls.Add(this.versionCbox);
            this.versionBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionBox.Location = new System.Drawing.Point(12, 76);
            this.versionBox.Name = "versionBox";
            this.versionBox.Size = new System.Drawing.Size(441, 93);
            this.versionBox.TabIndex = 13;
            this.versionBox.TabStop = false;
            this.versionBox.Text = "Firmware version";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(427, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please start by selecting the version of Pandora or the original firmware to be i" +
                "nstalled.\r\nThe official 2020 firmware runs on all devices. Concerning Pandora, n" +
                "ote it won\'t run on DDCSV3.1!";
            // 
            // versionCbox
            // 
            this.versionCbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.versionCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionCbox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionCbox.FormattingEnabled = true;
            this.versionCbox.Location = new System.Drawing.Point(9, 66);
            this.versionCbox.Name = "versionCbox";
            this.versionCbox.Size = new System.Drawing.Size(424, 21);
            this.versionCbox.TabIndex = 2;
            this.versionCbox.SelectedIndexChanged += new System.EventHandler(this.versionCbox_SelectedIndexChanged);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(296, 328);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Cancel";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // installButton
            // 
            this.installButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.installButton.Enabled = false;
            this.installButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installButton.Location = new System.Drawing.Point(377, 328);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(75, 23);
            this.installButton.TabIndex = 3;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // driveBox
            // 
            this.driveBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.driveBox.Controls.Add(this.label2);
            this.driveBox.Controls.Add(this.driveCbox);
            this.driveBox.Controls.Add(this.refreshButton);
            this.driveBox.Controls.Add(this.formatButton);
            this.driveBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driveBox.Location = new System.Drawing.Point(12, 175);
            this.driveBox.Name = "driveBox";
            this.driveBox.Size = new System.Drawing.Size(442, 147);
            this.driveBox.TabIndex = 12;
            this.driveBox.TabStop = false;
            this.driveBox.Text = "USB stick";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(427, 73);
            this.label2.TabIndex = 5;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // driveCbox
            // 
            this.driveCbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.driveCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driveCbox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driveCbox.FormattingEnabled = true;
            this.driveCbox.Location = new System.Drawing.Point(10, 93);
            this.driveCbox.Name = "driveCbox";
            this.driveCbox.Size = new System.Drawing.Size(363, 21);
            this.driveCbox.TabIndex = 0;
            this.driveCbox.SelectedIndexChanged += new System.EventHandler(this.driveCbox_SelectedIndexChanged);
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(379, 92);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(55, 23);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // formatButton
            // 
            this.formatButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.formatButton.Enabled = false;
            this.formatButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formatButton.Location = new System.Drawing.Point(9, 118);
            this.formatButton.Name = "formatButton";
            this.formatButton.Size = new System.Drawing.Size(75, 23);
            this.formatButton.TabIndex = 4;
            this.formatButton.Text = "FORMAT!";
            this.formatButton.UseVisualStyleBackColor = true;
            this.formatButton.Click += new System.EventHandler(this.formatButton_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.Location = new System.Drawing.Point(10, 12);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(442, 119);
            this.infoLabel.TabIndex = 11;
            this.infoLabel.Text = "This application will guide you through the process of installing Pandora onto yo" +
                "ur DDCSV1.1, DDCSV2.1, DDCSV3.1 and RMHV2.1 CNC controller.\r\n\r\nThe usage of this" +
                " utility is entirely at your own risk!";
            // 
            // MainForm
            // 
            this.AcceptButton = this.installButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(464, 421);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.grayPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pandora Installer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grayPanel.ResumeLayout(false);
            this.grayPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.forumImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoImage)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.versionBox.ResumeLayout(false);
            this.driveBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logoImage;
        private System.Windows.Forms.Panel grayPanel;
        private System.Windows.Forms.PictureBox forumImage;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox versionBox;
        private System.Windows.Forms.ComboBox versionCbox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.GroupBox driveBox;
        private System.Windows.Forms.ComboBox driveCbox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button formatButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

