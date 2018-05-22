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
    public partial class SearchWindow : Form
    {
        public SearchWindow()
        {
            InitializeComponent();
        }

        private void SearchWindow_Load(object sender, EventArgs e)
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
            cbGenre.Items.Add("Rock");
            cbGenre.Items.Add("Pop");
            cbGenre.Items.Add("Heavy Metal");
            cbGenre.Items.Add("Death Metal");

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "ID";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 30;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Email";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 100;

            ColumnHeader columnHeader3 = new ColumnHeader();
            columnHeader3.Text = "Title";
            columnHeader3.TextAlign = HorizontalAlignment.Left;
            columnHeader3.Width = 230;

            listView.Columns.Add(columnHeader1);
            listView.Columns.Add(columnHeader2);
            listView.Columns.Add(columnHeader3);
        }

        private void button7_Click(object sender, EventArgs e) // show results
        {
            if (cbAdType.SelectedItem != null && cbGenre.SelectedItem != null && cbInstrument != null)
            {
                Packet searchQuery = new Packet(Packet.PacketType.Search, Connection.id);
                searchQuery.gData.Add(cbAdType.SelectedItem.ToString());
                searchQuery.gData.Add(cbGenre.SelectedItem.ToString());
                searchQuery.gData.Add(cbInstrument.SelectedItem.ToString());
                Connection.master.Send(searchQuery.ToBytes());

                Thread.Sleep(400);

                if (Connection.findedTitles.Length > 0)
                {
                    for (int i = 0; i < Connection.findedemail.Length; i++)
                    {
                        ListViewItem listItem = new ListViewItem(i.ToString());
                        listItem.SubItems.Add(Connection.findedemail[i]);
                        listItem.SubItems.Add(Connection.findedTitles[i]);
                        listView.Items.Add(listItem);
                    }
                }
                else
                {
                    MessageBox.Show("No results!");
                }
            }
            else
            {
                MessageBox.Show("Fill all combo boxes!");
            }
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems != null)
            {
                string id = listView.FocusedItem.Text;
                int intID = int.Parse(id);
                MessageBox.Show(Connection.findedemail[intID] + "\n" + Connection.findedTitles[intID] + "\n" + Connection.findedDesc[intID]);
            }
            else
            {
                MessageBox.Show("Pick ad from list!");
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

        }

        private void btnPostAd_Click(object sender, EventArgs e)
        {
            PostAdWindow newWindow = new PostAdWindow();
            newWindow.StartPosition = FormStartPosition.Manual;
            newWindow.Location = new Point(this.Location.X, this.Location.Y);
            newWindow.Show();
            this.Close();
        }
    }
}
