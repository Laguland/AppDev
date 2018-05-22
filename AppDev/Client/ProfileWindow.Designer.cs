namespace Client
{
    partial class ProfileWindow
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
            this.btnMyProfile = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPostAd = new System.Windows.Forms.Button();
            this.btnMyBands = new System.Windows.Forms.Button();
            this.btnFriends = new System.Windows.Forms.Button();
            this.pbProfilePhoto = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.tbPersonalDesc = new System.Windows.Forms.TextBox();
            this.labelListOfInstruments = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelListOfBands = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMyProfile
            // 
            this.btnMyProfile.Location = new System.Drawing.Point(12, 285);
            this.btnMyProfile.Name = "btnMyProfile";
            this.btnMyProfile.Size = new System.Drawing.Size(65, 25);
            this.btnMyProfile.TabIndex = 0;
            this.btnMyProfile.Text = "My profile";
            this.btnMyProfile.UseVisualStyleBackColor = true;
            this.btnMyProfile.Click += new System.EventHandler(this.btnMyProfile_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(82, 285);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 25);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPostAd
            // 
            this.btnPostAd.Location = new System.Drawing.Point(152, 285);
            this.btnPostAd.Name = "btnPostAd";
            this.btnPostAd.Size = new System.Drawing.Size(65, 25);
            this.btnPostAd.TabIndex = 2;
            this.btnPostAd.Text = "Post ad";
            this.btnPostAd.UseVisualStyleBackColor = true;
            this.btnPostAd.Click += new System.EventHandler(this.btnPostAd_Click);
            // 
            // btnMyBands
            // 
            this.btnMyBands.Location = new System.Drawing.Point(291, 285);
            this.btnMyBands.Name = "btnMyBands";
            this.btnMyBands.Size = new System.Drawing.Size(65, 25);
            this.btnMyBands.TabIndex = 3;
            this.btnMyBands.Text = "My bands";
            this.btnMyBands.UseVisualStyleBackColor = true;
            // 
            // btnFriends
            // 
            this.btnFriends.Location = new System.Drawing.Point(222, 285);
            this.btnFriends.Name = "btnFriends";
            this.btnFriends.Size = new System.Drawing.Size(65, 25);
            this.btnFriends.TabIndex = 4;
            this.btnFriends.Text = "Friends";
            this.btnFriends.UseVisualStyleBackColor = true;
            // 
            // pbProfilePhoto
            // 
            this.pbProfilePhoto.Location = new System.Drawing.Point(13, 13);
            this.pbProfilePhoto.Name = "pbProfilePhoto";
            this.pbProfilePhoto.Size = new System.Drawing.Size(104, 90);
            this.pbProfilePhoto.TabIndex = 5;
            this.pbProfilePhoto.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(124, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(92, 13);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "<Name Surname>";
            // 
            // tbPersonalDesc
            // 
            this.tbPersonalDesc.Location = new System.Drawing.Point(13, 122);
            this.tbPersonalDesc.Multiline = true;
            this.tbPersonalDesc.Name = "tbPersonalDesc";
            this.tbPersonalDesc.Size = new System.Drawing.Size(342, 157);
            this.tbPersonalDesc.TabIndex = 7;
            // 
            // labelListOfInstruments
            // 
            this.labelListOfInstruments.AutoSize = true;
            this.labelListOfInstruments.Location = new System.Drawing.Point(194, 36);
            this.labelListOfInstruments.Name = "labelListOfInstruments";
            this.labelListOfInstruments.Size = new System.Drawing.Size(103, 13);
            this.labelListOfInstruments.TabIndex = 9;
            this.labelListOfInstruments.Text = "<List of instruments>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Member of:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Instruments:";
            // 
            // labelListOfBands
            // 
            this.labelListOfBands.AutoSize = true;
            this.labelListOfBands.Location = new System.Drawing.Point(191, 65);
            this.labelListOfBands.Name = "labelListOfBands";
            this.labelListOfBands.Size = new System.Drawing.Size(79, 13);
            this.labelListOfBands.TabIndex = 12;
            this.labelListOfBands.Text = "<List of bands>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Personal Description:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(125, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "City:";
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(149, 90);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(36, 13);
            this.labelCity.TabIndex = 15;
            this.labelCity.Text = "<City>";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(291, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Edit profile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProfileWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 321);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelListOfBands);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelListOfInstruments);
            this.Controls.Add(this.tbPersonalDesc);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.pbProfilePhoto);
            this.Controls.Add(this.btnFriends);
            this.Controls.Add(this.btnMyBands);
            this.Controls.Add(this.btnPostAd);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnMyProfile);
            this.Name = "ProfileWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.ProfileWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMyProfile;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPostAd;
        private System.Windows.Forms.Button btnMyBands;
        private System.Windows.Forms.Button btnFriends;
        private System.Windows.Forms.PictureBox pbProfilePhoto;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox tbPersonalDesc;
        private System.Windows.Forms.Label labelListOfInstruments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelListOfBands;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Button button1;
    }
}