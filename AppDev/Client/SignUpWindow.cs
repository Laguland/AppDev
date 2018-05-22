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
using unirest_net.request;
using unirest_net.http;
using System.Text.RegularExpressions;

namespace Client
{
    public partial class SignUpWindow : Form
    {
        LogInWindow logInWindow;

        public SignUpWindow(LogInWindow logInWindow)
        {
            this.logInWindow = logInWindow;
            InitializeComponent();
        }

        private void SignUpWindow_Load(object sender, EventArgs e)
        {
            tbDOB.Text = "dd/mm/yyyy";
        }

        private string ChangeEmailString(string email) // replace '@' with "%40"
        {
            string[] splitString = Regex.Split(email, "@");
            string newEmailString;

            if (splitString.Length == 2)
            {
                newEmailString = splitString[0] + "%40" + splitString[1];
                return newEmailString;
            }
            else
            {
                newEmailString = splitString[0];
                return newEmailString;
            }
        }

        private bool CheckDateString(string date)
        {
            string[] dateFields = Regex.Split(date, "/");
            int day, month, year;

            try
            {
                day = int.Parse(dateFields[0]);
                month = int.Parse(dateFields[1]);
                year = int.Parse(dateFields[2]);

                if(day > 0 && day < 32)
                {
                    if(month > 0 && month < 13)
                    {
                        if(year > 1900 && year < 2016)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string emailString = ChangeEmailString(tbEmail.Text);
            // These code snippets use an open-source library. http://unirest.io/net
            Task<HttpResponse<EWSemail>> response = Unirest.get("https://pozzad-email-validator.p.mashape.com/emailvalidator/validateEmail/"+ emailString) // "%40gmail.com"
            .header("X-Mashape-Key", "OnBgGH6OwPmshXGPQWCLf7BbP8Rbp1fedDajsnG7nvWOxohRJS")
            .header("Accept", "application/json")
            .asJsonAsync<EWSemail>();

            if (!string.IsNullOrWhiteSpace(tbCity.Text) && !string.IsNullOrWhiteSpace(tbDOB.Text) && !string.IsNullOrWhiteSpace(tbEmail.Text) &&
                !string.IsNullOrWhiteSpace(tbFName.Text) && !string.IsNullOrWhiteSpace(tbPassword.Text) && !string.IsNullOrWhiteSpace(tbPassword2.Text) &&
                !string.IsNullOrWhiteSpace(tbSName.Text))
            {
                if (tbDOB.Text.Length == 10 && CheckDateString(tbDOB.Text))
                {
                    if (response.Result.Body.isValid)
                    {
                        Packet checkEmail = new Packet(Packet.PacketType.CheckDuplicate, Connection.id);
                        checkEmail.gData.Add(tbEmail.Text);
                        Connection.master.Send(checkEmail.ToBytes());
                        Thread.Sleep(500);

                        if (!Connection.checkedEmail) // if checkedEmail = true email address is taken
                        {
                            if (tbPassword.Text == tbPassword2.Text)
                            {
                                Packet newSignUpPacket = new Packet(Packet.PacketType.SignUp, Connection.id);
                                newSignUpPacket.gData.Add(tbEmail.Text);
                                newSignUpPacket.gData.Add(tbFName.Text);
                                newSignUpPacket.gData.Add(tbSName.Text);
                                newSignUpPacket.gData.Add(tbDOB.Text);
                                newSignUpPacket.gData.Add(tbCity.Text);
                                newSignUpPacket.gData.Add(tbPassword.Text);

                                Connection.master.Send(newSignUpPacket.ToBytes());
                            }
                            else
                            {
                                MessageBox.Show("Passwords are different!");
                            }
                            Thread.Sleep(1000);
                            if (Connection.newUserRegistered)
                            {
                                MessageBox.Show("success");
                            }
                            else
                            {
                                MessageBox.Show("fail");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Email address is taken!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email address is not valid!");
                    }
                }
                else
                {
                    MessageBox.Show("Date syntax is wrong!");
                }
            }
            else
            {
                MessageBox.Show("Fill all fields!");
            }
}

        private void button2_Click(object sender, EventArgs e) // back
        {
            logInWindow.Show();
            Close();
        }
    }
}
