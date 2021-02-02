using MusixmatchClientLib.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusixmatchClientLib.Client
{
    public partial class FormMain : Form
    {
        private MusixmatchToken token;
        private MusixmatchClient client;

        public FormMain()
        {
            InitializeComponent();
            token = new MusixmatchToken("210123f3312aa5830ea3094a9ca2ae36ebf87840002377cca15cb3");
            client = new MusixmatchClient(token);
            ReloadInfo();
        }

        public void ReloadInfo()
        {
            try
            {
                var user = client.GetUserInfo();
                labelUsername.Text = user.UserData.Profile.Name;
                pbProfile.Load(user.UserData.Profile.UserPicture.Replace("=s50", ""));
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }
    }
}
