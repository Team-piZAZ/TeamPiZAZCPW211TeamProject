namespace TeamPiZAZCPW211TeamProject.Forms
{
    partial class mainLargeCard
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
            lblTitle = new Label();
            lblGenre = new Label();
            lblTvRating = new Label();
            lblEpisodes = new Label();
            lblPublicationYear = new Label();
            lblReleaseYear = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkTurquoise;
            lblTitle.Location = new Point(35, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(86, 42);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title";
            // 
            // lblGenre
            // 
            lblGenre.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblGenre.ForeColor = Color.DarkTurquoise;
            lblGenre.Location = new Point(35, 89);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(157, 53);
            lblGenre.TabIndex = 1;
            lblGenre.Text = "Genre";
            lblGenre.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTvRating
            // 
            lblTvRating.AutoSize = true;
            lblTvRating.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTvRating.ForeColor = Color.DarkTurquoise;
            lblTvRating.Location = new Point(35, 175);
            lblTvRating.Name = "lblTvRating";
            lblTvRating.Size = new Size(157, 42);
            lblTvRating.TabIndex = 2;
            lblTvRating.Text = "Tv Rating";
            // 
            // lblEpisodes
            // 
            lblEpisodes.AutoSize = true;
            lblEpisodes.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblEpisodes.ForeColor = Color.DarkTurquoise;
            lblEpisodes.Location = new Point(35, 260);
            lblEpisodes.Name = "lblEpisodes";
            lblEpisodes.Size = new Size(142, 42);
            lblEpisodes.TabIndex = 3;
            lblEpisodes.Text = "Episodes";
            // 
            // lblPublicationYear
            // 
            lblPublicationYear.AutoSize = true;
            lblPublicationYear.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblPublicationYear.ForeColor = Color.DarkTurquoise;
            lblPublicationYear.Location = new Point(35, 348);
            lblPublicationYear.Name = "lblPublicationYear";
            lblPublicationYear.Size = new Size(250, 42);
            lblPublicationYear.TabIndex = 4;
            lblPublicationYear.Text = "Publication Year";
            // 
            // lblReleaseYear
            // 
            lblReleaseYear.AutoSize = true;
            lblReleaseYear.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblReleaseYear.ForeColor = Color.DarkTurquoise;
            lblReleaseYear.Location = new Point(35, 431);
            lblReleaseYear.Name = "lblReleaseYear";
            lblReleaseYear.Size = new Size(208, 42);
            lblReleaseYear.TabIndex = 5;
            lblReleaseYear.Text = "Release Year";
            lblReleaseYear.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(397, 20);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(307, 468);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // mainLargeCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(pictureBox1);
            Controls.Add(lblReleaseYear);
            Controls.Add(lblPublicationYear);
            Controls.Add(lblEpisodes);
            Controls.Add(lblTvRating);
            Controls.Add(lblGenre);
            Controls.Add(lblTitle);
            ForeColor = SystemColors.Menu;
            Margin = new Padding(3, 4, 3, 4);
            Name = "mainLargeCard";
            Size = new Size(727, 509);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblGenre;
        private Label lblTvRating;
        private Label lblEpisodes;
        private Label lblPublicationYear;
        private Label lblReleaseYear;
        private PictureBox pictureBox1;
    }
}
