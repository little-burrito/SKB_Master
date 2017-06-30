using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKB_Master {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
			if ( Properties.Settings.Default.username == "" ||
				 Properties.Settings.Default.password == "" ) {
				showUserCredentialsForm();
			} else {
				UpdateUIUserCredentials();
			}
		}


		public void UpdateUIUserCredentials() { // Thread unsafe
			label1.Text = Properties.Settings.Default.username;
			label2.Text = Properties.Settings.Default.password;
		}
		delegate void UpdateUICrawlerResultCallback( string randomText, ushort progress ); // Thread safe
		public void UpdateUICrawlerResult( string randomText, ushort progress ) {
			if ( label3.InvokeRequired ) {
				UpdateUICrawlerResultCallback d = new UpdateUICrawlerResultCallback( UpdateUICrawlerResult );
				this.Invoke( d, new object[] { randomText, progress } );
			} else {
				label3.Text = randomText;
				progressBar1.Value = progress;
				if ( progressBar1.Value == 100 ) {
					progressBar1.Visible = false;
				} else {
					progressBar1.Visible = true;
				}
			}
		}

		private void credentialsFormButton_Click( object sender, EventArgs e ) {
			showUserCredentialsForm();
		}

		private void showUserCredentialsForm() {
			UserCredentials userCredentials = new UserCredentials();
			userCredentials.setMainForm( this );
			userCredentials.Show();
		}

		protected override bool ProcessDialogKey( Keys keyData ) {
			if ( ModifierKeys == Keys.None && keyData == Keys.Escape ) {
				Close();
				return true;
			}
			return base.ProcessDialogKey( keyData );
		}
	}
}
