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
    public partial class AdvancedView : Form, IUpdateUI {
        MainForm mainForm;
        Log log;
        List<LogPost> logPostsAlreadyLoaded;

        public AdvancedView() {
            InitializeComponent();
            log = new SKB_Master.Log( this.GetType().Name );
            logPostsAlreadyLoaded = new List<LogPost>();
            initializeLogListView();
            LoadNewLogItems();
        }

        void initializeLogListView() {
            logListView.View = View.Details;
            logListView.AllowColumnReorder = true;
            logListView.FullRowSelect = true;
            logListView.Sorting = SortOrder.Descending;

            logListView.Columns.Add( "Time", 150, HorizontalAlignment.Left );
            logListView.Columns.Add( "Reporting Class", -2, HorizontalAlignment.Left );
            logListView.Columns.Add( "Status", 250, HorizontalAlignment.Left );
            logListView.Columns.Add( "Details", 700, HorizontalAlignment.Left );
        }

        public void setMainForm( MainForm mainForm ) {
            this.mainForm = mainForm;
        }

        public void LoadNewLogItems() {
            List<LogPost> newLogPosts = getNewLogPosts();
            List<ListViewItem> listViewItems = convertLogPostsToListViewItems( newLogPosts );
            logListView.Items.AddRange( listViewItems.ToArray() );
        }

        private List<LogPost> getNewLogPosts() {
            List<LogPost> logPosts = log.getLog();
            if ( logPosts == null ) {
                logPosts = new List<LogPost>();
            }
            // TODO: Figure out why logPosts.Except stopped working when I made LogPost Serializeable and started saving to and loading from a file.
            // It doesn't even run the IEquatable or or IEqualityComparer methods on LogPost...
            // List<LogPost> newLogPosts = logPosts.Except( logPostsAlreadyLoaded ).ToList();
            List<LogPost> newLogPosts = logPosts;
            foreach ( LogPost logPost in logPostsAlreadyLoaded ) {
                newLogPosts.Remove( logPost );
            }
            logPostsAlreadyLoaded.AddRange( newLogPosts );
            return newLogPosts;
        }

        private List<ListViewItem> convertLogPostsToListViewItems( List<LogPost> logList ) {
            List<ListViewItem> items = new List<ListViewItem>();
            if ( logList != null ) {
                foreach ( LogPost post in logList ) {
                    ListViewItem item = new ListViewItem( new[] { post.timeStamp, post.reportingClass, post.status, post.details } );
                    items.Add( item );
                }
            }
            return items;
        }

        protected override void OnFormClosing( FormClosingEventArgs e ) {
            base.OnFormClosing( e );
            if ( e.CloseReason == CloseReason.UserClosing ) {
                e.Cancel = true;
                Hide();
            }
            mainForm.UncheckAdvancedView(); // TODO: Should be an event
        }

        protected override bool ProcessDialogKey( Keys keyData ) {
            if ( ModifierKeys == Keys.None && keyData == Keys.Escape ) {
                Close();
                return true;
            }
            return base.ProcessDialogKey( keyData );
        }

        public void UpdateUI() {
            if ( InvokeRequired ) {
                UpdateUICallback d = new UpdateUICallback( UpdateUI );
                Invoke( d, new object[] { } );
            } else {
                LoadNewLogItems();
            }
        }
    }
}
