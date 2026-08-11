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
            numRating = new NumericUpDown();
            dtpReleaseDate = new DateTimePicker();
            clbGenres = new CheckedListBox();
            btnSave = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            lblRating = new Label();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            lblReleaseDate = new Label();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.BackColor = SystemColors.ActiveBorder;
            txtTitle.BorderStyle = BorderStyle.None;
            txtTitle.Dock = DockStyle.Fill;
            txtTitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(3, 3);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(552, 32);
            txtTitle.TabIndex = 0;
            txtTitle.PlaceholderText = "Title goes here...";
            // 
            // txtSynopsis
            // 
            txtSynopsis.BackColor = SystemColors.ActiveBorder;
            txtSynopsis.BorderStyle = BorderStyle.None;
            txtSynopsis.Dock = DockStyle.Fill;
            txtSynopsis.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSynopsis.Location = new Point(3, 3);
            txtSynopsis.Multiline = true;
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.Size = new Size(555, 197);
            txtSynopsis.TabIndex = 1;
            txtSynopsis.PlaceholderText = "Short Description . . .";
            // 
            // numRating
            // 
            numRating.BackColor = SystemColors.ActiveBorder;
            numRating.DecimalPlaces = 1;
            numRating.Location = new Point(78, 3);
            numRating.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(82, 27);
            numRating.TabIndex = 2;
            numRating.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpReleaseDate
            // 
            dtpReleaseDate.CalendarMonthBackground = SystemColors.ActiveBorder;
            dtpReleaseDate.CalendarTitleBackColor = SystemColors.ActiveBorder;
            dtpReleaseDate.CustomFormat = "MM/yyyy";
            dtpReleaseDate.Dock = DockStyle.Right;
            dtpReleaseDate.DropDownAlign = LeftRightAlignment.Right;
            dtpReleaseDate.Format = DateTimePickerFormat.Custom;
            dtpReleaseDate.Location = new Point(152, 3);
            dtpReleaseDate.Name = "dtpReleaseDate";
            dtpReleaseDate.RightToLeft = RightToLeft.No;
            dtpReleaseDate.Size = new Size(138, 27);
            dtpReleaseDate.TabIndex = 3;
            // 
            // clbGenres
            // 
            clbGenres.BackColor = SystemColors.ActiveBorder;
            clbGenres.BorderStyle = BorderStyle.None;
            clbGenres.Dock = DockStyle.Fill;
            clbGenres.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clbGenres.FormattingEnabled = true;
            clbGenres.Location = new Point(3, 3);
            clbGenres.MultiColumn = true;
            clbGenres.Name = "clbGenres";
            clbGenres.ScrollAlwaysVisible = true;
            clbGenres.Size = new Size(555, 150);
            clbGenres.Sorted = true;
            clbGenres.TabIndex = 4;
            clbGenres.ThreeDCheckBoxes = true;
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
            btnSave.Size = new Size(555, 119);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Magenta;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(txtSynopsis);
            panel1.ForeColor = Color.Magenta;
            panel1.Location = new Point(71, 189);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3);
            panel1.Size = new Size(561, 203);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Magenta;
            panel2.Controls.Add(txtTitle);
            panel2.Location = new Point(74, 22);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(3);
            panel2.Size = new Size(558, 38);
            panel2.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Magenta;
            panel3.Controls.Add(lblRating);
            panel3.Controls.Add(numRating);
            panel3.Location = new Point(71, 95);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(3);
            panel3.Size = new Size(166, 33);
            panel3.TabIndex = 8;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRating.Location = new Point(9, 3);
            lblRating.Margin = new Padding(3);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(63, 25);
            lblRating.TabIndex = 3;
            lblRating.Text = "Rating";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Magenta;
            panel4.Controls.Add(clbGenres);
            panel4.Location = new Point(71, 429);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(3);
            panel4.Size = new Size(561, 156);
            panel4.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Magenta;
            panel5.Controls.Add(lblReleaseDate);
            panel5.Controls.Add(dtpReleaseDate);
            panel5.Location = new Point(339, 95);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(3);
            panel5.Size = new Size(293, 33);
            panel5.TabIndex = 10;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Lime;
            panel6.Controls.Add(btnSave);
            panel6.Location = new Point(71, 639);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(3);
            panel6.Size = new Size(561, 125);
            panel6.TabIndex = 11;
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.AutoSize = true;
            lblReleaseDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReleaseDate.Location = new Point(21, 3);
            lblReleaseDate.Margin = new Padding(3);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(112, 25);
            lblReleaseDate.TabIndex = 4;
            lblReleaseDate.Text = "Release Date";
            // 
            // AnimeDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(726, 824);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Sizable;
            Name = "AnimeDetailsForm";
            Text = "AnimeDetailsForm";
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
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
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtSynopsis;
        private NumericUpDown numRating;
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
    }
}