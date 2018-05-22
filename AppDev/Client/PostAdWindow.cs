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

namespace Client
{
    public partial class PostAdWindow : Form
    {
        public PostAdWindow()
        {
            InitializeComponent();
        }

        private void PostAdWindow_Load(object sender, EventArgs e)
        {
            cbAdType.Items.Add("Musician looking for band.");
            cbAdType.Items.Add("Band looking for musician.");
            cbAdType.Items.Add("Musician looking for student.");
            cbAdType.Items.Add("Student looking for musician.");
            cbAdType.Items.Add("Sell gear.");
            cbAdType.Items.Add("Buy gear.");
            cbInstrument.Items.Add("Bass guitar");
            cbInstrument.Items.Add("Piano");
            cbInstrument.Items.Add("Guitar");
            cbInstrument.Items.Add("Drums");
            cbInstrument.Items.Add("Keyboard");
            cbInstrument.Items.Add("Vocal");
            cbMusicGenre.Items.Add("Rock");
            cbMusicGenre.Items.Add("Pop");
            cbMusicGenre.Items.Add("Heavy Metal");
            cbMusicGenre.Items.Add("Death Metal");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSendAdToServer_Click(object sender, EventArgs e)
        {
            if (cbAdType.SelectedItem != null && cbInstrument != null && cbMusicGenre != null && !string.IsNullOrWhiteSpace(tbTitle.Text) && !string.IsNullOrWhiteSpace(tbDesc.Text))
            {
                Packet adPacket = new Packet(Packet.PacketType.PostAd, Connection.id);
                adPacket.gData.Add(tbTitle.Text);
                adPacket.gData.Add(tbDesc.Text);
                adPacket.gData.Add(cbAdType.SelectedItem.ToString());
                adPacket.gData.Add(cbInstrument.SelectedItem.ToString());
                adPacket.gData.Add(cbMusicGenre.SelectedItem.ToString());
                adPacket.gData.Add(Connection.loggedUserEmail);
                Connection.master.Send(adPacket.ToBytes());

                Thread.Sleep(500);

                if (Connection.poadAdSuccess)
                {
                    MessageBox.Show("Success!");
                }
                else
                {
                    MessageBox.Show("Fail!");
                }
            }
            else
            {
                MessageBox.Show("Fill all fields!");
            }
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            ProfileWindow newWindow = new ProfileWindow(Connection.loggedUserEmail);
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
    }
}
