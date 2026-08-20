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
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.FromArgb(30, 30, 30);
            txtTitle.BorderStyle = BorderStyle.None;
            txtTitle.Dock = DockStyle.Fill;
            txtTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.ForeColor = Color.White;
            txtTitle.Location = new Point(3, 2);
            txtTitle.Margin = new Padding(3, 2, 3, 2);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Title goes here...";
            txtTitle.Size = new Size(480, 22);
            txtTitle.TabIndex = 0;
            // 
            // txtSynopsis
            // 
            txtSynopsis.BackColor = Color.FromArgb(30, 30, 30);
            txtSynopsis.BorderStyle = BorderStyle.None;
            txtSynopsis.Dock = DockStyle.Fill;
            txtSynopsis.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSynopsis.ForeColor = Color.White;
            txtSynopsis.Location = new Point(3, 2);
            txtSynopsis.Margin = new Padding(3, 2, 3, 2);
            txtSynopsis.Multiline = true;
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.PlaceholderText = "Short Description . . .";
            txtSynopsis.Size = new Size(483, 146);
            txtSynopsis.TabIndex = 1;
            // 
            // dtpReleaseDate
            // 
            dtpReleaseDate.CalendarMonthBackground = SystemColors.ControlDarkDark;
            dtpReleaseDate.CustomFormat = "MM/yyyy";
            dtpReleaseDate.Dock = DockStyle.Right;
            dtpReleaseDate.Format = DateTimePickerFormat.Custom;
            dtpReleaseDate.Location = new Point(108, 3);
            dtpReleaseDate.Name = "dtpReleaseDate";
            dtpReleaseDate.Size = new Size(100, 23);
            dtpReleaseDate.TabIndex = 3;
            // 
            // clbGenres
            // 
            clbGenres.BackColor = Color.FromArgb(30, 30, 30);
            clbGenres.BorderStyle = BorderStyle.None;
            clbGenres.Dock = DockStyle.Fill;
            clbGenres.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clbGenres.ForeColor = Color.White;
            clbGenres.FormattingEnabled = true;
            clbGenres.Location = new Point(3, 2);
            clbGenres.Margin = new Padding(3, 2, 3, 2);
            clbGenres.MultiColumn = true;
            clbGenres.Name = "clbGenres";
            clbGenres.Size = new Size(483, 111);
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
            btnSave.Location = new Point(3, 2);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(483, 88);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Magenta;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtSynopsis);
            panel1.Location = new Point(62, 142);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3, 2, 3, 2);
            panel1.Size = new Size(491, 152);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Magenta;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtTitle);
            panel2.Location = new Point(62, 16);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(3, 2, 3, 2);
            panel2.Size = new Size(488, 28);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Magenta;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(cmbTvRating);
            panel3.Controls.Add(lblRating);
            panel3.Location = new Point(62, 57);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(3);
            panel3.Size = new Size(200, 26);
            panel3.TabIndex = 8;
            // 
            // cmbTvRating
            // 
            cmbTvRating.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            cmbTvRating.BackColor = Color.FromArgb(30, 30, 30);
            cmbTvRating.FlatStyle = FlatStyle.Flat;
            cmbTvRating.ForeColor = Color.White;
            cmbTvRating.FormattingEnabled = true;
            cmbTvRating.Location = new Point(103, 1);
            cmbTvRating.Name = "cmbTvRating";
            cmbTvRating.Size = new Size(92, 23);
            cmbTvRating.TabIndex = 4;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.BackColor = Color.Transparent;
            lblRating.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRating.ForeColor = Color.White;
            lblRating.Location = new Point(6, 1);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(70, 20);
            lblRating.TabIndex = 3;
            lblRating.Text = "Tv Rating";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Magenta;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(clbGenres);
            panel4.Location = new Point(62, 322);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(3, 2, 3, 2);
            panel4.Size = new Size(491, 117);
            panel4.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Magenta;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(lblReleaseDate);
            panel5.Controls.Add(dtpReleaseDate);
            panel5.Location = new Point(337, 57);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(3);
            panel5.Size = new Size(213, 29);
            panel5.TabIndex = 10;
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.AutoSize = true;
            lblReleaseDate.BackColor = Color.Transparent;
            lblReleaseDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReleaseDate.ForeColor = Color.White;
            lblReleaseDate.Location = new Point(6, 4);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(96, 20);
            lblReleaseDate.TabIndex = 4;
            lblReleaseDate.Text = "Release Date";
            // 
            // panel6
            // 
            panel6.BackColor = Color.Lime;
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(btnSave);
            panel6.Location = new Point(62, 499);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(3, 2, 3, 2);
            panel6.Size = new Size(491, 94);
            panel6.TabIndex = 11;
            // 
            // btnManageGenres
            // 
            btnManageGenres.BackColor = Color.DarkTurquoise;
            btnManageGenres.Dock = DockStyle.Fill;
            btnManageGenres.FlatStyle = FlatStyle.Popup;
            btnManageGenres.Location = new Point(3, 3);
            btnManageGenres.Name = "btnManageGenres";
            btnManageGenres.Size = new Size(483, 21);
            btnManageGenres.TabIndex = 12;
            btnManageGenres.Text = "Manage Genres";
            btnManageGenres.UseVisualStyleBackColor = false;
            btnManageGenres.Click += btnManageGenres_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Magenta;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(btnManageGenres);
            panel7.Location = new Point(62, 455);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(3);
            panel7.Size = new Size(491, 29);
            panel7.TabIndex = 13;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Magenta;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(lblEpisodes);
            panel8.Controls.Add(numEpisodes);
            panel8.Location = new Point(62, 99);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(3);
            panel8.Size = new Size(200, 29);
            panel8.TabIndex = 14;
            // 
            // lblEpisodes
            // 
            lblEpisodes.AutoSize = true;
            lblEpisodes.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEpisodes.ForeColor = SystemColors.Window;
            lblEpisodes.Location = new Point(8, 3);
            lblEpisodes.Name = "lblEpisodes";
            lblEpisodes.Size = new Size(68, 20);
            lblEpisodes.TabIndex = 1;
            lblEpisodes.Text = "Episodes";
            // 
            // numEpisodes
            // 
            numEpisodes.BackColor = Color.FromArgb(30, 30, 30);
            numEpisodes.BorderStyle = BorderStyle.FixedSingle;
            numEpisodes.Dock = DockStyle.Right;
            numEpisodes.ForeColor = SystemColors.Window;
            numEpisodes.Location = new Point(103, 3);
            numEpisodes.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numEpisodes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numEpisodes.Name = "numEpisodes";
            numEpisodes.Size = new Size(92, 23);
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
            panel9.Location = new Point(337, 99);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(3);
            panel9.Size = new Size(213, 29);
            panel9.TabIndex = 15;
            // 
            // lblPublicationYear
            // 
            lblPublicationYear.AutoSize = true;
            lblPublicationYear.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPublicationYear.ForeColor = SystemColors.Window;
            lblPublicationYear.Location = new Point(6, 3);
            lblPublicationYear.Name = "lblPublicationYear";
            lblPublicationYear.Size = new Size(115, 20);
            lblPublicationYear.TabIndex = 1;
            lblPublicationYear.Text = "Publication Year";
            // 
            // numPublicationYear
            // 
            numPublicationYear.BackColor = Color.FromArgb(30, 30, 30);
            numPublicationYear.BorderStyle = BorderStyle.FixedSingle;
            numPublicationYear.ForeColor = SystemColors.Window;
            numPublicationYear.Location = new Point(127, 3);
            numPublicationYear.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPublicationYear.Minimum = new decimal(new int[] { 1940, 0, 0, 0 });
            numPublicationYear.Name = "numPublicationYear";
            numPublicationYear.Size = new Size(81, 23);
            numPublicationYear.TabIndex = 0;
            numPublicationYear.Value = new decimal(new int[] { 1940, 0, 0, 0 });
            // 
            // AnimeDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(635, 618);
            Controls.Add(panel9);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
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
            ResumeLayout(false);
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
    }
}