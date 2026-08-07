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
            txtTitle.Location = new Point(94, 92);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(538, 27);
            txtTitle.TabIndex = 0;
            // 
            // txtSynopsis
            // 
            txtSynopsis.Location = new Point(94, 182);
            txtSynopsis.Multiline = true;
            txtSynopsis.Name = "txtSynopsis";
            txtSynopsis.Size = new Size(538, 178);
            txtSynopsis.TabIndex = 1;
            // 
            // numRating
            // 
            numRating.DecimalPlaces = 1;
            numRating.Location = new Point(699, 92);
            numRating.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numRating.Name = "numRating";
            numRating.Size = new Size(150, 27);
            numRating.TabIndex = 2;
            // 
            // dtpReleaseDate
            // 
            dtpReleaseDate.Format = DateTimePickerFormat.Short;
            dtpReleaseDate.Location = new Point(947, 92);
            dtpReleaseDate.Name = "dtpReleaseDate";
            dtpReleaseDate.Size = new Size(250, 27);
            dtpReleaseDate.TabIndex = 3;
            // 
            // clbGenres
            // 
            clbGenres.FormattingEnabled = true;
            clbGenres.Location = new Point(699, 180);
            clbGenres.Name = "clbGenres";
            clbGenres.Size = new Size(498, 180);
            clbGenres.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 192, 0);
            btnSave.Location = new Point(1274, 92);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(126, 268);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // AnimeDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1487, 425);
            Controls.Add(btnSave);
            Controls.Add(clbGenres);
            Controls.Add(dtpReleaseDate);
            Controls.Add(numRating);
            Controls.Add(txtSynopsis);
            Controls.Add(txtTitle);
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