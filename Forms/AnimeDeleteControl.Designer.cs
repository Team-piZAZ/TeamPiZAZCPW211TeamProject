namespace TeamPiZAZCPW211TeamProject.Forms
{
    partial class AnimeDeleteControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimeDeleteControl));
            txtDeleteSearch = new TextBox();
            btnSearch = new Button();
            picPreview = new PictureBox();
            lblPreviewTitle = new Label();
            lblPreviewGenre = new Label();
            lblPreviewRating = new Label();
            btnDelete = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            SuspendLayout();
            // 
            // txtDeleteSearch
            // 
            txtDeleteSearch.AcceptsReturn = true;
            txtDeleteSearch.AllowDrop = true;
            txtDeleteSearch.BackColor = SystemColors.ButtonShadow;
            txtDeleteSearch.BorderStyle = BorderStyle.FixedSingle;
            txtDeleteSearch.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDeleteSearch.ForeColor = SystemColors.HighlightText;
            txtDeleteSearch.Location = new Point(22, 24);
            txtDeleteSearch.Margin = new Padding(4, 4, 4, 4);
            txtDeleteSearch.Name = "txtDeleteSearch";
            txtDeleteSearch.PlaceholderText = "Title";
            txtDeleteSearch.Size = new Size(360, 32);
            txtDeleteSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.MenuHighlight;
            btnSearch.FlatStyle = FlatStyle.Popup;
            btnSearch.Font = new Font("Verdana", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(22, 83);
            btnSearch.Margin = new Padding(4, 4, 4, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(361, 40);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // picPreview
            // 
            picPreview.BackColor = Color.Transparent;
            picPreview.Location = new Point(22, 146);
            picPreview.Margin = new Padding(4, 4, 4, 4);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(361, 269);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 2;
            picPreview.TabStop = false;
            // 
            // lblPreviewTitle
            // 
            lblPreviewTitle.AutoSize = true;
            lblPreviewTitle.BackColor = Color.Transparent;
            lblPreviewTitle.Font = new Font("Verdana", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblPreviewTitle.Location = new Point(26, 422);
            lblPreviewTitle.Margin = new Padding(4, 0, 4, 0);
            lblPreviewTitle.Name = "lblPreviewTitle";
            lblPreviewTitle.Size = new Size(62, 25);
            lblPreviewTitle.TabIndex = 3;
            lblPreviewTitle.Text = "Title";
            // 
            // lblPreviewGenre
            // 
            lblPreviewGenre.AutoSize = true;
            lblPreviewGenre.BackColor = Color.Transparent;
            lblPreviewGenre.Font = new Font("Verdana", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblPreviewGenre.Location = new Point(26, 481);
            lblPreviewGenre.Margin = new Padding(4, 0, 4, 0);
            lblPreviewGenre.Name = "lblPreviewGenre";
            lblPreviewGenre.Size = new Size(78, 25);
            lblPreviewGenre.TabIndex = 4;
            lblPreviewGenre.Text = "Genre";
            // 
            // lblPreviewRating
            // 
            lblPreviewRating.AutoSize = true;
            lblPreviewRating.BackColor = Color.Transparent;
            lblPreviewRating.Font = new Font("Verdana", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblPreviewRating.Location = new Point(26, 553);
            lblPreviewRating.Margin = new Padding(4, 0, 4, 0);
            lblPreviewRating.Name = "lblPreviewRating";
            lblPreviewRating.Size = new Size(121, 25);
            lblPreviewRating.TabIndex = 5;
            lblPreviewRating.Text = "TV Rating";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Crimson;
            btnDelete.Enabled = false;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Verdana", 13.8F, FontStyle.Bold | FontStyle.Strikeout, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(22, 636);
            btnDelete.Margin = new Padding(4, 4, 4, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(361, 44);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete Anime";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.MenuHighlight;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Verdana", 13.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(22, 711);
            btnCancel.Margin = new Padding(4, 4, 4, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(361, 44);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // AnimeDeleteControl
            // 
            AutoScaleDimensions = new SizeF(13F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(lblPreviewRating);
            Controls.Add(lblPreviewGenre);
            Controls.Add(lblPreviewTitle);
            Controls.Add(picPreview);
            Controls.Add(btnSearch);
            Controls.Add(txtDeleteSearch);
            DoubleBuffered = true;
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "AnimeDeleteControl";
            Padding = new Padding(4, 4, 4, 4);
            Size = new Size(407, 794);
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDeleteSearch;
        private Button btnSearch;
        private PictureBox picPreview;
        private Label lblPreviewTitle;
        private Label lblPreviewGenre;
        private Label lblPreviewRating;
        private Button btnDelete;
        private Button btnCancel;
    }
}
