﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKB_Master {
    public partial class InactiveOffer : UserControl {
        public InactiveOffer() {
            InitializeComponent();
        }

        public InactiveOffer( Offer offer ) {
            InitializeComponent();
            name.Text = offer.name;
            areaName.Text = offer.areaName;
            roomsAndSize.Text = offer.rooms + " rum, " + offer.size + " m²";
            additionalMoneyRequiredToMoveIn.Text = "Insats kvar " + string.Format( "{0:n0}", offer.additionalMoneyRequiredToMoveIn ) + " kr";
            placementInQueue.Text = "Senast kända plats " + offer.placementInQueue + " av " + offer.peopleInQueue;
            rent.Text = string.Format( "{0:n0}", offer.rent ) + " kr/mån";
            estimatedLoanPricePerMonth.Text = string.Format( "{0:n0}", offer.estimatedLoanPricePerMonth ) + " kr/mån";
            estimatedTotalCostPerMonth.Text = string.Format( "{0:n0}", offer.estimatedTotalCostPerMonth ) + " kr/mån";
        }

        private void name_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e ) {
            System.Diagnostics.Process.Start( Properties.Settings.Default.queuePlacingsUrl );
        }

        private void replyNow_Click( object sender, EventArgs e ) {
            System.Diagnostics.Process.Start( Properties.Settings.Default.queuePlacingsUrl );
        }
    }
}
