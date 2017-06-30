namespace SKB_Master {
	partial class UserCredentials {
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
			this.username = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.save = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Användarnamn";
			// 
			// username
			// 
			this.username.Location = new System.Drawing.Point(13, 26);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(156, 20);
			this.username.TabIndex = 1;
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(13, 66);
			this.password.Name = "password";
			this.password.Size = new System.Drawing.Size(156, 20);
			this.password.TabIndex = 2;
			this.password.UseSystemPasswordChar = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Lösenord";
			// 
			// save
			// 
			this.save.Location = new System.Drawing.Point(13, 93);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(75, 23);
			this.save.TabIndex = 3;
			this.save.Text = "&Spara";
			this.save.UseVisualStyleBackColor = true;
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(94, 93);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 4;
			this.cancel.Text = "&Avbryt";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// UserCredentials
			// 
			this.AcceptButton = this.save;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(184, 129);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.save);
			this.Controls.Add(this.password);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.username);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "UserCredentials";
			this.Text = "Inloggningsuppgifter";
			this.Load += new System.EventHandler(this.UserCredentials_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox username;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Button cancel;
	}
}