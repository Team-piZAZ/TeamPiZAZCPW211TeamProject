namespace TeamPiZAZCPW211TeamProject.Forms
{
    partial class AnimeDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimeDetailsForm));
            txtTitle = new TextBox();
            txtSynopsis = new TextBox();
            dtpReleaseDate = new DateTimePicker();
            clbGenres = new CheckedListBox();
            btnSave = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            cmbTvRating = new ComboBox();
            lblRating = new Label();
            panel4 = new Panel();
            panel5 = new Panel();
            lblReleaseDate = new Label();
            panel6 = new Panel();
            btnManageGenres = new Button();
            panel7 = new Panel();
            panel8 = new Panel();
            lblEpisodes = new Label();
            numEpisodes = new NumericUpDown();
            panel9 = new Panel();
            lblPublicationYear = new Label();
            numPublicationYear = new NumericUpDown();
            lblGenres = new Label();
            panel10 = new Panel();
            btnEditAnime = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numEpisodes).BeginInit();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPublicationYear).BeginInit();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.FromArgb(30, 30, 30);
            txtTitle.BorderStyle = BorderStyle.None;
            txtTitle.Dock = DockStyle.Fill;
            txtTitle.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.ForeColor = Color.White;
            txtTitle.Location = new Point(3, 3);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Title goes here...";
            txtTitle.Size = new Size(549, 29);
            txtTitle.TabIndex = 0;
            // 
            // txtSynopsis
            // 
            txtSynopsis.BackColor = Color.FromArgb(30, 30, 30);
            txtSynopsis.BorderStyle = BorderStyle.FixedSingle;
            txtSynopsis.Dock = DockStyle.Fill;
            txtSynopsis.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSynopsis.ForeColor = Color.White;
            txtSynopsis.Location = new Point(3, 3);
            txtSynopsis.Multiline = true;
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.PlaceholderText = "Short Description . . .";
            txtSynopsis.Size = new Size(553, 145);
            txtSynopsis.TabIndex = 1;
            // 
            // dtpReleaseDate
            // 
            dtpReleaseDate.CalendarMonthBackground = SystemColors.ControlDarkDark;
            dtpReleaseDate.CustomFormat = "MM/yyyy";
            dtpReleaseDate.Dock = DockStyle.Right;
            dtpReleaseDate.Format = DateTimePickerFormat.Custom;
            dtpReleaseDate.Location = new Point(149, 4);
            dtpReleaseDate.Margin = new Padding(3, 4, 3, 4);
            dtpReleaseDate.Name = "dtpReleaseDate";
            dtpReleaseDate.Size = new Size(89, 27);
            dtpReleaseDate.TabIndex = 3;
            // 
            // clbGenres
            // 
            clbGenres.BackColor = Color.FromArgb(30, 30, 30);
            clbGenres.BorderStyle = BorderStyle.FixedSingle;
            clbGenres.Dock = DockStyle.Fill;
            clbGenres.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clbGenres.ForeColor = Color.White;
            clbGenres.FormattingEnabled = true;
            clbGenres.Location = new Point(3, 3);
            clbGenres.MultiColumn = true;
            clbGenres.Name = "clbGenres";
            clbGenres.Size = new Size(553, 118);
            clbGenres.Sorted = true;
            clbGenres.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.BackgroundImage = (Image)resources.GetObject("btnSave.BackgroundImage");
            btnSave.BackgroundImageLayout = ImageLayout.Stretch;
            btnSave.Dock = DockStyle.Fill;
            btnSave.FlatStyle = FlatStyle.Popup;
            btnSave.Font = new Font("Verdana", 24F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.Lime;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(553, 117);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Magenta;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtSynopsis);
            panel1.Location = new Point(71, 189);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3, 3, 3, 3);
            panel1.Size = new Size(561, 153);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Magenta;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtTitle);
            panel2.Location = new Point(71, 21);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(3, 3, 3, 3);
            panel2.Size = new Size(557, 37);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Magenta;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(cmbTvRating);
            panel3.Controls.Add(lblRating);
            panel3.Location = new Point(71, 76);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(3, 4, 3, 4);
            panel3.Size = new Size(228, 34);
            panel3.TabIndex = 8;
            // 
            // cmbTvRating
            // 
            cmbTvRating.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            cmbTvRating.BackColor = Color.FromArgb(30, 30, 30);
            cmbTvRating.FlatStyle = FlatStyle.Flat;
            cmbTvRating.ForeColor = Color.White;
            cmbTvRating.FormattingEnabled = true;
            cmbTvRating.Location = new Point(118, 1);
            cmbTvRating.Margin = new Padding(3, 4, 3, 4);
            cmbTvRating.Name = "cmbTvRating";
            cmbTvRating.Size = new Size(105, 28);
            cmbTvRating.TabIndex = 4;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.BackColor = Color.Transparent;
            lblRating.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRating.ForeColor = Color.White;
            lblRating.Location = new Point(7, 1);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(110, 25);
            lblRating.TabIndex = 3;
            lblRating.Text = "TV Rating";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Magenta;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(clbGenres);
            panel4.Location = new Point(71, 387);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(3, 3, 3, 3);
            panel4.Size = new Size(561, 126);
            panel4.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Magenta;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(lblReleaseDate);
            panel5.Controls.Add(dtpReleaseDate);
            panel5.Location = new Point(385, 76);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(3, 4, 3, 4);
            panel5.Size = new Size(243, 38);
            panel5.TabIndex = 10;
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.AutoSize = true;
            lblReleaseDate.BackColor = Color.Transparent;
            lblReleaseDate.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReleaseDate.ForeColor = Color.White;
            lblReleaseDate.Location = new Point(7, 5);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(144, 25);
            lblReleaseDate.TabIndex = 4;
            lblReleaseDate.Text = "Release Date";
            // 
            // panel6
            // 
            panel6.BackColor = Color.Lime;
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(btnSave);
            panel6.Location = new Point(71, 665);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(3, 3, 3, 3);
            panel6.Size = new Size(561, 125);
            panel6.TabIndex = 11;
            // 
            // btnManageGenres
            // 
            btnManageGenres.BackColor = Color.DarkTurquoise;
            btnManageGenres.Dock = DockStyle.Fill;
            btnManageGenres.FlatStyle = FlatStyle.Popup;
            btnManageGenres.Font = new Font("Verdana", 12F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnManageGenres.ForeColor = Color.Lime;
            btnManageGenres.Location = new Point(3, 4);
            btnManageGenres.Margin = new Padding(3, 4, 3, 4);
            btnManageGenres.Name = "btnManageGenres";
            btnManageGenres.Size = new Size(553, 41);
            btnManageGenres.TabIndex = 12;
            btnManageGenres.Text = "Manage Genres";
            btnManageGenres.UseVisualStyleBackColor = false;
            btnManageGenres.Click += btnManageGenres_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Lime;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(btnManageGenres);
            panel7.Location = new Point(71, 607);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(3, 4, 3, 4);
            panel7.Size = new Size(561, 51);
            panel7.TabIndex = 13;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Magenta;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(lblEpisodes);
            panel8.Controls.Add(numEpisodes);
            panel8.Location = new Point(71, 132);
            panel8.Margin = new Padding(3, 4, 3, 4);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(3, 4, 3, 4);
            panel8.Size = new Size(228, 38);
            panel8.TabIndex = 14;
            // 
            // lblEpisodes
            // 
            lblEpisodes.AutoSize = true;
            lblEpisodes.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEpisodes.ForeColor = SystemColors.Window;
            lblEpisodes.Location = new Point(9, 4);
            lblEpisodes.Name = "lblEpisodes";
            lblEpisodes.Size = new Size(99, 25);
            lblEpisodes.TabIndex = 1;
            lblEpisodes.Text = "Episodes";
            // 
            // numEpisodes
            // 
            numEpisodes.BackColor = Color.FromArgb(30, 30, 30);
            numEpisodes.BorderStyle = BorderStyle.FixedSingle;
            numEpisodes.Dock = DockStyle.Right;
            numEpisodes.ForeColor = SystemColors.Window;
            numEpisodes.Location = new Point(118, 4);
            numEpisodes.Margin = new Padding(3, 4, 3, 4);
            numEpisodes.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numEpisodes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numEpisodes.Name = "numEpisodes";
            numEpisodes.Size = new Size(105, 27);
            numEpisodes.TabIndex = 0;
            numEpisodes.ThousandsSeparator = true;
            numEpisodes.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // panel9
            // 
            panel9.BackColor = Color.Magenta;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(lblPublicationYear);
            panel9.Controls.Add(numPublicationYear);
            panel9.Location = new Point(385, 132);
            panel9.Margin = new Padding(3, 4, 3, 4);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(3, 4, 3, 4);
            panel9.Size = new Size(243, 38);
            panel9.TabIndex = 15;
            // 
            // lblPublicationYear
            // 
            lblPublicationYear.AutoSize = true;
            lblPublicationYear.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPublicationYear.ForeColor = SystemColors.Window;
            lblPublicationYear.Location = new Point(-1, 4);
            lblPublicationYear.Name = "lblPublicationYear";
            lblPublicationYear.Size = new Size(173, 25);
            lblPublicationYear.TabIndex = 1;
            lblPublicationYear.Text = "Publication Year";
            // 
            // numPublicationYear
            // 
            numPublicationYear.BackColor = Color.FromArgb(30, 30, 30);
            numPublicationYear.BorderStyle = BorderStyle.FixedSingle;
            numPublicationYear.ForeColor = SystemColors.Window;
            numPublicationYear.Location = new Point(174, 4);
            numPublicationYear.Margin = new Padding(3, 4, 3, 4);
            numPublicationYear.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPublicationYear.Minimum = new decimal(new int[] { 1940, 0, 0, 0 });
            numPublicationYear.Name = "numPublicationYear";
            numPublicationYear.Size = new Size(64, 27);
            numPublicationYear.TabIndex = 0;
            numPublicationYear.Value = new decimal(new int[] { 1940, 0, 0, 0 });
            // 
            // lblGenres
            // 
            lblGenres.AutoSize = true;
            lblGenres.BackColor = Color.Transparent;
            lblGenres.Font = new Font("Verdana", 12F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblGenres.ForeColor = Color.Turquoise;
            lblGenres.Location = new Point(75, 356);
            lblGenres.Name = "lblGenres";
            lblGenres.Size = new Size(90, 25);
            lblGenres.TabIndex = 16;
            lblGenres.Text = "Genres";
            // 
            // panel10
            // 
            panel10.BackColor = Color.Lime;
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(btnEditAnime);
            panel10.Location = new Point(71, 543);
            panel10.Margin = new Padding(3, 4, 3, 4);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(3, 4, 3, 4);
            panel10.Size = new Size(561, 55);
            panel10.TabIndex = 17;
            // 
            // btnEditAnime
            // 
            btnEditAnime.BackColor = Color.DarkTurquoise;
            btnEditAnime.Dock = DockStyle.Fill;
            btnEditAnime.FlatStyle = FlatStyle.Popup;
            btnEditAnime.Font = new Font("Verdana", 12F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnEditAnime.ForeColor = Color.Lime;
            btnEditAnime.Location = new Point(3, 4);
            btnEditAnime.Margin = new Padding(3, 4, 3, 4);
            btnEditAnime.Name = "btnEditAnime";
            btnEditAnime.Size = new Size(553, 45);
            btnEditAnime.TabIndex = 0;
            btnEditAnime.Text = "Edit Anime";
            btnEditAnime.UseVisualStyleBackColor = false;
            btnEditAnime.Click += btnEditAnime_Click;
            // 
            // AnimeDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(711, 824);
            Controls.Add(panel10);
            Controls.Add(lblGenres);
            Controls.Add(panel9);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AnimeDetailsForm";
            Text = "AnimeDetailsForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numEpisodes).EndInit();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPublicationYear).EndInit();
            panel10.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtSynopsis;
        private DateTimePicker dtpReleaseDate;
        private CheckedListBox clbGenres;
        private Button btnSave;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label lblRating;
        private Label lblReleaseDate;
        private Button btnManageGenres;
        private Panel panel7;
        private ComboBox cmbTvRating;
        private Panel panel8;
        private NumericUpDown numEpisodes;
        private Panel panel9;
        private Label lblEpisodes;
        private Label lblPublicationYear;
        private NumericUpDown numPublicationYear;
        private Label lblGenres;
        private Panel panel10;
        private Button btnEditAnime;
    }
}