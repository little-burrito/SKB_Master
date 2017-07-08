namespace SKB_Master {
    partial class InactiveOffer {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.areaName = new System.Windows.Forms.Label();
            this.infoTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.roomsAndSize = new System.Windows.Forms.Label();
            this.additionalMoneyRequiredToMoveIn = new System.Windows.Forms.Label();
            this.placementInQueue = new System.Windows.Forms.Label();
            this.estimatedLoanPricePerMonth = new System.Windows.Forms.Label();
            this.estimatedTotalCostPerMonth = new System.Windows.Forms.Label();
            this.rent = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.LinkLabel();
            this.separatorLine = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.infoTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // areaName
            // 
            this.areaName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.areaName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.areaName.Location = new System.Drawing.Point(3, 29);
            this.areaName.Name = "areaName";
            this.areaName.Size = new System.Drawing.Size(247, 16);
            this.areaName.TabIndex = 1;
            this.areaName.Text = "Hässelby Villastad";
            this.areaName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip.SetToolTip(this.areaName, "Lägenhetens område");
            // 
            // infoTableLayout
            // 
            this.infoTableLayout.ColumnCount = 2;
            this.infoTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.77733F));
            this.infoTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.22267F));
            this.infoTableLayout.Controls.Add(this.roomsAndSize, 0, 0);
            this.infoTableLayout.Controls.Add(this.additionalMoneyRequiredToMoveIn, 0, 1);
            this.infoTableLayout.Controls.Add(this.placementInQueue, 0, 2);
            this.infoTableLayout.Controls.Add(this.estimatedLoanPricePerMonth, 1, 1);
            this.infoTableLayout.Controls.Add(this.estimatedTotalCostPerMonth, 1, 2);
            this.infoTableLayout.Controls.Add(this.rent, 1, 0);
            this.infoTableLayout.Location = new System.Drawing.Point(3, 52);
            this.infoTableLayout.Name = "infoTableLayout";
            this.infoTableLayout.RowCount = 3;
            this.infoTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.infoTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.infoTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.infoTableLayout.Size = new System.Drawing.Size(247, 62);
            this.infoTableLayout.TabIndex = 2;
            // 
            // roomsAndSize
            // 
            this.roomsAndSize.AutoSize = true;
            this.roomsAndSize.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.roomsAndSize.Location = new System.Drawing.Point(3, 0);
            this.roomsAndSize.Name = "roomsAndSize";
            this.roomsAndSize.Size = new System.Drawing.Size(74, 13);
            this.roomsAndSize.TabIndex = 0;
            this.roomsAndSize.Text = "2 rum, 63 kvm";
            this.toolTip.SetToolTip(this.roomsAndSize, "Lägenhetens antal rum och yta");
            // 
            // additionalMoneyRequiredToMoveIn
            // 
            this.additionalMoneyRequiredToMoveIn.AutoSize = true;
            this.additionalMoneyRequiredToMoveIn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.additionalMoneyRequiredToMoveIn.Location = new System.Drawing.Point(3, 20);
            this.additionalMoneyRequiredToMoveIn.Name = "additionalMoneyRequiredToMoveIn";
            this.additionalMoneyRequiredToMoveIn.Size = new System.Drawing.Size(148, 13);
            this.additionalMoneyRequiredToMoveIn.TabIndex = 1;
            this.additionalMoneyRequiredToMoveIn.Text = "Återstående insats 190 268 kr";
            this.toolTip.SetToolTip(this.additionalMoneyRequiredToMoveIn, "Återstående kostnad att betala för lägenhetens insats");
            // 
            // placementInQueue
            // 
            this.placementInQueue.AutoSize = true;
            this.placementInQueue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.placementInQueue.Location = new System.Drawing.Point(3, 40);
            this.placementInQueue.Name = "placementInQueue";
            this.placementInQueue.Size = new System.Drawing.Size(149, 13);
            this.placementInQueue.TabIndex = 2;
            this.placementInQueue.Text = "Senast kända plats 37 av 167";
            this.toolTip.SetToolTip(this.placementInQueue, "Placering i kön till den här lägenhet");
            // 
            // estimatedLoanPricePerMonth
            // 
            this.estimatedLoanPricePerMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.estimatedLoanPricePerMonth.AutoSize = true;
            this.estimatedLoanPricePerMonth.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.estimatedLoanPricePerMonth.Location = new System.Drawing.Point(182, 20);
            this.estimatedLoanPricePerMonth.Name = "estimatedLoanPricePerMonth";
            this.estimatedLoanPricePerMonth.Size = new System.Drawing.Size(62, 13);
            this.estimatedLoanPricePerMonth.TabIndex = 4;
            this.estimatedLoanPricePerMonth.Text = "250 kr/mån";
            this.estimatedLoanPricePerMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.estimatedLoanPricePerMonth, "Uppskattad kostnad per månad för lån av återstående insats");
            // 
            // estimatedTotalCostPerMonth
            // 
            this.estimatedTotalCostPerMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.estimatedTotalCostPerMonth.AutoSize = true;
            this.estimatedTotalCostPerMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.estimatedTotalCostPerMonth.Location = new System.Drawing.Point(173, 40);
            this.estimatedTotalCostPerMonth.Name = "estimatedTotalCostPerMonth";
            this.estimatedTotalCostPerMonth.Size = new System.Drawing.Size(71, 13);
            this.estimatedTotalCostPerMonth.TabIndex = 5;
            this.estimatedTotalCostPerMonth.Text = "6 189 kr/mån";
            this.estimatedTotalCostPerMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.estimatedTotalCostPerMonth, "Uppskattad kostnad per månad inklusive lån");
            // 
            // rent
            // 
            this.rent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rent.AutoSize = true;
            this.rent.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rent.Location = new System.Drawing.Point(167, 0);
            this.rent.Name = "rent";
            this.rent.Size = new System.Drawing.Size(77, 13);
            this.rent.TabIndex = 3;
            this.rent.Text = "15 939 kr/mån";
            this.rent.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip.SetToolTip(this.rent, "Hyra");
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.name.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.name.LinkColor = System.Drawing.SystemColors.ControlText;
            this.name.Location = new System.Drawing.Point(3, 7);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(247, 19);
            this.name.TabIndex = 0;
            this.name.TabStop = true;
            this.name.Text = "Granskogsvägen 48 LGH 1602";
            this.name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip.SetToolTip(this.name, "Lägenhetens adress");
            this.name.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.name_LinkClicked);
            // 
            // separatorLine
            // 
            this.separatorLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.separatorLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.separatorLine.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.separatorLine.Location = new System.Drawing.Point(165, 89);
            this.separatorLine.Name = "separatorLine";
            this.separatorLine.Size = new System.Drawing.Size(83, 1);
            this.separatorLine.TabIndex = 4;
            // 
            // InactiveOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.Controls.Add(this.separatorLine);
            this.Controls.Add(this.name);
            this.Controls.Add(this.infoTableLayout);
            this.Controls.Add(this.areaName);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.Name = "InactiveOffer";
            this.Size = new System.Drawing.Size(253, 129);
            this.infoTableLayout.ResumeLayout(false);
            this.infoTableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label areaName;
        private System.Windows.Forms.TableLayoutPanel infoTableLayout;
        private System.Windows.Forms.Label roomsAndSize;
        private System.Windows.Forms.Label additionalMoneyRequiredToMoveIn;
        private System.Windows.Forms.Label placementInQueue;
        private System.Windows.Forms.Label rent;
        private System.Windows.Forms.Label estimatedLoanPricePerMonth;
        private System.Windows.Forms.Label estimatedTotalCostPerMonth;
        private System.Windows.Forms.LinkLabel name;
        private System.Windows.Forms.Label separatorLine;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
