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
            this.errorLabel = new System.Windows.Forms.Label();
            this.successLabel = new System.Windows.Forms.Label();
            this.credentialsFormButton = new System.Windows.Forms.Button();
            this.statusProgressBar = new System.Windows.Forms.ProgressBar();
            this.status = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(9, 325);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(262, 13);
            this.errorLabel.TabIndex = 0;
            this.errorLabel.Text = "label1";
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // successLabel
            // 
            this.successLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.successLabel.ForeColor = System.Drawing.Color.Green;
            this.successLabel.Location = new System.Drawing.Point(12, 325);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(262, 13);
            this.successLabel.TabIndex = 1;
            this.successLabel.Text = "label2";
            this.successLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // credentialsFormButton
            // 
            this.credentialsFormButton.Location = new System.Drawing.Point(74, 356);
            this.credentialsFormButton.Name = "credentialsFormButton";
            this.credentialsFormButton.Size = new System.Drawing.Size(137, 23);
            this.credentialsFormButton.TabIndex = 2;
            this.credentialsFormButton.Text = "&Inloggningsuppgifter";
            this.credentialsFormButton.UseVisualStyleBackColor = true;
            this.credentialsFormButton.Click += new System.EventHandler(this.credentialsFormButton_Click);
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Location = new System.Drawing.Point(12, 405);
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(262, 23);
            this.statusProgressBar.TabIndex = 4;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(12, 431);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(40, 13);
            this.status.TabIndex = 5;
            this.status.Text = "Status:";
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("Logo.InitialImage")));
            this.Logo.Location = new System.Drawing.Point(12, 12);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(262, 290);
            this.Logo.TabIndex = 6;
            this.Logo.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(287, 453);
            this.Controls.Add(this.status);
            this.Controls.Add(this.statusProgressBar);
            this.Controls.Add(this.credentialsFormButton);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SKB Master";
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label errorLabel;
		private System.Windows.Forms.Label successLabel;
		private System.Windows.Forms.Button credentialsFormButton;
		private System.Windows.Forms.ProgressBar statusProgressBar;
		private System.Windows.Forms.Label status;
        private System.Windows.Forms.PictureBox Logo;
    }
}

