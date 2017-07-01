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
            clearErrorAndSuccess();
			if ( Properties.Settings.Default.username == "" ||
				 Properties.Settings.Default.password == "" ) {
                showUserCredentialsForm();
                UpdateUIUserCredentials();
            }
        }

        delegate void showSuccessCallback( string successText );
        public void showSuccess( string successText ) {
            if ( InvokeRequired ) {
                showSuccessCallback d = new showSuccessCallback( showSuccess );
                Invoke( d, new object[] { successText } );
            } else {
                errorLabel.Visible = false;
                successLabel.Text = successText;
                successLabel.Visible = true;
            }
        }

        delegate void showErrorCallback( string errorText );
        public void showError( string errorText ) {
            if ( InvokeRequired ) {
                showErrorCallback d = new showErrorCallback( showError );
                Invoke( d, new object[] { errorText } );
            } else {
                successLabel.Visible = false;
                errorLabel.Text = errorText;
                errorLabel.Visible = true;
            }
        }

        delegate void clearErrorAndSuccessCallback();
        public void clearErrorAndSuccess() {
            if ( InvokeRequired ) {
                clearErrorAndSuccessCallback d = new clearErrorAndSuccessCallback( clearErrorAndSuccess );
                Invoke( d, new object[] { } );
            } else {
                errorLabel.Visible = false;
                successLabel.Visible = false;
            }
        }


		public void UpdateUIUserCredentials() { // Thread unsafe
            if ( Properties.Settings.Default.username == "" ||
				 Properties.Settings.Default.password == "" ) {
                showError( "Inget användarnamn/lösenord ifyllt" );
            } else {
                showSuccess( "Användarnamn och lösenord har uppdaterats" );
            }
		}
		delegate void UpdateUICrawlerResultCallback( string statusString, ushort progress ); // Thread safe
		public void UpdateUICrawlerResult( string statusString, ushort progress ) {
			if ( InvokeRequired ) {
				UpdateUICrawlerResultCallback d = new UpdateUICrawlerResultCallback( UpdateUICrawlerResult );
				Invoke( d, new object[] { statusString, progress } );
			} else {
				status.Text = "Status: " + statusString;
				statusProgressBar.Value = progress;
				if ( statusProgressBar.Value == 100 ) {
					statusProgressBar.Visible = false;
				} else {
					statusProgressBar.Visible = true;
				}
			}
		}

		private void credentialsFormButton_Click( object sender, EventArgs e ) {
			showUserCredentialsForm();
		}

        UserCredentials userCredentials = new UserCredentials();
        private void showUserCredentialsForm() {
			userCredentials.setMainForm( this );
            if ( userCredentials.Visible ) {
                userCredentials.Activate();
            } else {
                userCredentials.ShowDialog();
            }
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
