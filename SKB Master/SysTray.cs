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
        private Log log;

		public SysTray() {
            log = new Log( this.GetType().Name );
            log.AddLog( "Initializing SysTray" );

			MenuItem configMenuItem = new MenuItem( "Visa fönster", new EventHandler( ShowMainFormFromContextMenu ) );
			MenuItem exitMenuItem = new MenuItem( "Avsluta", new EventHandler( Exit ) );

			notifyIcon = new NotifyIcon();
			notifyIcon.Icon = SKB_Master.Properties.Resources.AppIcon;
            notifyIcon.Text = "SKB Master";
			notifyIcon.ContextMenu = new ContextMenu( new MenuItem[] { configMenuItem, exitMenuItem } );
			notifyIcon.Visible = true;
			notifyIcon.MouseDoubleClick += ShowMainFormFromDoubleClick;

            // TODO: This should be run from here
            // Scraper scraper = new SKB_Master.Scraper( mainForm ); // Starts immediately
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

		void Exit( object sender, EventArgs e ) {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            log.AddLog( "Graceful shutdown" );
            mainForm.CloseAllTrayIcons();
			if ( notifyIcon != null ) {
				notifyIcon.Visible = false;
                notifyIcon.Dispose();
			}
			Application.Exit();
		}
	}
}
