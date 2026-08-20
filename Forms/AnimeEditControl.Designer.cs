namespace TeamPiZAZCPW211TeamProject.Forms
{
    partial class AnimeEditControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimeEditControl));
            txtEditSearch = new TextBox();
            btnSearch = new Button();
            txtTitle = new TextBox();
            lblComment = new Label();
            txtSynopsis = new TextBox();
            cmbEditTvRating = new ComboBox();
            numEpisodes = new NumericUpDown();
            dtpPublicationYear = new DateTimePicker();
            lblTvRating = new Label();
            lblEpisodes = new Label();
            lblPublicationYear = new Label();
            btnSaveChanges = new Button();
            btnCancelChanges = new Button();
            ((System.ComponentModel.ISupportInitialize)numEpisodes).BeginInit();
            SuspendLayout();
            // 
            // txtEditSearch
            // 
            txtEditSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtEditSearch.BackColor = Color.FromArgb(30, 30, 30);
            txtEditSearch.BorderStyle = BorderStyle.FixedSingle;
            txtEditSearch.ForeColor = SystemColors.Window;
            txtEditSearch.Location = new Point(120, 13);
            txtEditSearch.Name = "txtEditSearch";
            txtEditSearch.PlaceholderText = "Name of Anime...";
            txtEditSearch.Size = new Size(321, 27);
            txtEditSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.MenuHighlight;
            btnSearch.FlatStyle = FlatStyle.Popup;
            btnSearch.Font = new Font("Verdana", 12F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(18, 14);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(85, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.FromArgb(30, 30, 30);
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Location = new Point(18, 78);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Edit Title...";
            txtTitle.Size = new Size(423, 27);
            txtTitle.TabIndex = 2;
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.BackColor = Color.Transparent;
            lblComment.Font = new Font("Verdana", 12F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblComment.ForeColor = SystemColors.InactiveCaption;
            lblComment.Location = new Point(30, 43);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(390, 18);
            lblComment.TabIndex = 3;
            lblComment.Text = "Edit Selected Anime Details in the form below";
            // 
            // txtSynopsis
            // 
            txtSynopsis.BackColor = Color.FromArgb(30, 30, 30);
            txtSynopsis.BorderStyle = BorderStyle.FixedSingle;
            txtSynopsis.ForeColor = SystemColors.InactiveCaption;
            txtSynopsis.Location = new Point(18, 123);
            txtSynopsis.Multiline = true;
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.PlaceholderText = "Edit Synopsis...";
            txtSynopsis.ScrollBars = ScrollBars.Vertical;
            txtSynopsis.Size = new Size(423, 66);
            txtSynopsis.TabIndex = 4;
            // 
            // cmbEditTvRating
            // 
            cmbEditTvRating.BackColor = Color.FromArgb(30, 30, 30);
            cmbEditTvRating.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEditTvRating.FormattingEnabled = true;
            cmbEditTvRating.Items.AddRange(new object[] { "TV-Y", "TV-Y7", "TV-G", "TV-PG", "TV-14", "TV-MA" });
            cmbEditTvRating.Location = new Point(18, 228);
            cmbEditTvRating.Name = "cmbEditTvRating";
            cmbEditTvRating.Size = new Size(121, 26);
            cmbEditTvRating.TabIndex = 5;
            // 
            // numEpisodes
            // 
            numEpisodes.BackColor = Color.FromArgb(30, 30, 30);
            numEpisodes.BorderStyle = BorderStyle.FixedSingle;
            numEpisodes.ForeColor = SystemColors.InactiveCaption;
            numEpisodes.Location = new Point(195, 229);
            numEpisodes.Margin = new Padding(4);
            numEpisodes.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numEpisodes.Name = "numEpisodes";
            numEpisodes.Size = new Size(76, 27);
            numEpisodes.TabIndex = 6;
            numEpisodes.TextAlign = HorizontalAlignment.Center;
            numEpisodes.ThousandsSeparator = true;
            // 
            // dtpPublicationYear
            // 
            dtpPublicationYear.CalendarForeColor = Color.FromArgb(30, 30, 30);
            dtpPublicationYear.CalendarMonthBackground = Color.FromArgb(30, 30, 30);
            dtpPublicationYear.CalendarTitleBackColor = Color.FromArgb(30, 30, 30);
            dtpPublicationYear.CalendarTitleForeColor = Color.FromArgb(30, 30, 30);
            dtpPublicationYear.CustomFormat = "yyyy";
            dtpPublicationYear.DropDownAlign = LeftRightAlignment.Right;
            dtpPublicationYear.Format = DateTimePickerFormat.Custom;
            dtpPublicationYear.Location = new Point(306, 229);
            dtpPublicationYear.Name = "dtpPublicationYear";
            dtpPublicationYear.RightToLeft = RightToLeft.No;
            dtpPublicationYear.Size = new Size(123, 27);
            dtpPublicationYear.TabIndex = 7;
            dtpPublicationYear.Value = new DateTime(2026, 8, 20, 0, 0, 0, 0);
            // 
            // lblTvRating
            // 
            lblTvRating.AutoSize = true;
            lblTvRating.BackColor = Color.Transparent;
            lblTvRating.Font = new Font("Verdana", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTvRating.ForeColor = SystemColors.HighlightText;
            lblTvRating.Location = new Point(30, 207);
            lblTvRating.Name = "lblTvRating";
            lblTvRating.Size = new Size(88, 18);
            lblTvRating.TabIndex = 8;
            lblTvRating.Text = "TV Rating";
            // 
            // lblEpisodes
            // 
            lblEpisodes.AutoSize = true;
            lblEpisodes.BackColor = Color.Transparent;
            lblEpisodes.Font = new Font("Verdana", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblEpisodes.ForeColor = SystemColors.HighlightText;
            lblEpisodes.Location = new Point(195, 207);
            lblEpisodes.Name = "lblEpisodes";
            lblEpisodes.Size = new Size(81, 18);
            lblEpisodes.TabIndex = 9;
            lblEpisodes.Text = "Episodes";
            // 
            // lblPublicationYear
            // 
            lblPublicationYear.AutoSize = true;
            lblPublicationYear.BackColor = Color.Transparent;
            lblPublicationYear.Font = new Font("Verdana", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblPublicationYear.ForeColor = SystemColors.HighlightText;
            lblPublicationYear.Location = new Point(301, 207);
            lblPublicationYear.Name = "lblPublicationYear";
            lblPublicationYear.Size = new Size(140, 18);
            lblPublicationYear.TabIndex = 10;
            lblPublicationYear.Text = "Publication Year";
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.BackColor = SystemColors.Highlight;
            btnSaveChanges.FlatStyle = FlatStyle.Popup;
            btnSaveChanges.Location = new Point(18, 270);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(423, 26);
            btnSaveChanges.TabIndex = 11;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = false;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnCancelChanges
            // 
            btnCancelChanges.BackColor = Color.Firebrick;
            btnCancelChanges.FlatStyle = FlatStyle.Popup;
            btnCancelChanges.Location = new Point(18, 302);
            btnCancelChanges.Name = "btnCancelChanges";
            btnCancelChanges.Size = new Size(423, 34);
            btnCancelChanges.TabIndex = 12;
            btnCancelChanges.Text = "Cancel ";
            btnCancelChanges.UseVisualStyleBackColor = false;
            // 
            // AnimeEditControl
            // 
            AutoScaleDimensions = new SizeF(10F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(btnCancelChanges);
            Controls.Add(btnSaveChanges);
            Controls.Add(lblPublicationYear);
            Controls.Add(lblEpisodes);
            Controls.Add(txtTitle);
            Controls.Add(dtpPublicationYear);
            Controls.Add(txtSynopsis);
            Controls.Add(lblTvRating);
            Controls.Add(numEpisodes);
            Controls.Add(lblComment);
            Controls.Add(cmbEditTvRating);
            Controls.Add(btnSearch);
            Controls.Add(txtEditSearch);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "AnimeEditControl";
            Size = new Size(455, 348);
            Load += AnimeEditControl_Load;
            ((System.ComponentModel.ISupportInitialize)numEpisodes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEditSearch;
        private Button btnSearch;
        private TextBox txtTitle;
        private Label lblComment;
        private TextBox txtSynopsis;
        private ComboBox cmbEditTvRating;
        private NumericUpDown numEpisodes;
        private DateTimePicker dtpPublicationYear;
        private Label lblTvRating;
        private Label lblEpisodes;
        private Label lblPublicationYear;
        private Button btnSaveChanges;
        private Button btnCancelChanges;
    }
}
