namespace TeamPiZAZCPW211TeamProject
{
    partial class SmallAnimeCard
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
            lblRating = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.FlatStyle = FlatStyle.Popup;
            lblTitle.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.Window;
            lblTitle.Location = new Point(14, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(44, 22);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title:";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.BackColor = Color.Transparent;
            lblRating.BorderStyle = BorderStyle.Fixed3D;
            lblRating.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblRating.ForeColor = SystemColors.Window;
            lblRating.Location = new Point(14, 85);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(82, 22);
            lblRating.TabIndex = 1;
            lblRating.Text = "TV Rating:";
            lblRating.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(144, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 134);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // SmallAnimeCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DeepSkyBlue;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(pictureBox1);
            Controls.Add(lblRating);
            Controls.Add(lblTitle);
            Name = "SmallAnimeCard";
            Size = new Size(275, 140);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblRating;
        private PictureBox pictureBox1;
    }
}
