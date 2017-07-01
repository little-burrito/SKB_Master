using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Timers;
using System.Net;

namespace SKB_Master {
	public class SysTray : ApplicationContext {
		NotifyIcon notifyIcon;
		const double crawlUpdateInterval = 60000.0; // Milliseconds
		private static System.Timers.Timer crawlUpdateTimer;
        private static string loginUrl = "https://www.skb.org/login/";
        private static string queuePositionsUrl = "https://www.skb.org/mina-sidor/mina-intresseanmalningar/mina-kallelser/";
        private static string loggedInClass = "Loggedin";
        private static string notLoggedInClass = "NotLoggedin";

		public SysTray() {
			MenuItem configMenuItem = new MenuItem( "Visa fönster", new EventHandler( ShowMainFormFromContextMenu ) );
			MenuItem exitMenuItem = new MenuItem( "Avsluta", new EventHandler( Exit ) );

			notifyIcon = new NotifyIcon();
			notifyIcon.Icon = SKB_Master.Properties.Resources.AppIcon;
			notifyIcon.ContextMenu = new ContextMenu( new MenuItem[] { configMenuItem, exitMenuItem } );
			notifyIcon.Visible = true;
			notifyIcon.MouseDoubleClick += ShowMainFormFromDoubleClick;

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
            mainForm.UpdateUICrawlerResult( "Starting crawl", 0 );

            HttpWebRequest request = ( HttpWebRequest )WebRequest.Create( loginUrl );

            if ( mainForm != null ) {
				mainForm.UpdateUICrawlerResult( System.DateTime.Now.TimeOfDay.ToString(), 55 );
			}
		}

		void Exit( object sender, EventArgs e ) {
			// We must manually tidy up and remove the icon before we exit.
			// Otherwise it will be left behind until the user mouses over.
			if ( notifyIcon != null ) {
				notifyIcon.Visible = false;
                notifyIcon.Dispose();
			}
			Application.Exit();
		}
	}
}
