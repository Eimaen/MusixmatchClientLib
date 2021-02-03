namespace MusixmatchClientLib.Client
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panelLoginMusixmatch = new System.Windows.Forms.Panel();
            this.pbProfile = new System.Windows.Forms.PictureBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelRank = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelCurator = new System.Windows.Forms.Label();
            this.labelGraduated = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLoginMusixmatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(8, 21);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(218, 20);
            this.tbLogin.TabIndex = 1;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(5, 5);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(35, 13);
            this.labelLogin.TabIndex = 2;
            this.labelLogin.Text = "Email:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(5, 44);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(8, 60);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(218, 20);
            this.tbPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(151, 86);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // panelLoginMusixmatch
            // 
            this.panelLoginMusixmatch.Controls.Add(this.labelLogin);
            this.panelLoginMusixmatch.Controls.Add(this.btnLogin);
            this.panelLoginMusixmatch.Controls.Add(this.tbLogin);
            this.panelLoginMusixmatch.Controls.Add(this.labelPassword);
            this.panelLoginMusixmatch.Controls.Add(this.tbPassword);
            this.panelLoginMusixmatch.Location = new System.Drawing.Point(12, 12);
            this.panelLoginMusixmatch.Name = "panelLoginMusixmatch";
            this.panelLoginMusixmatch.Size = new System.Drawing.Size(233, 120);
            this.panelLoginMusixmatch.TabIndex = 6;
            // 
            // pbProfile
            // 
            this.pbProfile.Location = new System.Drawing.Point(8, 7);
            this.pbProfile.Name = "pbProfile";
            this.pbProfile.Size = new System.Drawing.Size(100, 100);
            this.pbProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfile.TabIndex = 7;
            this.pbProfile.TabStop = false;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUsername.Location = new System.Drawing.Point(114, 7);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(51, 25);
            this.labelUsername.TabIndex = 8;
            this.labelUsername.Text = "You";
            // 
            // labelRank
            // 
            this.labelRank.AutoSize = true;
            this.labelRank.Location = new System.Drawing.Point(116, 32);
            this.labelRank.Name = "labelRank";
            this.labelRank.Size = new System.Drawing.Size(33, 13);
            this.labelRank.TabIndex = 9;
            this.labelRank.Text = "Rank";
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Location = new System.Drawing.Point(116, 45);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(36, 13);
            this.labelPoints.TabIndex = 10;
            this.labelPoints.Text = "Points";
            // 
            // labelCurator
            // 
            this.labelCurator.AutoSize = true;
            this.labelCurator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCurator.ForeColor = System.Drawing.Color.Red;
            this.labelCurator.Location = new System.Drawing.Point(117, 94);
            this.labelCurator.Name = "labelCurator";
            this.labelCurator.Size = new System.Drawing.Size(48, 13);
            this.labelCurator.TabIndex = 11;
            this.labelCurator.Text = "Curator";
            // 
            // labelGraduated
            // 
            this.labelGraduated.AutoSize = true;
            this.labelGraduated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGraduated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelGraduated.Location = new System.Drawing.Point(117, 81);
            this.labelGraduated.Name = "labelGraduated";
            this.labelGraduated.Size = new System.Drawing.Size(66, 13);
            this.labelGraduated.TabIndex = 12;
            this.labelGraduated.Text = "Graduated";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbProfile);
            this.panel1.Controls.Add(this.labelGraduated);
            this.panel1.Controls.Add(this.labelUsername);
            this.panel1.Controls.Add(this.labelCurator);
            this.panel1.Controls.Add(this.labelRank);
            this.panel1.Controls.Add(this.labelPoints);
            this.panel1.Location = new System.Drawing.Point(251, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 114);
            this.panel1.TabIndex = 13;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 354);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelLoginMusixmatch);
            this.Name = "FormMain";
            this.Text = "MusixmatchClientLib Client";
            this.panelLoginMusixmatch.ResumeLayout(false);
            this.panelLoginMusixmatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panelLoginMusixmatch;
        private System.Windows.Forms.PictureBox pbProfile;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelRank;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelCurator;
        private System.Windows.Forms.Label labelGraduated;
        private System.Windows.Forms.Panel panel1;
    }
}

