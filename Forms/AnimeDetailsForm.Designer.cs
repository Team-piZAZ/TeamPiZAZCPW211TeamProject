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
            txtTitle = new TextBox();
            txtSynopsis = new TextBox();
            numRating = new NumericUpDown();
            dtpReleaseDate = new DateTimePicker();
            clbGenres = new CheckedListBox();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)numRating).BeginInit();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(82, 69);
            txtTitle.Margin = new Padding(3, 2, 3, 2);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(471, 23);
            txtTitle.TabIndex = 0;
            // 
            // txtSynopsis
            // 
            txtSynopsis.Location = new Point(82, 136);
            txtSynopsis.Margin = new Padding(3, 2, 3, 2);
            txtSynopsis.Multiline = true;
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.Size = new Size(471, 134);
            txtSynopsis.TabIndex = 1;
            // 
            // numRating
            // 
            numRating.DecimalPlaces = 1;
            numRating.Location = new Point(612, 69);
            numRating.Margin = new Padding(3, 2, 3, 2);
            numRating.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(131, 23);
            numRating.TabIndex = 2;
            // 
            // dtpReleaseDate
            // 
            dtpReleaseDate.Format = DateTimePickerFormat.Short;
            dtpReleaseDate.Location = new Point(829, 69);
            dtpReleaseDate.Margin = new Padding(3, 2, 3, 2);
            dtpReleaseDate.Name = "dtpReleaseDate";
            dtpReleaseDate.Size = new Size(219, 23);
            dtpReleaseDate.TabIndex = 3;
            // 
            // clbGenres
            // 
            clbGenres.FormattingEnabled = true;
            clbGenres.Location = new Point(612, 135);
            clbGenres.Margin = new Padding(3, 2, 3, 2);
            clbGenres.Name = "clbGenres";
            clbGenres.Size = new Size(436, 130);
            clbGenres.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 192, 0);
            btnSave.Location = new Point(1115, 69);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 201);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // AnimeDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1301, 319);
            Controls.Add(btnSave);
            Controls.Add(clbGenres);
            Controls.Add(dtpReleaseDate);
            Controls.Add(numRating);
            Controls.Add(txtSynopsis);
            Controls.Add(txtTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AnimeDetailsForm";
            Text = "AnimeDetailsForm";
            ((System.ComponentModel.ISupportInitialize)numRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtSynopsis;
        private NumericUpDown numRating;
        private DateTimePicker dtpReleaseDate;
        private CheckedListBox clbGenres;
        private Button btnSave;
    }
}