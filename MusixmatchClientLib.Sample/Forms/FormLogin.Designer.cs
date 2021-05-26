
namespace MusixmatchClientLib.Sample.Forms
{
    partial class FormLogin
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
            this.lblLoginFormDescription = new System.Windows.Forms.Label();
            this.tbToken = new System.Windows.Forms.TextBox();
            this.lblTokenDesc = new System.Windows.Forms.Label();
            this.btnGenerateToken = new System.Windows.Forms.Button();
            this.gbTokenAuth = new System.Windows.Forms.GroupBox();
            this.lblMoreAuth = new System.Windows.Forms.Label();
            this.btnLoginGoogle = new System.Windows.Forms.Button();
            this.btnLoginRaw = new System.Windows.Forms.Button();
            this.btnAutoAuth = new System.Windows.Forms.Button();
            this.gbTokenManagement = new System.Windows.Forms.GroupBox();
            this.gbProfilePreview = new System.Windows.Forms.GroupBox();
            this.btnPreviewForceUpdate = new System.Windows.Forms.Button();
            this.lblPreviewRankInfo = new System.Windows.Forms.Label();
            this.lblPreviewNickname = new System.Windows.Forms.Label();
            this.pbPreviewUserPicture = new System.Windows.Forms.PictureBox();
            this.btnProceed = new System.Windows.Forms.Button();
            this.gbTokenAuth.SuspendLayout();
            this.gbTokenManagement.SuspendLayout();
            this.gbProfilePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewUserPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLoginFormDescription
            // 
            this.lblLoginFormDescription.AutoSize = true;
            this.lblLoginFormDescription.Location = new System.Drawing.Point(12, 9);
            this.lblLoginFormDescription.Name = "lblLoginFormDescription";
            this.lblLoginFormDescription.Size = new System.Drawing.Size(169, 13);
            this.lblLoginFormDescription.TabIndex = 0;
            this.lblLoginFormDescription.Text = "Login to your Musixmatch account";
            // 
            // tbToken
            // 
            this.tbToken.Location = new System.Drawing.Point(9, 32);
            this.tbToken.Name = "tbToken";
            this.tbToken.Size = new System.Drawing.Size(371, 20);
            this.tbToken.TabIndex = 1;
            // 
            // lblTokenDesc
            // 
            this.lblTokenDesc.AutoSize = true;
            this.lblTokenDesc.Location = new System.Drawing.Point(6, 16);
            this.lblTokenDesc.Name = "lblTokenDesc";
            this.lblTokenDesc.Size = new System.Drawing.Size(88, 13);
            this.lblTokenDesc.TabIndex = 2;
            this.lblTokenDesc.Text = "Enter your token:";
            // 
            // btnGenerateToken
            // 
            this.btnGenerateToken.Location = new System.Drawing.Point(9, 58);
            this.btnGenerateToken.Name = "btnGenerateToken";
            this.btnGenerateToken.Size = new System.Drawing.Size(371, 23);
            this.btnGenerateToken.TabIndex = 3;
            this.btnGenerateToken.Text = "Generate a new Musixmatch token";
            this.btnGenerateToken.UseVisualStyleBackColor = true;
            this.btnGenerateToken.Click += new System.EventHandler(this.btnGenerateToken_Click);
            // 
            // gbTokenAuth
            // 
            this.gbTokenAuth.Controls.Add(this.lblMoreAuth);
            this.gbTokenAuth.Controls.Add(this.btnLoginGoogle);
            this.gbTokenAuth.Controls.Add(this.btnLoginRaw);
            this.gbTokenAuth.Controls.Add(this.btnAutoAuth);
            this.gbTokenAuth.Location = new System.Drawing.Point(407, 9);
            this.gbTokenAuth.Name = "gbTokenAuth";
            this.gbTokenAuth.Size = new System.Drawing.Size(326, 103);
            this.gbTokenAuth.TabIndex = 4;
            this.gbTokenAuth.TabStop = false;
            this.gbTokenAuth.Text = "Token Authorization";
            // 
            // lblMoreAuth
            // 
            this.lblMoreAuth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMoreAuth.ForeColor = System.Drawing.Color.Gray;
            this.lblMoreAuth.Location = new System.Drawing.Point(6, 70);
            this.lblMoreAuth.Name = "lblMoreAuth";
            this.lblMoreAuth.Size = new System.Drawing.Size(314, 27);
            this.lblMoreAuth.TabIndex = 6;
            this.lblMoreAuth.Text = "Even if you are experiencing some issues using Web login method, ignore them.\r\n";
            // 
            // btnLoginGoogle
            // 
            this.btnLoginGoogle.Location = new System.Drawing.Point(6, 46);
            this.btnLoginGoogle.Name = "btnLoginGoogle";
            this.btnLoginGoogle.Size = new System.Drawing.Size(153, 23);
            this.btnLoginGoogle.TabIndex = 3;
            this.btnLoginGoogle.Text = "Login via Google Token";
            this.btnLoginGoogle.UseVisualStyleBackColor = true;
            this.btnLoginGoogle.Click += new System.EventHandler(this.btnLoginGoogle_Click);
            // 
            // btnLoginRaw
            // 
            this.btnLoginRaw.Location = new System.Drawing.Point(167, 46);
            this.btnLoginRaw.Name = "btnLoginRaw";
            this.btnLoginRaw.Size = new System.Drawing.Size(153, 23);
            this.btnLoginRaw.TabIndex = 2;
            this.btnLoginRaw.Text = "Login via Musixmatch";
            this.btnLoginRaw.UseVisualStyleBackColor = true;
            this.btnLoginRaw.Click += new System.EventHandler(this.btnLoginRaw_Click);
            // 
            // btnAutoAuth
            // 
            this.btnAutoAuth.Location = new System.Drawing.Point(6, 19);
            this.btnAutoAuth.Name = "btnAutoAuth";
            this.btnAutoAuth.Size = new System.Drawing.Size(314, 23);
            this.btnAutoAuth.TabIndex = 0;
            this.btnAutoAuth.Text = "Login via Web";
            this.btnAutoAuth.UseVisualStyleBackColor = true;
            this.btnAutoAuth.Click += new System.EventHandler(this.btnAutoAuth_Click);
            // 
            // gbTokenManagement
            // 
            this.gbTokenManagement.Controls.Add(this.tbToken);
            this.gbTokenManagement.Controls.Add(this.lblTokenDesc);
            this.gbTokenManagement.Controls.Add(this.btnGenerateToken);
            this.gbTokenManagement.Location = new System.Drawing.Point(15, 25);
            this.gbTokenManagement.Name = "gbTokenManagement";
            this.gbTokenManagement.Size = new System.Drawing.Size(386, 87);
            this.gbTokenManagement.TabIndex = 5;
            this.gbTokenManagement.TabStop = false;
            this.gbTokenManagement.Text = "Token Management";
            // 
            // gbProfilePreview
            // 
            this.gbProfilePreview.Controls.Add(this.btnPreviewForceUpdate);
            this.gbProfilePreview.Controls.Add(this.lblPreviewRankInfo);
            this.gbProfilePreview.Controls.Add(this.lblPreviewNickname);
            this.gbProfilePreview.Controls.Add(this.pbPreviewUserPicture);
            this.gbProfilePreview.Location = new System.Drawing.Point(15, 118);
            this.gbProfilePreview.Name = "gbProfilePreview";
            this.gbProfilePreview.Size = new System.Drawing.Size(718, 126);
            this.gbProfilePreview.TabIndex = 6;
            this.gbProfilePreview.TabStop = false;
            this.gbProfilePreview.Text = "Profile Preview";
            // 
            // btnPreviewForceUpdate
            // 
            this.btnPreviewForceUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviewForceUpdate.Location = new System.Drawing.Point(596, 96);
            this.btnPreviewForceUpdate.Name = "btnPreviewForceUpdate";
            this.btnPreviewForceUpdate.Size = new System.Drawing.Size(116, 23);
            this.btnPreviewForceUpdate.TabIndex = 3;
            this.btnPreviewForceUpdate.Text = "Force Update";
            this.btnPreviewForceUpdate.UseVisualStyleBackColor = true;
            this.btnPreviewForceUpdate.Click += new System.EventHandler(this.btnPreviewForceUpdate_Click);
            // 
            // lblPreviewRankInfo
            // 
            this.lblPreviewRankInfo.AutoSize = true;
            this.lblPreviewRankInfo.Location = new System.Drawing.Point(116, 39);
            this.lblPreviewRankInfo.Name = "lblPreviewRankInfo";
            this.lblPreviewRankInfo.Size = new System.Drawing.Size(58, 13);
            this.lblPreviewRankInfo.TabIndex = 2;
            this.lblPreviewRankInfo.Text = "Your Rank";
            // 
            // lblPreviewNickname
            // 
            this.lblPreviewNickname.AutoSize = true;
            this.lblPreviewNickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPreviewNickname.Location = new System.Drawing.Point(115, 19);
            this.lblPreviewNickname.Name = "lblPreviewNickname";
            this.lblPreviewNickname.Size = new System.Drawing.Size(117, 20);
            this.lblPreviewNickname.TabIndex = 1;
            this.lblPreviewNickname.Text = "Your Nickname";
            // 
            // pbPreviewUserPicture
            // 
            this.pbPreviewUserPicture.Location = new System.Drawing.Point(9, 19);
            this.pbPreviewUserPicture.Name = "pbPreviewUserPicture";
            this.pbPreviewUserPicture.Size = new System.Drawing.Size(100, 100);
            this.pbPreviewUserPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreviewUserPicture.TabIndex = 0;
            this.pbPreviewUserPicture.TabStop = false;
            // 
            // btnProceed
            // 
            this.btnProceed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProceed.Location = new System.Drawing.Point(617, 252);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(116, 23);
            this.btnProceed.TabIndex = 4;
            this.btnProceed.Text = "Continue";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 281);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.gbProfilePreview);
            this.Controls.Add(this.gbTokenManagement);
            this.Controls.Add(this.gbTokenAuth);
            this.Controls.Add(this.lblLoginFormDescription);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.gbTokenAuth.ResumeLayout(false);
            this.gbTokenManagement.ResumeLayout(false);
            this.gbTokenManagement.PerformLayout();
            this.gbProfilePreview.ResumeLayout(false);
            this.gbProfilePreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewUserPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoginFormDescription;
        private System.Windows.Forms.TextBox tbToken;
        private System.Windows.Forms.Label lblTokenDesc;
        private System.Windows.Forms.Button btnGenerateToken;
        private System.Windows.Forms.GroupBox gbTokenAuth;
        private System.Windows.Forms.GroupBox gbTokenManagement;
        private System.Windows.Forms.Label lblMoreAuth;
        private System.Windows.Forms.Button btnLoginGoogle;
        private System.Windows.Forms.Button btnLoginRaw;
        private System.Windows.Forms.Button btnAutoAuth;
        private System.Windows.Forms.GroupBox gbProfilePreview;
        private System.Windows.Forms.Button btnPreviewForceUpdate;
        private System.Windows.Forms.Label lblPreviewRankInfo;
        private System.Windows.Forms.Label lblPreviewNickname;
        private System.Windows.Forms.PictureBox pbPreviewUserPicture;
        private System.Windows.Forms.Button btnProceed;
    }
}