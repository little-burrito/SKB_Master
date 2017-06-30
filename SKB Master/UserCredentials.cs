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
	public partial class UserCredentials : Form {

		private MainForm mainForm;

		public UserCredentials() {
			InitializeComponent();
			username.Text = Properties.Settings.Default.username;
			password.Text = Properties.Settings.Default.password;
		}

		private void UserCredentials_Load( object sender, EventArgs e ) {
		}

		private void save_Click( object sender, EventArgs e ) {
			Properties.Settings.Default.username = username.Text;
			Properties.Settings.Default.password = password.Text; // TODO: THIS IS SAVED IN PLAIN-TEXT
			Properties.Settings.Default.Save();
			if ( mainForm != null ) {
				mainForm.UpdateUIUserCredentials();
			}
			Close();
		}

		private void cancel_Click( object sender, EventArgs e ) {
			Close();
		}

		public void setMainForm( MainForm mainForm ) {
			this.mainForm = mainForm;
		}
	}
}
