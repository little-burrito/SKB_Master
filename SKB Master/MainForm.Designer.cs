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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.credentialsFormButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.status = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "label2";
			// 
			// credentialsFormButton
			// 
			this.credentialsFormButton.Location = new System.Drawing.Point(41, 102);
			this.credentialsFormButton.Name = "credentialsFormButton";
			this.credentialsFormButton.Size = new System.Drawing.Size(137, 23);
			this.credentialsFormButton.TabIndex = 2;
			this.credentialsFormButton.Text = "&Inloggningsuppgifter";
			this.credentialsFormButton.UseVisualStyleBackColor = true;
			this.credentialsFormButton.Click += new System.EventHandler(this.credentialsFormButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(120, 52);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "label3";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(92, 163);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(100, 23);
			this.progressBar1.TabIndex = 4;
			// 
			// status
			// 
			this.status.AutoSize = true;
			this.status.Location = new System.Drawing.Point(92, 144);
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(40, 13);
			this.status.TabIndex = 5;
			this.status.Text = "Status:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.status);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.credentialsFormButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "SKB Master";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button credentialsFormButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label status;
	}
}

