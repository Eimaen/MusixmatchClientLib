
namespace MusixmatchClientLib.Sample.Forms
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSpotifyPresenceStatus = new System.Windows.Forms.Label();
            this.gbProfile = new System.Windows.Forms.GroupBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblProfileRanking = new System.Windows.Forms.Label();
            this.gbActiveSubscriptions = new System.Windows.Forms.GroupBox();
            this.gbRankings = new System.Windows.Forms.GroupBox();
            this.gbContributionGraph = new System.Windows.Forms.GroupBox();
            this.cbPremium = new System.Windows.Forms.CheckBox();
            this.lblWorld = new System.Windows.Forms.Label();
            this.lblLocal = new System.Windows.Forms.Label();
            this.gbProfile.SuspendLayout();
            this.gbActiveSubscriptions.SuspendLayout();
            this.gbRankings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSpotifyPresenceStatus
            // 
            this.lblSpotifyPresenceStatus.AutoSize = true;
            this.lblSpotifyPresenceStatus.Location = new System.Drawing.Point(11, 428);
            this.lblSpotifyPresenceStatus.Name = "lblSpotifyPresenceStatus";
            this.lblSpotifyPresenceStatus.Size = new System.Drawing.Size(109, 13);
            this.lblSpotifyPresenceStatus.TabIndex = 0;
            this.lblSpotifyPresenceStatus.Text = "Now Playing: Nothing";
            // 
            // gbProfile
            // 
            this.gbProfile.Controls.Add(this.lblProfileRanking);
            this.gbProfile.Controls.Add(this.lblUsername);
            this.gbProfile.Location = new System.Drawing.Point(12, 12);
            this.gbProfile.Name = "gbProfile";
            this.gbProfile.Size = new System.Drawing.Size(220, 65);
            this.gbProfile.TabIndex = 1;
            this.gbProfile.TabStop = false;
            this.gbProfile.Text = "Logged in as";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUsername.Location = new System.Drawing.Point(6, 16);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(75, 24);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Eimaen";
            // 
            // lblProfileRanking
            // 
            this.lblProfileRanking.AutoSize = true;
            this.lblProfileRanking.Location = new System.Drawing.Point(7, 40);
            this.lblProfileRanking.Name = "lblProfileRanking";
            this.lblProfileRanking.Size = new System.Drawing.Size(101, 13);
            this.lblProfileRanking.TabIndex = 1;
            this.lblProfileRanking.Text = "King, 700000 points";
            // 
            // gbActiveSubscriptions
            // 
            this.gbActiveSubscriptions.Controls.Add(this.cbPremium);
            this.gbActiveSubscriptions.Location = new System.Drawing.Point(12, 83);
            this.gbActiveSubscriptions.Name = "gbActiveSubscriptions";
            this.gbActiveSubscriptions.Size = new System.Drawing.Size(220, 100);
            this.gbActiveSubscriptions.TabIndex = 2;
            this.gbActiveSubscriptions.TabStop = false;
            this.gbActiveSubscriptions.Text = "Active subscriptions";
            // 
            // gbRankings
            // 
            this.gbRankings.Controls.Add(this.lblLocal);
            this.gbRankings.Controls.Add(this.lblWorld);
            this.gbRankings.Location = new System.Drawing.Point(12, 189);
            this.gbRankings.Name = "gbRankings";
            this.gbRankings.Size = new System.Drawing.Size(220, 100);
            this.gbRankings.TabIndex = 3;
            this.gbRankings.TabStop = false;
            this.gbRankings.Text = "Your ranking positions";
            // 
            // gbContributionGraph
            // 
            this.gbContributionGraph.Location = new System.Drawing.Point(238, 12);
            this.gbContributionGraph.Name = "gbContributionGraph";
            this.gbContributionGraph.Size = new System.Drawing.Size(550, 277);
            this.gbContributionGraph.TabIndex = 4;
            this.gbContributionGraph.TabStop = false;
            this.gbContributionGraph.Text = "Contribution statistics visualization";
            // 
            // cbPremium
            // 
            this.cbPremium.AutoSize = true;
            this.cbPremium.Checked = true;
            this.cbPremium.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPremium.Enabled = false;
            this.cbPremium.Location = new System.Drawing.Point(10, 19);
            this.cbPremium.Name = "cbPremium";
            this.cbPremium.Size = new System.Drawing.Size(109, 17);
            this.cbPremium.TabIndex = 5;
            this.cbPremium.Text = "Premium Account";
            this.cbPremium.UseMnemonic = false;
            this.cbPremium.UseVisualStyleBackColor = true;
            // 
            // lblWorld
            // 
            this.lblWorld.AutoSize = true;
            this.lblWorld.Location = new System.Drawing.Point(6, 20);
            this.lblWorld.Name = "lblWorld";
            this.lblWorld.Size = new System.Drawing.Size(38, 13);
            this.lblWorld.TabIndex = 5;
            this.lblWorld.Text = "World:";
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Location = new System.Drawing.Point(7, 38);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(36, 13);
            this.lblLocal.TabIndex = 6;
            this.lblLocal.Text = "Local:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbContributionGraph);
            this.Controls.Add(this.gbRankings);
            this.Controls.Add(this.gbActiveSubscriptions);
            this.Controls.Add(this.gbProfile);
            this.Controls.Add(this.lblSpotifyPresenceStatus);
            this.Name = "FormMain";
            this.Text = "MusixmatchClientLib Client";
            this.gbProfile.ResumeLayout(false);
            this.gbProfile.PerformLayout();
            this.gbActiveSubscriptions.ResumeLayout(false);
            this.gbActiveSubscriptions.PerformLayout();
            this.gbRankings.ResumeLayout(false);
            this.gbRankings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSpotifyPresenceStatus;
        private System.Windows.Forms.GroupBox gbProfile;
        private System.Windows.Forms.Label lblProfileRanking;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.GroupBox gbActiveSubscriptions;
        private System.Windows.Forms.CheckBox cbPremium;
        private System.Windows.Forms.GroupBox gbRankings;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.Label lblWorld;
        private System.Windows.Forms.GroupBox gbContributionGraph;
    }
}