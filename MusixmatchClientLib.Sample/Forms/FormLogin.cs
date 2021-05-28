using MusixmatchClientLib.API.Model.Exceptions;
using MusixmatchClientLib.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusixmatchClientLib.Sample.Forms
{
    public partial class FormLogin : Form
    {
        private MusixmatchClient MusixmatchClient;
        private MusixmatchToken MusixmatchToken;

        public FormLogin()
        {
            InitializeComponent();
        }

        private Image LoadImage(string url) => Image.FromStream(new WebClient().OpenRead(url));

        private void IssueNewToken()
        {
            try
            {
                MusixmatchToken = new MusixmatchToken();
                tbToken.Text = MusixmatchToken.Token.ToString();
            }
            catch 
            { 
            
            }
            UpdateUserToken();
        }

        private void UpdateUserToken()
        {
            MusixmatchToken = new MusixmatchToken(tbToken.Text);
            MusixmatchClient = new MusixmatchClient(MusixmatchToken);
        }

        private void UpdateProfileInfo()
        {
            UpdateUserToken();

            try
            {
                var userInfo = MusixmatchClient.GetUserScore();

                lblPreviewNickname.Text = userInfo.UserName.ToString();
                lblPreviewRankInfo.Text = $"Score: {userInfo.Score}";
                pbPreviewUserPicture.Image = LoadImage(userInfo.UserProfilePhoto);
            }
            catch (MusixmatchRequestException ex)
            {
                lblPreviewNickname.Text = "You are not logged in!";
                lblPreviewRankInfo.Text = ex.Message;
                pbPreviewUserPicture.Image = new Bitmap(50, 50);
            }
        }

        private void btnGenerateToken_Click(object sender, EventArgs e) => IssueNewToken();

        private void btnPreviewForceUpdate_Click(object sender, EventArgs e) => UpdateProfileInfo();

        private void btnAutoAuth_Click(object sender, EventArgs e) => Process.Start($"https://oauth.musixmatch.com/credential/signin?app_id=web-desktop-app-v1.0&usertoken={MusixmatchToken.Token}&origin=none");

        private void btnProceed_Click(object sender, EventArgs e)
        {
            Globals.MusixmatchClient = MusixmatchClient;
        }

        private void btnLoginGoogle_Click(object sender, EventArgs e)
        {

        }

        private void btnLoginRaw_Click(object sender, EventArgs e)
        {

        }
    }
}
