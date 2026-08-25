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
            picAnimeCover = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picAnimeCover).BeginInit();
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
            lblTitle.Location = new Point(16, 28);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(57, 27);
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
            lblRating.Location = new Point(16, 113);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(104, 27);
            lblRating.TabIndex = 1;
            lblRating.Text = "TV Rating:";
            lblRating.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picAnimeCover
            // 
            picAnimeCover.Location = new Point(165, 4);
            picAnimeCover.Margin = new Padding(3, 4, 3, 4);
            picAnimeCover.Name = "picAnimeCover";
            picAnimeCover.Size = new Size(146, 179);
            picAnimeCover.SizeMode = PictureBoxSizeMode.Zoom;
            picAnimeCover.TabIndex = 2;
            picAnimeCover.TabStop = false;
            // 
            // SmallAnimeCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(95, 0, 160);
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(picAnimeCover);
            Controls.Add(lblRating);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SmallAnimeCard";
            Size = new Size(314, 187);
            Load += SmallAnimeCard_Load;
            ((System.ComponentModel.ISupportInitialize)picAnimeCover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblRating;
        private PictureBox picAnimeCover;
    }
}
