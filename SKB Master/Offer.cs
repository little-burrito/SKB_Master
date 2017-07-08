using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SKB_Master {
    [ Serializable() ]
    public class Offer : IEquatable< Offer > {
        public string name;
        public int rooms;
        public int size;
        public string areaName;
        public int rent;
        public int additionalMoneyRequiredToMoveIn;
        public int estimatedLoanPricePerMonth;
        public int estimatedTotalCostPerMonth;
        public int placementInQueue;
        public int peopleInQueue;
        public bool isActive;
        public bool canReplyNow;
        public string replyLatestDateTime;
        public List<int> placementInQueueHistory;

        // Notices
        public bool showNewOfferNotice = true; // Unnecessary - will always be true
        public bool closedNewOfferNotice = false;
        
        public bool showCanReplyNowNotice = false; // Unnecessary - will always be same as canReplyNow
        public bool closedCanReplyNowNotice = false;

        public bool showActiveChangedNotice = false;
        public bool closedActiveChangedNotice = false;

        public bool showPlacementChangedNotice = false;
        public bool closedPlacementChangedNotice = false;

        // TODO: Add a timestamp for last active, so that we can sort the view by that if necessary?

        public Offer() {
            name = null;
            rooms = -1;
            size = -1;
            areaName = null;
            rent = -1;
            additionalMoneyRequiredToMoveIn = -1;
            estimatedLoanPricePerMonth = -1;
            estimatedTotalCostPerMonth = -1;
            placementInQueue = -1;
            placementInQueueHistory = new List<int>();
            peopleInQueue = -1;
            isActive = false;
            canReplyNow = false;
            replyLatestDateTime = null;
        }

        public Offer( HtmlElement offerContainerElement ) {
            name = getNameFromOfferContainer( offerContainerElement );
            rooms = getRoomsFromOfferContainer( offerContainerElement );
            size = getSizeFromOfferContainer( offerContainerElement );
            areaName = getAreaNameFromOfferContainer( offerContainerElement );
            rent = getRentFromOfferContainer( offerContainerElement );
            additionalMoneyRequiredToMoveIn = getAdditionalMoneyRequiredToMoveInFromOfferContainer( offerContainerElement );
            placementInQueue = getPlacementInQueueFromOfferContainer( offerContainerElement );
            placementInQueueHistory = new List<int>() { placementInQueue };
            peopleInQueue = getPeopleInQueueFromOfferContainer( offerContainerElement );
            canReplyNow = getCanReplyNowFromOfferContainer( offerContainerElement );
            showCanReplyNowNotice = canReplyNow;
            replyLatestDateTime = getReplyLatestDateTimeFromOfferContainer( offerContainerElement );
            isActive = true;
            CalculateEstimatedLoanPrice();
        }

        public Offer( string name, int rooms, int size, string areaName, int rent, int moneyRequiredToMoveIn, int placementInQueue, int peopleInQueue, bool isActive, bool canReplyNow, string replyNowDateTime ) {
            this.name = name;
            this.rooms = rooms;
            this.size = size;
            this.areaName = areaName;
            this.rent = rent;
            this.additionalMoneyRequiredToMoveIn = moneyRequiredToMoveIn;
            this.placementInQueue = placementInQueue;
            placementInQueueHistory = new List<int>() { placementInQueue };
            this.peopleInQueue = peopleInQueue;
            this.isActive = isActive;
            this.canReplyNow = canReplyNow;
            showCanReplyNowNotice = canReplyNow;
            this.replyLatestDateTime = replyNowDateTime;
            CalculateEstimatedLoanPrice();
        }

        public void UpdateOfferWithNewOffer( Offer newOffer ) {
            if ( newOffer.isActive ) {
                showActiveChangedNotice = false;
            }
            if ( placementInQueue != newOffer.placementInQueue ) {
                showPlacementChangedNotice = true;
                closedPlacementChangedNotice = false;
                placementInQueueHistory.Add( newOffer.placementInQueue );
            }
            if ( !canReplyNow && newOffer.canReplyNow ) {
                showCanReplyNowNotice = true;
            }

            placementInQueue = newOffer.placementInQueue;
            peopleInQueue = newOffer.peopleInQueue;
            isActive = newOffer.isActive;
            canReplyNow = newOffer.canReplyNow;
            replyLatestDateTime = newOffer.replyLatestDateTime;
        }

        public void CalculateEstimatedLoanPrice() {
            estimatedLoanPricePerMonth = ( int )( Properties.Settings.Default.estimatedInterestMultiplier * additionalMoneyRequiredToMoveIn );
            estimatedTotalCostPerMonth = rent + estimatedLoanPricePerMonth;
        }

        private string getNameFromOfferContainer( HtmlElement offerContainerElement ) {
            HtmlElement div = HtmlHelper.GetDescendantElement( offerContainerElement, "div", "ObjektDetalj span6" );
            HtmlElement h3 = HtmlHelper.GetDescendantElement( div, "h3" );
            HtmlElement a = HtmlHelper.GetDescendantElement( h3, "a" );
            if ( a != null ) {
                string name = a.InnerText;
                return name;
            }
            return null;
        }

        private int getRoomsFromOfferContainer( HtmlElement offerContainerElement ) {
            HtmlElement div = HtmlHelper.GetDescendantElement( offerContainerElement, "div", "ObjektDetalj span6" );
            HtmlElement h2 = HtmlHelper.GetDescendantElement( div, "h2" );
            HtmlElement a = HtmlHelper.GetDescendantElement( h2, "a" );
            if ( a != null ) {
                int rooms = extractNumbersFromString( a.InnerText );
                return rooms;
            }
            return -1;
        }

        private int getSizeFromOfferContainer( HtmlElement offerContainerElement ) {
            HtmlElement dd = HtmlHelper.GetDescendantElement( offerContainerElement, "dd", "ObjektYta" );
            if ( dd != null ) {
                int rooms = extractNumbersFromString( dd.InnerText );
                return rooms;
            }
            return -1;
        }

        private string getAreaNameFromOfferContainer( HtmlElement offerContainerElement ) {
            HtmlElement dd = HtmlHelper.GetDescendantElement( offerContainerElement, "dd", "ObjektOmrade" );
            if ( dd != null ) {
                string areaName = dd.InnerText;
                return areaName;
            }
            return null;
        }

        private int getRentFromOfferContainer( HtmlElement offerContainerElement ) {
            HtmlElement dd = HtmlHelper.GetDescendantElement( offerContainerElement, "dd", "ObjektHyra" );
            if ( dd != null ) {
                int rent = extractNumbersFromString( dd.InnerText );
                return rent;
            }
            return -1;
        }

        private int getAdditionalMoneyRequiredToMoveInFromOfferContainer( HtmlElement offerContainerElement ) {
            HtmlElement dd = HtmlHelper.GetDescendantElement( offerContainerElement, "dd", "kompletteras" );
            if ( dd != null ) {
                int additionalMoneyRequiredToMoveIn = extractNumbersFromString( dd.InnerText );
                return additionalMoneyRequiredToMoveIn;
            }
            return -1;
        }

        private int getPlacementInQueueFromOfferContainer( HtmlElement offerContainerElement ) {
            HtmlElement div = HtmlHelper.GetDescendantElement( offerContainerElement, "div", "Fritext" );
            if ( div != null ) {
                string text = div.InnerText;
                string regexToKeep = "plats \\d+ av ";
                Regex regex = new Regex( regexToKeep, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled );
                string placementInQueueWithExtraLetters = regex.Match( text ).ToString();
                int placementInQueue = extractNumbersFromString( placementInQueueWithExtraLetters );
                return placementInQueue;
            }
            return -1;
        }

        private int getPeopleInQueueFromOfferContainer( HtmlElement offerContainerElement ) {
            HtmlElement div = HtmlHelper.GetDescendantElement( offerContainerElement, "div", "Fritext" );
            if ( div != null ) {
                string text = div.InnerText;
                string regexToKeep = " av \\d+ sökande";
                Regex regex = new Regex( regexToKeep, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled );
                string peopleInQueueWithExtraLetters = regex.Match( text ).ToString();
                int peopleInQueue = extractNumbersFromString( peopleInQueueWithExtraLetters );
                return peopleInQueue;
            }
            return -1;
        }

        private bool getCanReplyNowFromOfferContainer( HtmlElement offerContainerElement ) {
            HtmlElement div = HtmlHelper.GetDescendantElement( offerContainerElement, "div", "ErbjudandeSvar" );
            HtmlElement input = HtmlHelper.GetDescendantElement( div, "input", "btn ErbjudandeVerifieraJa btn-success" );
            if ( input != null ) {
                return true;
            }
            return false;
        }

        private string getReplyLatestDateTimeFromOfferContainer( HtmlElement offerContainerElement ) {
            HtmlElement div = HtmlHelper.GetDescendantElement( offerContainerElement, "div", "ErbjudandeStatus" );
            if ( div != null ) {
                string text = div.InnerText;
                string regexToKeep = "\\d{4}-\\d{2}-\\d{2} kl \\d{2}:\\d{2}";
                Regex regex = new Regex( regexToKeep, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled );
                string canReplyNowDateTime = regex.Match( text ).ToString();
                return canReplyNowDateTime;
            }
            return null;
        }

        private int extractNumbersFromString( string textWithNumbers ) {
            string regexToRemove = "[^0-9]+";
            Regex regex = new Regex( regexToRemove, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled );
            string textWithoutNumbers = regex.Replace( textWithNumbers, string.Empty );
            if ( textWithoutNumbers.Length > 0 ) {
                int number = Int32.Parse( textWithoutNumbers );
                return number;
            }
            return 0;
        }

        public bool Equals( Offer other ) {
            if ( name == other.name &&
                 estimatedLoanPricePerMonth == other.estimatedLoanPricePerMonth &&
                 placementInQueue == other.placementInQueue &&
                 peopleInQueue == other.peopleInQueue &&
                 showActiveChangedNotice == other.showActiveChangedNotice &&
                 showCanReplyNowNotice == other.showCanReplyNowNotice &&
                 showNewOfferNotice == other.showNewOfferNotice &&
                 showPlacementChangedNotice == other.showPlacementChangedNotice &&
                 closedActiveChangedNotice == other.closedActiveChangedNotice &&
                 closedCanReplyNowNotice == other.closedCanReplyNowNotice &&
                 closedNewOfferNotice == other.closedNewOfferNotice &&
                 closedPlacementChangedNotice == other.closedPlacementChangedNotice ) {
                return true;
            }
            return false;
        }
    }
}
