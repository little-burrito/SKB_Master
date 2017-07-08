namespace SKB_Master {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusProgressBar = new System.Windows.Forms.ProgressBar();
            this.status = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.activeOffersTabPage = new System.Windows.Forms.TabPage();
            this.activeOffersFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.inactiveOffersTabPage = new System.Windows.Forms.TabPage();
            this.inactiveOffersFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.optionsTabPage = new System.Windows.Forms.TabPage();
            this.estimatedInterestInput = new System.Windows.Forms.NumericUpDown();
            this.interestPercentageSignLabel = new System.Windows.Forms.Label();
            this.estimatedInterestLabel = new System.Windows.Forms.Label();
            this.saveEstimatedInterestButton = new System.Windows.Forms.Button();
            this.advancedCheckbox = new System.Windows.Forms.CheckBox();
            this.credentialsFormButton = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.successLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.statusTitleLabel = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.activeOffersTabPage.SuspendLayout();
            this.inactiveOffersTabPage.SuspendLayout();
            this.optionsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estimatedInterestInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusProgressBar.Location = new System.Drawing.Point(12, 413);
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(262, 23);
            this.statusProgressBar.TabIndex = 4;
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(49, 439);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(35, 13);
            this.status.TabIndex = 5;
            this.status.Text = "status";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.activeOffersTabPage);
            this.tabControl.Controls.Add(this.inactiveOffersTabPage);
            this.tabControl.Controls.Add(this.optionsTabPage);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(287, 389);
            this.tabControl.TabIndex = 8;
            // 
            // activeOffersTabPage
            // 
            this.activeOffersTabPage.Controls.Add(this.activeOffersFlowLayout);
            this.activeOffersTabPage.Location = new System.Drawing.Point(4, 22);
            this.activeOffersTabPage.Name = "activeOffersTabPage";
            this.activeOffersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.activeOffersTabPage.Size = new System.Drawing.Size(279, 365);
            this.activeOffersTabPage.TabIndex = 0;
            this.activeOffersTabPage.Text = "Erbjudanden nu";
            this.activeOffersTabPage.UseVisualStyleBackColor = true;
            // 
            // activeOffersFlowLayout
            // 
            this.activeOffersFlowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.activeOffersFlowLayout.AutoScroll = true;
            this.activeOffersFlowLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.activeOffersFlowLayout.Location = new System.Drawing.Point(0, 0);
            this.activeOffersFlowLayout.Name = "activeOffersFlowLayout";
            this.activeOffersFlowLayout.Padding = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.activeOffersFlowLayout.Size = new System.Drawing.Size(279, 421);
            this.activeOffersFlowLayout.TabIndex = 0;
            // 
            // inactiveOffersTabPage
            // 
            this.inactiveOffersTabPage.Controls.Add(this.inactiveOffersFlowLayout);
            this.inactiveOffersTabPage.Location = new System.Drawing.Point(4, 22);
            this.inactiveOffersTabPage.Name = "inactiveOffersTabPage";
            this.inactiveOffersTabPage.Size = new System.Drawing.Size(279, 353);
            this.inactiveOffersTabPage.TabIndex = 2;
            this.inactiveOffersTabPage.Text = "Gamla erbjudanden";
            this.inactiveOffersTabPage.UseVisualStyleBackColor = true;
            // 
            // inactiveOffersFlowLayout
            // 
            this.inactiveOffersFlowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.inactiveOffersFlowLayout.AutoScroll = true;
            this.inactiveOffersFlowLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.inactiveOffersFlowLayout.Location = new System.Drawing.Point(0, 0);
            this.inactiveOffersFlowLayout.Name = "inactiveOffersFlowLayout";
            this.inactiveOffersFlowLayout.Padding = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.inactiveOffersFlowLayout.Size = new System.Drawing.Size(279, 876);
            this.inactiveOffersFlowLayout.TabIndex = 0;
            // 
            // optionsTabPage
            // 
            this.optionsTabPage.Controls.Add(this.estimatedInterestInput);
            this.optionsTabPage.Controls.Add(this.interestPercentageSignLabel);
            this.optionsTabPage.Controls.Add(this.estimatedInterestLabel);
            this.optionsTabPage.Controls.Add(this.saveEstimatedInterestButton);
            this.optionsTabPage.Controls.Add(this.advancedCheckbox);
            this.optionsTabPage.Controls.Add(this.credentialsFormButton);
            this.optionsTabPage.Controls.Add(this.Logo);
            this.optionsTabPage.Location = new System.Drawing.Point(4, 22);
            this.optionsTabPage.Name = "optionsTabPage";
            this.optionsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.optionsTabPage.Size = new System.Drawing.Size(279, 363);
            this.optionsTabPage.TabIndex = 1;
            this.optionsTabPage.Text = "Inställningar";
            this.optionsTabPage.UseVisualStyleBackColor = true;
            // 
            // estimatedInterestInput
            // 
            this.estimatedInterestInput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.estimatedInterestInput.DecimalPlaces = 3;
            this.estimatedInterestInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.estimatedInterestInput.Location = new System.Drawing.Point(94, 329);
            this.estimatedInterestInput.Name = "estimatedInterestInput";
            this.estimatedInterestInput.Size = new System.Drawing.Size(60, 20);
            this.estimatedInterestInput.TabIndex = 13;
            this.estimatedInterestInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.estimatedInterestInput.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // interestPercentageSignLabel
            // 
            this.interestPercentageSignLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.interestPercentageSignLabel.AutoSize = true;
            this.interestPercentageSignLabel.Location = new System.Drawing.Point(153, 332);
            this.interestPercentageSignLabel.Name = "interestPercentageSignLabel";
            this.interestPercentageSignLabel.Size = new System.Drawing.Size(15, 13);
            this.interestPercentageSignLabel.TabIndex = 16;
            this.interestPercentageSignLabel.Text = "%";
            // 
            // estimatedInterestLabel
            // 
            this.estimatedInterestLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.estimatedInterestLabel.AutoSize = true;
            this.estimatedInterestLabel.Location = new System.Drawing.Point(27, 332);
            this.estimatedInterestLabel.Name = "estimatedInterestLabel";
            this.estimatedInterestLabel.Size = new System.Drawing.Size(61, 13);
            this.estimatedInterestLabel.TabIndex = 15;
            this.estimatedInterestLabel.Text = "Ränta/mån";
            // 
            // saveEstimatedInterestButton
            // 
            this.saveEstimatedInterestButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.saveEstimatedInterestButton.Location = new System.Drawing.Point(174, 327);
            this.saveEstimatedInterestButton.Name = "saveEstimatedInterestButton";
            this.saveEstimatedInterestButton.Size = new System.Drawing.Size(75, 23);
            this.saveEstimatedInterestButton.TabIndex = 14;
            this.saveEstimatedInterestButton.Text = "&Spara ränta";
            this.saveEstimatedInterestButton.UseVisualStyleBackColor = true;
            this.saveEstimatedInterestButton.Click += new System.EventHandler(this.saveEstimatedInterestButton_Click);
            // 
            // advancedCheckbox
            // 
            this.advancedCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.advancedCheckbox.AutoSize = true;
            this.advancedCheckbox.Location = new System.Drawing.Point(174, 304);
            this.advancedCheckbox.Name = "advancedCheckbox";
            this.advancedCheckbox.Size = new System.Drawing.Size(75, 17);
            this.advancedCheckbox.TabIndex = 12;
            this.advancedCheckbox.Text = "&Avancerat";
            this.advancedCheckbox.UseVisualStyleBackColor = true;
            this.advancedCheckbox.CheckedChanged += new System.EventHandler(this.advancedCheckbox_CheckedChanged);
            // 
            // credentialsFormButton
            // 
            this.credentialsFormButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.credentialsFormButton.Location = new System.Drawing.Point(30, 300);
            this.credentialsFormButton.Name = "credentialsFormButton";
            this.credentialsFormButton.Size = new System.Drawing.Size(137, 23);
            this.credentialsFormButton.TabIndex = 10;
            this.credentialsFormButton.Text = "&Inloggningsuppgifter";
            this.credentialsFormButton.UseVisualStyleBackColor = true;
            this.credentialsFormButton.Click += new System.EventHandler(this.credentialsFormButton_Click);
            // 
            // Logo
            // 
            this.Logo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("Logo.InitialImage")));
            this.Logo.Location = new System.Drawing.Point(8, 3);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(262, 290);
            this.Logo.TabIndex = 11;
            this.Logo.TabStop = false;
            // 
            // successLabel
            // 
            this.successLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.successLabel.BackColor = System.Drawing.Color.Transparent;
            this.successLabel.ForeColor = System.Drawing.Color.Green;
            this.successLabel.Location = new System.Drawing.Point(13, 394);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(262, 13);
            this.successLabel.TabIndex = 10;
            this.successLabel.Text = "Successes";
            this.successLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(12, 394);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(262, 13);
            this.errorLabel.TabIndex = 11;
            this.errorLabel.Text = "Errors";
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusTitleLabel
            // 
            this.statusTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusTitleLabel.AutoSize = true;
            this.statusTitleLabel.Location = new System.Drawing.Point(12, 439);
            this.statusTitleLabel.Name = "statusTitleLabel";
            this.statusTitleLabel.Size = new System.Drawing.Size(40, 13);
            this.statusTitleLabel.TabIndex = 12;
            this.statusTitleLabel.Text = "Status:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(287, 461);
            this.Controls.Add(this.statusTitleLabel);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.status);
            this.Controls.Add(this.statusProgressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(303, 10000);
            this.MinimumSize = new System.Drawing.Size(303, 500);
            this.Name = "MainForm";
            this.Text = "SKB Master";
            this.tabControl.ResumeLayout(false);
            this.activeOffersTabPage.ResumeLayout(false);
            this.inactiveOffersTabPage.ResumeLayout(false);
            this.optionsTabPage.ResumeLayout(false);
            this.optionsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estimatedInterestInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ProgressBar statusProgressBar;
		private System.Windows.Forms.Label status;
        private System.Windows.Forms.TabPage activeOffersTabPage;
        private System.Windows.Forms.TabPage optionsTabPage;
        private System.Windows.Forms.CheckBox advancedCheckbox;
        private System.Windows.Forms.Button credentialsFormButton;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label successLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage inactiveOffersTabPage;
        private System.Windows.Forms.FlowLayoutPanel activeOffersFlowLayout;
        private System.Windows.Forms.FlowLayoutPanel inactiveOffersFlowLayout;
        private System.Windows.Forms.NumericUpDown estimatedInterestInput;
        private System.Windows.Forms.Label interestPercentageSignLabel;
        private System.Windows.Forms.Label estimatedInterestLabel;
        private System.Windows.Forms.Button saveEstimatedInterestButton;
        private System.Windows.Forms.Label statusTitleLabel;
    }
}

