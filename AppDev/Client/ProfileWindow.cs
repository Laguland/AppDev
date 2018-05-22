using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerData;
using System.Threading;
using System.Text.RegularExpressions;

namespace Client
{
    public partial class ProfileWindow : Form
    {
        public string userProfileEmail;

        public ProfileWindow(string newUserProfileEmail)
        {
            this.userProfileEmail = newUserProfileEmail;
            InitializeComponent();
        }

        private void ProfileWindow_Load(object sender, EventArgs e)
        {
            labelListOfInstruments.Text = "";
            Packet loadProfilePacket = new Packet(Packet.PacketType.ProfileLoad, Connection.id);
            loadProfilePacket.gData.Add(userProfileEmail);
            Connection.master.Send(loadProfilePacket.ToBytes());

            Thread.Sleep(500);

            labelName.Text = Connection.userFName + " " + Connection.userSName;
            string instrumnets = Connection.instruments;
            string[] arrayInstruments = Regex.Split(instrumnets, ";");

            if (arrayInstruments.Length > 1)
            {
                for (int i = 0; i < arrayInstruments.Length; i++)
                {
                    if(i == arrayInstruments.Length - 1)
                    {
                        labelListOfInstruments.Text += arrayInstruments[i];
                    }
                    else
                    {
                        labelListOfInstruments.Text += arrayInstruments[i] + ",";
                    }
                }
            }
            else
            {
                labelListOfInstruments.Text += arrayInstruments[0].ToLower();
            }

            labelCity.Text = Connection.userCity;
            labelListOfBands.Text = Connection.memberOf;
            tbPersonalDesc.Text = Connection.description;
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPostAd_Click(object sender, EventArgs e)
        {
            PostAdWindow newWindow = new PostAdWindow();
            newWindow.StartPosition = FormStartPosition.Manual;
            newWindow.Location = new Point(this.Location.X, this.Location.Y);
            newWindow.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchWindow newWindow = new SearchWindow();
            newWindow.StartPosition = FormStartPosition.Manual;
            newWindow.Location = new Point(this.Location.X, this.Location.Y);
            newWindow.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
