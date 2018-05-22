namespace Client
{
    partial class SearchWindow
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
            this.cbAdType = new System.Windows.Forms.ComboBox();
            this.cbInstrument = new System.Windows.Forms.ComboBox();
            this.cbGenre = new System.Windows.Forms.ComboBox();
            this.listView = new System.Windows.Forms.ListView();
            this.btnMyProfile = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPostAd = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.btnShowResults = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbAdType
            // 
            this.cbAdType.FormattingEnabled = true;
            this.cbAdType.Location = new System.Drawing.Point(72, 15);
            this.cbAdType.Name = "cbAdType";
            this.cbAdType.Size = new System.Drawing.Size(290, 21);
            this.cbAdType.TabIndex = 0;
            // 
            // cbInstrument
            // 
            this.cbInstrument.FormattingEnabled = true;
            this.cbInstrument.Location = new System.Drawing.Point(72, 42);
            this.cbInstrument.Name = "cbInstrument";
            this.cbInstrument.Size = new System.Drawing.Size(290, 21);
            this.cbInstrument.TabIndex = 1;
            // 
            // cbGenre
            // 
            this.cbGenre.FormattingEnabled = true;
            this.cbGenre.Location = new System.Drawing.Point(72, 69);
            this.cbGenre.Name = "cbGenre";
            this.cbGenre.Size = new System.Drawing.Size(290, 21);
            this.cbGenre.TabIndex = 2;
            // 
            // listView
            // 
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 96);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(350, 155);
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // btnMyProfile
            // 
            this.btnMyProfile.Location = new System.Drawing.Point(12, 286);
            this.btnMyProfile.Name = "btnMyProfile";
            this.btnMyProfile.Size = new System.Drawing.Size(65, 25);
            this.btnMyProfile.TabIndex = 4;
            this.btnMyProfile.Text = "My profile";
            this.btnMyProfile.UseVisualStyleBackColor = true;
            this.btnMyProfile.Click += new System.EventHandler(this.btnMyProfile_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(83, 286);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 25);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPostAd
            // 
            this.btnPostAd.Location = new System.Drawing.Point(154, 286);
            this.btnPostAd.Name = "btnPostAd";
            this.btnPostAd.Size = new System.Drawing.Size(65, 25);
            this.btnPostAd.TabIndex = 6;
            this.btnPostAd.Text = "Post ad";
            this.btnPostAd.UseVisualStyleBackColor = true;
            this.btnPostAd.Click += new System.EventHandler(this.btnPostAd_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(225, 285);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 25);
            this.button4.TabIndex = 7;
            this.button4.Text = "Friends";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(296, 286);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(65, 25);
            this.button5.TabIndex = 8;
            this.button5.Text = "My bands";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.Location = new System.Drawing.Point(287, 257);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(75, 23);
            this.btnShowDetails.TabIndex = 9;
            this.btnShowDetails.Text = "Show details";
            this.btnShowDetails.UseVisualStyleBackColor = true;
            this.btnShowDetails.Click += new System.EventHandler(this.btnShowDetails_Click);
            // 
            // btnShowResults
            // 
            this.btnShowResults.Location = new System.Drawing.Point(12, 257);
            this.btnShowResults.Name = "btnShowResults";
            this.btnShowResults.Size = new System.Drawing.Size(75, 23);
            this.btnShowResults.TabIndex = 10;
            this.btnShowResults.Text = "Show results";
            this.btnShowResults.UseVisualStyleBackColor = true;
            this.btnShowResults.Click += new System.EventHandler(this.button7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ad type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Instrument:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Genre:";
            // 
            // SearchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 321);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShowResults);
            this.Controls.Add(this.btnShowDetails);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnPostAd);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnMyProfile);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.cbGenre);
            this.Controls.Add(this.cbInstrument);
            this.Controls.Add(this.cbAdType);
            this.Name = "SearchWindow";
            this.Text = "SearchWindow";
            this.Load += new System.EventHandler(this.SearchWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAdType;
        private System.Windows.Forms.ComboBox cbInstrument;
        private System.Windows.Forms.ComboBox cbGenre;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button btnMyProfile;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPostAd;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.Button btnShowResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}