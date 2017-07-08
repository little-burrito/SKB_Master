using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKB_Master {
    class Scraper {
        private MainForm mainForm; // To update the UI
        private WebBrowser webBrowser;
        static double scrapeUpdateInterval = Properties.Settings.Default.DEBUG ?
            10000.0
            :
            Properties.Settings.Default.scrapeUpdateMillisecondInterval;
		private static System.Timers.Timer scrapeUpdateTimer;
        private Log log;
        private Dictionary<string, Action> webPageHandlers;
        private HtmlDocument currentDocument;

        private static string loggedInClassName = "UserInfo Loggedin";
        private static string notLoggedInClassName = "UserInfo NotLoggedin";

        private static string loginUrl = Properties.Settings.Default.loginUrl;
        private static string loginFormId = "loginform";
        private static string loginFormUsernameId = "user_login";
        private static string loginFormPasswordId = "user_pass";
        private static string loginSuccessfulUrl = Properties.Settings.Default.loginSuccessfulUrl;
        private static string loginFailedUrl = Properties.Settings.Default.loginFailedUrl;

        private static string queuePlacingsUrl = Properties.Settings.Default.DEBUG ?
            "file:///C:/Users/Anton/Desktop/Temp/SKB Mina kallelser en man kan tacka ja-nej till och en man inte kan/Mina kallelser _ SKB.htm"
            :
            Properties.Settings.Default.queuePlacingsUrl;
        private static string queuePlacingsNotLoadedClassName = "f2-widget Loading Kapitel Erbjudanden";
        private static string queuePlacingsLoadedClassName = "f2-widget Kapitel Erbjudanden";

        private enum ProgressId {
            initializingScraper,
            scraperStart,
            loadingLoginPage,
            handleLogin,
            loginSuccessful,
            loginFailed,
            requestQueuePlacings,
            extractQueueDataAttempt,
            extractQueueDataFailed,
            extractQueueDataSuccessful,
            done,
            unknownUrl
        };
        private Dictionary<ProgressId, ProgressMessageAndValue> progressUpdate = new Dictionary<ProgressId, ProgressMessageAndValue>() {
            { ProgressId.initializingScraper,       new ProgressMessageAndValue( "Initializing scraper", 100 ) },
            { ProgressId.scraperStart,              new ProgressMessageAndValue( "Starting scraping", 0 ) },
            { ProgressId.loadingLoginPage,          new ProgressMessageAndValue( "Loading login page", 10 ) },
            { ProgressId.handleLogin,               new ProgressMessageAndValue( "Handling login", 30 ) },
            { ProgressId.loginSuccessful,           new ProgressMessageAndValue( "Login successful", 70 ) },
            { ProgressId.loginFailed,               new ProgressMessageAndValue( "Login failed", 100 ) },
            { ProgressId.requestQueuePlacings,      new ProgressMessageAndValue( "Requesting queue placings", 85 ) },
            { ProgressId.extractQueueDataAttempt,   new ProgressMessageAndValue( "Attempting to extract queue data", 95 ) },
            { ProgressId.extractQueueDataFailed,    new ProgressMessageAndValue( "Queue data extraction failed", 95 ) },
            { ProgressId.extractQueueDataSuccessful,new ProgressMessageAndValue( "Queue data extraction successful", 100 ) },
            { ProgressId.done,                      new ProgressMessageAndValue( "Done. Awaiting next scrape.", 100 ) },
            { ProgressId.unknownUrl,                new ProgressMessageAndValue( "Unknown URL", 100 ) },
        };

        public Scraper( MainForm mainForm ) {
            log = new SKB_Master.Log( this.GetType().Name, mainForm );
            initializeWebPageHandlers();
            updateStatus( ProgressId.initializingScraper );
            webBrowser = new WebBrowser();
            this.mainForm = mainForm;

            scrapeUpdateTimer = new System.Timers.Timer( scrapeUpdateInterval );
            scrapeUpdateTimer.Interval = scrapeUpdateInterval;
            scrapeUpdateTimer.Enabled = true;
            scrapeUpdateTimer.Elapsed += startScrapeFromEvent;
            startScrape();
        }

        void initializeWebPageHandlers() {
            webPageHandlers = new Dictionary<string, Action>();
            webPageHandlers.Add( loginUrl, handleLogin );
            webPageHandlers.Add( loginSuccessfulUrl, goToQueuePlacings );
            webPageHandlers.Add( loginFailedUrl, handleFailedLogin );
            webPageHandlers.Add( queuePlacingsUrl, extractQueuePlacingsData );
        }

        void updateStatus( ProgressId progressName, string details = "" ) {
            log.AddLog( progressUpdate[ progressName ].message, details );
            if ( mainForm != null ) {
                mainForm.UpdateStatus( progressUpdate[ progressName ].message, progressUpdate[ progressName ].progressValue );
            }
        }

		void startScrapeFromEvent( object sender, System.Timers.ElapsedEventArgs e ) {
            startScrape();
		}
        delegate void startScrapeCallback();
        void startScrape() {
            if ( webBrowser.InvokeRequired ) {
                startScrapeCallback d = new startScrapeCallback( startScrape );
                webBrowser.Invoke( d, new object[] { } );
            } else {
                webBrowser = new WebBrowser();
                updateStatus( ProgressId.scraperStart, loginUrl );
                logIn();
                webBrowser.DocumentCompleted += webPageLoaded;
            }
        }

        private void webPageLoaded( object sender, WebBrowserDocumentCompletedEventArgs e ) {
            currentDocument = webBrowser.Document;
            string url = e.Url.ToString();
            if ( webPageHandlers.ContainsKey( url ) ) {
                webPageHandlers[ url ]();
            } else {
                updateStatus( ProgressId.unknownUrl, url );
            }
        }

        void handleLogin() {
            if ( !isLoggedIn() ) {
                updateStatus( ProgressId.handleLogin, webBrowser.Url.ToString() );
                el( loginFormId ).OuterHtml = ""; // The page has 2 identical forms with the same ids in all elements, which causes problems. Remove the first one.
                                                  // el( "breadcrumbs" ).InnerText = "Mina bajskorvar"; // Hehe :) TODO: Grow up
                el( loginFormUsernameId ).SetAttribute( "value", Properties.Settings.Default.username );
                el( loginFormPasswordId ).SetAttribute( "value", Properties.Settings.Default.password );
                el( loginFormId ).InvokeMember( "submit" );
            } else {
                goToQueuePlacings();
            }
        }

        void handleFailedLogin() {
            updateStatus( ProgressId.loginFailed );
            mainForm.showError( "Inloggningen misslyckades." );
        }

        void logIn() {
            updateStatus( ProgressId.loadingLoginPage, loginUrl );
            webBrowser.Navigate( loginUrl );
        }

        void goToQueuePlacings() {
            updateStatus( ProgressId.requestQueuePlacings, queuePlacingsUrl );
            webBrowser.Navigate( queuePlacingsUrl );
        }

        void extractQueuePlacingsData() {
            updateStatus( ProgressId.extractQueueDataAttempt, webBrowser.Url.ToString() );
            HtmlElementCollection documentDivs = currentDocument.GetElementsByTagName( "div" );
            HtmlElement offersContainer = HtmlHelper.GetDescendantElement( documentDivs, "div", queuePlacingsLoadedClassName );
            List<Offer> currentOffers = getOffersFromOffersContainer( offersContainer );
            OfferHandler.updateOffersWithNewOffers( currentOffers );
            mainForm.UpdateUI();

            if ( offersContainer == null ) {
                System.Timers.Timer retryTimer = new System.Timers.Timer( 1000.0 );
                retryTimer.Elapsed += retryExtractQueuePlacingsData;
                retryTimer.Start();
            } else {
                updateStatus( ProgressId.done );
            }
        }

        List<Offer> getOffersFromOffersContainer( HtmlElement offersContainer ) {
            if ( offersContainer != null ) {
                List<Offer> offers = new List<Offer>();
                foreach ( HtmlElement offerContainer in offersContainer.Children ) {
                    Offer offer = new SKB_Master.Offer( offerContainer );
                    offers.Add( offer );
                }
                updateStatus( ProgressId.extractQueueDataSuccessful, offers.Count + " offers loaded" );
                return offers;
            } else {
                updateStatus( ProgressId.extractQueueDataFailed, "It probably hadn't loaded yet" );
            }
            return null;
        }

        void retryExtractQueuePlacingsData( object sender, System.Timers.ElapsedEventArgs e ) {
            System.Timers.Timer timer = sender as System.Timers.Timer;
            timer.Stop();
            extractQueuePlacingsData();
        }

        bool isLoggedIn() {
            List<string> classNames = new List<string>();
            HtmlElementCollection divs = currentDocument.GetElementsByTagName( "div" );
            foreach ( HtmlElement div in divs ) {
                string className = div.GetAttribute( "className" );
                if ( className == loggedInClassName ) {
                    return true;
                } else if ( className == notLoggedInClassName ) {
                    return false;
                }
            }
            return false;
        }

        HtmlElement el( string elementId ) { // Shorthand
            return currentDocument.GetElementById( elementId );
        }

        private struct ProgressMessageAndValue {
            public string message;
            public ushort progressValue;
            public ProgressMessageAndValue( string message, ushort progressValue ) {
                this.message = message;
                this.progressValue = progressValue;
            }
        }
    }
}
