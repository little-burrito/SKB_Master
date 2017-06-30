using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Timers;

namespace SKB_Master {
	public class SysTray : ApplicationContext {
		NotifyIcon notifyIcon;
		const double crawlUpdateInterval = 1000.0;
		private static System.Timers.Timer crawlUpdateTimer;

		public SysTray() {
			MenuItem configMenuItem = new MenuItem( "Visa fönster", new EventHandler( ShowMainFormFromContextMenu ) );
			MenuItem exitMenuItem = new MenuItem( "Avsluta", new EventHandler( Exit ) );

			NotifyIcon notifyIcon = new NotifyIcon();
			notifyIcon.Icon = SKB_Master.Properties.Resources.AppIcon;
			notifyIcon.ContextMenu = new ContextMenu( new MenuItem[] { configMenuItem, exitMenuItem } );
			notifyIcon.Visible = true;
			notifyIcon.MouseDoubleClick += ShowMainFormFromDoubleClick;

			if ( Properties.Settings.Default.username == "" ||
				 Properties.Settings.Default.password == "" ) {
				UserCredentials userCredentials = new UserCredentials();
				userCredentials.ShowDialog();
			}

			crawlUpdateTimer = new System.Timers.Timer( crawlUpdateInterval );
			crawlUpdateTimer.Interval = crawlUpdateInterval;
			crawlUpdateTimer.Enabled = true;
			crawlUpdateTimer.Elapsed += updateSKB;
		}

		MainForm mainForm = new MainForm();
		void ShowMainForm() {
			// If we are already showing the window, merely focus it.
			if ( mainForm.Visible ) {
				mainForm.Activate();
			} else {
				mainForm.ShowDialog();
			}
		}

		void ShowMainFormFromContextMenu( object sender, EventArgs e ) {
			ShowMainForm();
		}

		void ShowMainFormFromDoubleClick( object sender, MouseEventArgs e ) {
			ShowMainForm();
		}

		void updateSKB( object sender, System.Timers.ElapsedEventArgs e ) {
			if ( mainForm != null ) {
				mainForm.UpdateUICrawlerResult( System.DateTime.Now.TimeOfDay.ToString(), 100 );
			}
		}

		void Exit( object sender, EventArgs e ) {
			// We must manually tidy up and remove the icon before we exit.
			// Otherwise it will be left behind until the user mouses over.
			if ( notifyIcon != null ) {
				notifyIcon.Visible = false;
			}
			Application.Exit();
		}
	}
}
