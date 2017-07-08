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

    public partial class MainForm : Form, IUpdateUI {
        private Scraper scraper;
        private List<Offer> activeOffersLoaded;
        private List<Offer> inactiveOffersLoaded;
        private List<NotifyIcon> placementChangedNotifyIcons;
        private List<NotifyIcon> activeChangedNotifyIcons;
        private List<NotifyIcon> newOfferNotifyIcons;
        private List<NotifyIcon> canReplyNotifyIcons;

        public MainForm() {
            InitializeComponent();
            clearErrorAndSuccess();
            placementChangedNotifyIcons = new List<NotifyIcon>();
            activeChangedNotifyIcons = new List<NotifyIcon>();
            newOfferNotifyIcons = new List<NotifyIcon>();
            canReplyNotifyIcons = new List<NotifyIcon>();
            activeOffersLoaded = new List<Offer>();
            inactiveOffersLoaded = new List<Offer>();
            estimatedInterestInput.Value = ( decimal )( Properties.Settings.Default.estimatedInterestMultiplier * 100.0 );
            if ( Properties.Settings.Default.username == "" ||
                 Properties.Settings.Default.password == "" ) {
                showUserCredentialsForm();
                tabControl.SelectTab( optionsTabPage );
                UpdateUIUserCredentials();
            }
            advancedView.setMainForm( this );
            // TODO: This should be run from SysTray, not from the MainForm
            scraper = new SKB_Master.Scraper( this ); // Starts immediately
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
            if ( advancedView != null ) {
                advancedView.LoadNewLogItems();
            }
            scraper = new Scraper( this ); // Restart scraper
        }
        delegate void UpdateStatusCallback( string statusString, ushort progress ); // Thread safe
        public void UpdateStatus( string statusString, ushort progress ) {
            if ( InvokeRequired ) {
                UpdateStatusCallback d = new UpdateStatusCallback( UpdateStatus );
                Invoke( d, new object[] { statusString, progress } );
            } else {
                status.Text = statusString;
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

        delegate void UncheckAdvancedViewCallback();
        public void UncheckAdvancedView() {
            if ( InvokeRequired ) {
                UncheckAdvancedViewCallback d = new UncheckAdvancedViewCallback( UncheckAdvancedView );
                Invoke( d, new object[] { } );
            } else {
                advancedCheckbox.Checked = false;
            }
        }

        AdvancedView advancedView = new AdvancedView();
        private void advancedCheckbox_CheckedChanged( object sender, EventArgs e ) {
            Properties.Settings.Default.showAdvanced = advancedCheckbox.Checked;
            Properties.Settings.Default.Save();
            showAdvancedViewIfChecked();
        }
        private void showAdvancedViewIfChecked() {
            if ( Properties.Settings.Default.showAdvanced ) {
                if ( advancedView.Visible ) {
                    advancedView.Activate();
                } else {
                    advancedView.Show();
                }
            } else {
                if ( advancedView.Visible ) {
                    advancedView.Hide();
                }
            }
        }

        public void updateAdvancedView() {
            advancedView.LoadNewLogItems();
        }

        private void updateOffers() {
            List<Offer> allOffers = OfferHandler.LoadOffers();
            List<Offer> activeOffers = new List<Offer>();
            List<Offer> inactiveOffers = new List<Offer>();
            foreach ( Offer offer in allOffers ) {
                if ( offer.isActive ) {
                    activeOffers.Add( offer );
                } else {
                    inactiveOffers.Add( offer );
                }
            }
            if ( !offerListsAreEqual( activeOffers, activeOffersLoaded ) ) { // TODO: Should work with List.Equals
                activeOffersFlowLayout.Controls.Clear();
                foreach ( Offer offer in activeOffers ) {
                    ActiveOffer activeOffer = new ActiveOffer( offer );
                    AddActiveOfferToFlowLayoutPanel( activeOffer, activeOffersFlowLayout );
                }
                activeOffersLoaded = activeOffers;
            }
            if ( !offerListsAreEqual( inactiveOffers, inactiveOffersLoaded ) ) { // TODO: Should work with List.Equals
                inactiveOffersFlowLayout.Controls.Clear();
                foreach ( Offer offer in inactiveOffers ) {
                    InactiveOffer inactiveOffer = new InactiveOffer( offer );
                    AddInactiveOfferToFlowLayoutPanel( inactiveOffer, inactiveOffersFlowLayout );
                }
                inactiveOffersLoaded = inactiveOffers;
            }
            updateOffersPadding();
            updateNewOfferNotifyIcons();
            updateCanReplyNotifyIcons();
            updateActiveChangedNotifyIcons();
            updatePlacementChangedNotifyIcons();
        }

        /* delegate void UpdateStatusCallback( string statusString, ushort progress ); // Thread safe
        public void UpdateStatus( string statusString, ushort progress ) {
                UpdateStatusCallback d = new UpdateStatusCallback( UpdateStatus );
                Invoke( d, new object[] { statusString, progress } );
            } else {
                status.Text = statusString;
                statusProgressBar.Value = progress;
                if ( statusProgressBar.Value == 100 ) {
                    statusProgressBar.Visible = false;
                } else {
                    statusProgressBar.Visible = true;
                }
            }
        } */
        delegate void AddActiveOfferToFlowLayoutPanelCallback( ActiveOffer offer, FlowLayoutPanel flowLayoutPanel );
        public void AddActiveOfferToFlowLayoutPanel( ActiveOffer offer, FlowLayoutPanel flowLayoutPanel ) {
            if ( flowLayoutPanel.InvokeRequired ) {
                AddActiveOfferToFlowLayoutPanelCallback d = new AddActiveOfferToFlowLayoutPanelCallback( AddActiveOfferToFlowLayoutPanel );
                Invoke( d, new object[] { offer, flowLayoutPanel } );
            } else {
                flowLayoutPanel.Controls.Add( offer );
            }
        }

        delegate void AddInactiveOfferToFlowLayoutPanelCallback( InactiveOffer offer, FlowLayoutPanel flowLayoutPanel );
        public void AddInactiveOfferToFlowLayoutPanel( InactiveOffer offer, FlowLayoutPanel flowLayoutPanel ) {
            if ( flowLayoutPanel.InvokeRequired ) {
                AddInactiveOfferToFlowLayoutPanelCallback d = new AddInactiveOfferToFlowLayoutPanelCallback( AddInactiveOfferToFlowLayoutPanel );
                Invoke( d, new object[] { offer, flowLayoutPanel } );
            } else {
                flowLayoutPanel.Controls.Add( offer );
            }
        }

        private bool offerListsAreEqual( List<Offer> first, List<Offer> second ) { // TODO: Close enough. Should work with List<Offer>.Equals, but the Serialization() seems to mess that up somehow.
            if ( first.Count != second.Count ) {
                return false;
            }
            foreach ( Offer offer in first ) {
                if ( !second.Contains( offer ) ) {
                    return false;
                }
            }
            foreach ( Offer offer in second ) {
                if ( !first.Contains( offer ) ) {
                    return false;
                }
            }
            return true;
        }

        private void updateOffersPadding() {
            if ( activeOffersFlowLayout.VerticalScroll.Visible ) {
                if ( activeOffersFlowLayout.Padding.Left != 0 ) {
                    activeOffersFlowLayout.Padding = new Padding( 0, activeOffersFlowLayout.Padding.Top, activeOffersFlowLayout.Padding.Right, activeOffersFlowLayout.Padding.Bottom );
                }
            } else {
                if ( activeOffersFlowLayout.Padding.Left != 10 ) {
                    activeOffersFlowLayout.Padding = new Padding( 10, activeOffersFlowLayout.Padding.Top, activeOffersFlowLayout.Padding.Right, activeOffersFlowLayout.Padding.Bottom );
                }
            }
            if ( inactiveOffersFlowLayout.VerticalScroll.Visible ) {
                if ( inactiveOffersFlowLayout.Padding.Left != 0 ) {
                    inactiveOffersFlowLayout.Padding = new Padding( 0, inactiveOffersFlowLayout.Padding.Top, inactiveOffersFlowLayout.Padding.Right, inactiveOffersFlowLayout.Padding.Bottom );
                }
            } else {
                if ( inactiveOffersFlowLayout.Padding.Left != 10 ) {
                    inactiveOffersFlowLayout.Padding = new Padding( 10, inactiveOffersFlowLayout.Padding.Top, inactiveOffersFlowLayout.Padding.Right, inactiveOffersFlowLayout.Padding.Bottom );
                }
            }
        }

        private void updateNewOfferNotifyIcons() {
            foreach ( Offer offer in activeOffersLoaded ) {
                if ( offer.showNewOfferNotice ) {
                    if ( !offer.closedNewOfferNotice ) {
                        bool isAlreadyBeingShown = false;
                        foreach ( NotifyIcon notifyIcon in newOfferNotifyIcons ) {
                            if ( notifyIcon.Tag.ToString() == offer.name ) {
                                isAlreadyBeingShown = true;
                                break;
                            }
                        }
                        if ( !isAlreadyBeingShown ) {
                            NotifyIcon notifyIcon = new NotifyIcon();
                            notifyIcon.Icon = SKB_Master.Properties.Resources.AppIconNewOffer;
                            notifyIcon.Visible = true;
                            notifyIcon.Text = truncateString( "Nytt erbjudande! " + offer.name, 60 );
                            notifyIcon.Tag = offer.name;
                            notifyIcon.Click += newOfferNoticeClicked;
                            newOfferNotifyIcons.Add( notifyIcon );
                        }
                    }
                }
            }
        }

        private void updateCanReplyNotifyIcons() {
            foreach ( Offer offer in activeOffersLoaded ) {
                if ( offer.showCanReplyNowNotice ) {
                    if ( !offer.closedCanReplyNowNotice ) {
                        bool isAlreadyBeingShown = false;
                        foreach ( NotifyIcon notifyIcon in canReplyNotifyIcons ) {
                            if ( notifyIcon.Tag.ToString() == offer.name ) {
                                isAlreadyBeingShown = true;
                                break;
                            }
                        }
                        if ( !isAlreadyBeingShown ) {
                            NotifyIcon notifyIcon = new NotifyIcon();
                            notifyIcon.Icon = SKB_Master.Properties.Resources.AppIconCanReplyNow;
                            notifyIcon.Visible = true;
                            notifyIcon.Text = truncateString( "Nu är det dags att lämna svar om " + offer.name, 60 );
                            notifyIcon.Tag = offer.name;
                            notifyIcon.Click += canReplyNoticeClicked;
                            canReplyNotifyIcons.Add( notifyIcon );
                        }
                    }
                }
            }
        }

        private void updateActiveChangedNotifyIcons() {
            foreach ( Offer offer in inactiveOffersLoaded ) {
                if ( offer.showActiveChangedNotice ) {
                    if ( !offer.closedActiveChangedNotice ) {
                        bool isAlreadyBeingShown = false;
                        foreach ( NotifyIcon notifyIcon in activeChangedNotifyIcons ) {
                            if ( notifyIcon.Tag.ToString() == offer.name ) {
                                isAlreadyBeingShown = true;
                                break;
                            }
                        }
                        if ( !isAlreadyBeingShown ) {
                            NotifyIcon notifyIcon = new NotifyIcon();
                            notifyIcon.Icon = SKB_Master.Properties.Resources.AppIconActiveChanged;
                            notifyIcon.Visible = true;
                            notifyIcon.Text = truncateString( "Lägenheten blev uthyrd. " + offer.name, 60 );
                            notifyIcon.Tag = offer.name;
                            notifyIcon.Click += activeChangedNoticeClicked;
                            activeChangedNotifyIcons.Add( notifyIcon );
                        }
                    }
                }
            }
        }

        private void updatePlacementChangedNotifyIcons() {
            foreach ( Offer offer in activeOffersLoaded ) {
                if ( offer.showPlacementChangedNotice ) {
                    if ( !offer.closedPlacementChangedNotice ) {
                        bool isAlreadyBeingShown = false;
                        foreach ( NotifyIcon notifyIcon in placementChangedNotifyIcons ) {
                            if ( notifyIcon.Tag.ToString() == offer.name ) {
                                isAlreadyBeingShown = true;
                                notifyIcon.Text = truncateString( "Din köplats är nu " + offer.placementInQueue + " av " + offer.peopleInQueue + " till " + offer.name, 60 );
                                notifyIcon.Visible = true;
                                break;
                            }
                        }
                        if ( !isAlreadyBeingShown ) {
                            NotifyIcon notifyIcon = new NotifyIcon();
                            notifyIcon.Icon = SKB_Master.Properties.Resources.AppIconPlacementChanged;
                            notifyIcon.Visible = true;
                            notifyIcon.Text = truncateString( "Din köplats är nu " + offer.placementInQueue + " av " + offer.peopleInQueue + " till " + offer.name, 60 );
                            notifyIcon.Tag = offer.name;
                            notifyIcon.Click += placementChangedNoticeClicked;
                            placementChangedNotifyIcons.Add( notifyIcon );
                        }
                    }
                }
            }
        }

        private void newOfferNoticeClicked( object sender, EventArgs e ) {
            NotifyIcon notifyIcon = sender as NotifyIcon;
            List<Offer> offers = OfferHandler.LoadOffers();
            foreach ( Offer offer in offers ) {
                if ( offer.name == notifyIcon.Tag.ToString() ) {
                    offer.closedNewOfferNotice = true;
                    OfferHandler.SaveOffers( offers );
                    notifyIcon.Visible = false;
                    notifyIcon.Dispose();
                    tabControl.SelectTab( activeOffersTabPage );
                    ShowOrActivate();
                    break;
                }
            }
        }

        private void canReplyNoticeClicked( object sender, EventArgs e ) {
            NotifyIcon notifyIcon = sender as NotifyIcon;
            List<Offer> offers = OfferHandler.LoadOffers();
            foreach ( Offer offer in offers ) {
                if ( offer.name == notifyIcon.Tag.ToString() ) {
                    offer.closedCanReplyNowNotice = true;
                    OfferHandler.SaveOffers( offers );
                    notifyIcon.Visible = false;
                    notifyIcon.Dispose();
                    tabControl.SelectTab( activeOffersTabPage );
                    ShowOrActivate();
                    break;
                }
            }
        }

        private void activeChangedNoticeClicked( object sender, EventArgs e ) {
            NotifyIcon notifyIcon = sender as NotifyIcon;
            List<Offer> offers = OfferHandler.LoadOffers();
            foreach ( Offer offer in offers ) {
                if ( offer.name == notifyIcon.Tag.ToString() ) {
                    offer.closedActiveChangedNotice = true;
                    OfferHandler.SaveOffers( offers );
                    notifyIcon.Visible = false;
                    notifyIcon.Dispose();
                    tabControl.SelectTab( inactiveOffersTabPage );
                    ShowOrActivate();
                    break;
                }
            }
        }

        private void placementChangedNoticeClicked( object sender, EventArgs e ) {
            NotifyIcon notifyIcon = sender as NotifyIcon;
            List<Offer> offers = OfferHandler.LoadOffers();
            foreach ( Offer offer in offers ) {
                if ( offer.name == notifyIcon.Tag.ToString() ) {
                    offer.closedPlacementChangedNotice = true;
                    OfferHandler.SaveOffers( offers );
                    notifyIcon.Visible = false;
                    // notifyIcon.Dispose(); // Don't dispose, because this might be reused.
                    tabControl.SelectTab( activeOffersTabPage );
                    ShowOrActivate();
                    break;
                }
            }
        }

        public void UpdateUI() {
            if ( InvokeRequired ) {
                UpdateUICallback d = new UpdateUICallback( UpdateUI );
                Invoke( d, new object[] { } );
            } else {
                UpdateStatus( status.Text, ( ushort )statusProgressBar.Value );
                if ( advancedView != null ) {
                    advancedView.UpdateUI();
                }
                updateOffers();
                // This overwrites changes if you're working on it:
                // estimatedInterestInput.Value = ( decimal )( Properties.Settings.Default.estimatedInterestMultiplier * 100.0 );
            }
        }

        public void CloseAllTrayIcons() {
            foreach ( NotifyIcon icon in activeChangedNotifyIcons ) {
                icon.Visible = false;
                icon.Dispose();
            }
            foreach ( NotifyIcon icon in canReplyNotifyIcons ) {
                icon.Visible = false;
                icon.Dispose();
            }
            foreach ( NotifyIcon icon in newOfferNotifyIcons ) {
                icon.Visible = false;
                icon.Dispose();
            }
            foreach ( NotifyIcon icon in placementChangedNotifyIcons ) {
                icon.Visible = false;
                icon.Dispose();
            }
        }

        private void saveEstimatedInterestButton_Click( object sender, EventArgs e ) {
            Properties.Settings.Default.estimatedInterestMultiplier = ( double )estimatedInterestInput.Value / 100.0;
            Properties.Settings.Default.Save();
            UpdateUI();
        }

        public void ShowOrActivate() {
			if ( Visible ) {
				Activate();
			} else {
				ShowDialog();
			}
        }

        private static string truncateString( string value, int maxChars ) {
            return value.Length <= maxChars ? value : value.Substring( 0, maxChars ) + "...";
        }
    }
}
