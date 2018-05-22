using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ServerData;

namespace Client
{
    public partial class LogInWindow : Form
    {
        string stringIP = "192.168.0.8";
        int port = 7009;

        public LogInWindow()
        {
            InitializeComponent();
        }

        private void LogInWindow_Load(object sender, EventArgs e)
        {
            if (!Connection.IsConnected())
            {
                Connection.ConnectToServer(stringIP, port);
            }

            if (Connection.IsConnected())
            {
                btnTryAgain.Visible = false;
                labelConnecting.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                tbIP.Visible = false;
                tbPort.Visible = false;

                labelEmail.Visible = true;
                labelPassword.Visible = true;
                tbEmail.Visible = true;
                tbPassword.Visible = true;
                btnLogIn.Visible = true;
                btnSignUp.Visible = true;
        }
            else
            {
                labelConnecting.Text = "Cannot connect to server!";
                btnTryAgain.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                tbIP.Visible = true;
                tbPort.Visible = true;
            }
}

        private void btnTryAgain_Click(object sender, EventArgs e)
        {
            Connection.ConnectToServer(tbIP.Text, int.Parse(tbPort.Text));

            if (Connection.IsConnected())
            {
                btnTryAgain.Visible = false;
                labelConnecting.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                tbIP.Visible = false;
                tbPort.Visible = false;

                labelEmail.Visible = true;
                labelPassword.Visible = true;
                tbEmail.Visible = true;
                tbPassword.Visible = true;
                btnLogIn.Visible = true;
                btnSignUp.Visible = true;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Packet logInPacket = new Packet(Packet.PacketType.LogIn, Connection.id);
            Connection.loggedUserEmail = tbEmail.Text;
            logInPacket.gData.Add(tbEmail.Text);
            logInPacket.gData.Add(tbPassword.Text);
            Connection.master.Send(logInPacket.ToBytes());

            Thread.Sleep(500);
            if (Connection.isValidUser)
            {
                ProfileWindow newWindow = new ProfileWindow(Connection.loggedUserEmail);
                newWindow.StartPosition = FormStartPosition.Manual;
                newWindow.Location = new Point(this.Location.X, this.Location.Y);
                newWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(Connection.logInMessage);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpWindow newWindow = new SignUpWindow(this);
            newWindow.StartPosition = FormStartPosition.Manual;
            newWindow.Location = new Point(this.Location.X, this.Location.Y);
            newWindow.Show();
            this.Hide();
        }
    }
}
