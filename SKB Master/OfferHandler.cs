using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace SKB_Master {
    public static class OfferHandler {
        private static string offersFileName = "offers.xml";

        public static void updateOffersWithNewOffers( List<Offer> newOffers ) {
            if ( newOffers != null ) {
                List<Offer> loadedOffers = LoadOffers();
                foreach ( Offer offer in loadedOffers ) {
                    if ( offer.isActive ) {
                        offer.showActiveChangedNotice = true;
                    }
                    offer.isActive = false;
                }
                foreach ( Offer newOffer in newOffers ) {
                    bool seenEarlier = false;
                    foreach ( Offer offer in loadedOffers ) {
                        if ( offer.name == newOffer.name ) {
                            seenEarlier = true;
                            offer.UpdateOfferWithNewOffer( newOffer );
                        }
                    }
                    if ( !seenEarlier ) {
                        loadedOffers.Add( newOffer );
                    }
                }
                SaveOffers( loadedOffers );
            }
        }

        public static void closedPlacementChangedNotificationForOffer( Offer offer ) {
            List<Offer> offers = LoadOffers();
            if ( offers.Contains( offer ) ) {
                offers.Remove( offer );
                offer.showPlacementChangedNotice = false;
                offers.Add( offer );
                SaveOffers( offers );
            }
        }

        public static void closedActiveChangedNotificationForOffer( Offer offer ) {
            List<Offer> offers = LoadOffers();
            if ( offers.Contains( offer ) ) {
                offers.Remove( offer );
                offer.showActiveChangedNotice = false;
                offers.Add( offer );
                SaveOffers( offers );
            }
        }

        public static void closedIsNewOfferNotificationForOffer( Offer offer ) {
            List<Offer> offers = LoadOffers();
            if ( offers.Contains( offer ) ) {
                offers.Remove( offer );
                offer.showNewOfferNotice = false;
                offers.Add( offer );
                SaveOffers( offers );
            }
        }

        public static void SaveOffers( List<Offer> offers ) {
            string filePath = Environment.ExpandEnvironmentVariables( Properties.Settings.Default.offersFileLocation + offersFileName );
            XmlSerializer xmlSerializer = new XmlSerializer( typeof( List<Offer> ) );
            TextWriter fileStream = new StreamWriter( filePath );
            xmlSerializer.Serialize( fileStream, offers );
            fileStream.Close();
        }

        public static List<Offer> LoadOffers() {
            string filePath = Environment.ExpandEnvironmentVariables( Properties.Settings.Default.offersFileLocation + offersFileName );
            if ( File.Exists( filePath ) ) {
                XmlSerializer xmlSerializer = new XmlSerializer( typeof( List<Offer> ) );
                TextReader fileStream = new StreamReader( filePath );
                List<Offer> offers = xmlSerializer.Deserialize( fileStream ) as List<Offer>;
                fileStream.Close();
                foreach( Offer offer in offers ) {
                    offer.CalculateEstimatedLoanPrice();
                }
                return offers;
            }
            return new List<Offer>();
        }
    }
}
