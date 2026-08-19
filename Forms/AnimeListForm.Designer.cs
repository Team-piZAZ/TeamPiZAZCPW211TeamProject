using TeamPiZAZCPW211TeamProject.Models;
using TeamPiZAZCPW211TeamProject.Services;
using TeamPiZAZCPW211TeamProject.Database;
using TeamPiZAZCPW211TeamProject.Forms;

namespace TeamPiZAZCPW211TeamProject
{
    partial class AnimeListForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimeListForm));
            lblStudio = new Label();
            lblAnimeName = new Label();
            txtAnimeName = new TextBox();
            btnAddToList = new Button();
            lblGenre = new Label();
            splitContainer1 = new SplitContainer();
            flpAnimeList = new FlowLayoutPanel();
            txtSearchTitle = new Button();
            cmbStudio = new ComboBox();
            cmbGenre = new ComboBox();
            mainLargeCard = new mainLargeCard();
            smallAnimeCard1 = new SmallAnimeCard();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flpAnimeList.SuspendLayout();
            SuspendLayout();
            // 
            // lblStudio
            // 
            lblStudio.AutoSize = true;
            lblStudio.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblStudio.ForeColor = SystemColors.Control;
            lblStudio.Location = new Point(12, 9);
            lblStudio.Name = "lblStudio";
            lblStudio.Size = new Size(41, 15);
            lblStudio.TabIndex = 0;
            lblStudio.Text = "Studio";
            // 
            // lblAnimeName
            // 
            lblAnimeName.AutoSize = true;
            lblAnimeName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAnimeName.ForeColor = SystemColors.Control;
            lblAnimeName.Location = new Point(369, 9);
            lblAnimeName.Name = "lblAnimeName";
            lblAnimeName.Size = new Size(78, 15);
            lblAnimeName.TabIndex = 9;
            lblAnimeName.Text = "Anime Name";
            // 
            // txtAnimeName
            // 
            txtAnimeName.BackColor = Color.FromArgb(30, 30, 30);
            txtAnimeName.Location = new Point(452, 6);
            txtAnimeName.Name = "txtAnimeName";
            txtAnimeName.PlaceholderText = "Enter Anime Name";
            txtAnimeName.Size = new Size(246, 23);
            txtAnimeName.TabIndex = 12;
            txtAnimeName.TextChanged += txtAnimeName_TextChanged;
            // 
            // btnAddToList
            // 
            btnAddToList.BackColor = Color.BlueViolet;
            btnAddToList.FlatStyle = FlatStyle.Flat;
            btnAddToList.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddToList.Location = new Point(854, 5);
            btnAddToList.Name = "btnAddToList";
            btnAddToList.Size = new Size(130, 23);
            btnAddToList.TabIndex = 13;
            btnAddToList.Text = "Add To List";
            btnAddToList.UseVisualStyleBackColor = false;
            btnAddToList.Click += btnAddToList_Click;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblGenre.ForeColor = SystemColors.Control;
            lblGenre.Location = new Point(184, 9);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(39, 15);
            lblGenre.TabIndex = 14;
            lblGenre.Text = "Genre";
            lblGenre.Click += lblGenre_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.Transparent;
            splitContainer1.Location = new Point(12, 35);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flpAnimeList);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(mainLargeCard);
            splitContainer1.Size = new Size(972, 569);
            splitContainer1.SplitterDistance = 324;
            splitContainer1.TabIndex = 15;
            // 
            // flpAnimeList
            // 
            flpAnimeList.AutoScroll = true;
            flpAnimeList.Controls.Add(smallAnimeCard1);
            flpAnimeList.Dock = DockStyle.Fill;
            flpAnimeList.Location = new Point(0, 0);
            flpAnimeList.Name = "flpAnimeList";
            flpAnimeList.Size = new Size(324, 569);
            flpAnimeList.TabIndex = 0;
            // 
            // txtSearchTitle
            // 
            txtSearchTitle.BackColor = Color.DarkCyan;
            txtSearchTitle.FlatStyle = FlatStyle.Popup;
            txtSearchTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearchTitle.Location = new Point(715, 5);
            txtSearchTitle.Name = "txtSearchTitle";
            txtSearchTitle.Size = new Size(122, 23);
            txtSearchTitle.TabIndex = 16;
            txtSearchTitle.Text = "Search Title";
            txtSearchTitle.UseVisualStyleBackColor = false;
            // 
            // cmbStudio
            // 
            cmbStudio.BackColor = Color.FromArgb(30, 30, 30);
            cmbStudio.FlatStyle = FlatStyle.Popup;
            cmbStudio.ForeColor = SystemColors.Window;
            cmbStudio.FormattingEnabled = true;
            cmbStudio.Location = new Point(59, 5);
            cmbStudio.Name = "cmbStudio";
            cmbStudio.Size = new Size(109, 23);
            cmbStudio.TabIndex = 17;
            // 
            // cmbGenre
            // 
            cmbGenre.BackColor = Color.FromArgb(30, 30, 30);
            cmbGenre.FlatStyle = FlatStyle.Popup;
            cmbGenre.ForeColor = SystemColors.Window;
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(229, 5);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(121, 23);
            cmbGenre.TabIndex = 18;
            // 
            // mainLargeCard
            // 
            this.mainLargeCard.BackColor = Color.FromArgb(30, 30, 30);
            this.mainLargeCard.BorderStyle = BorderStyle.Fixed3D;
            this.mainLargeCard.Dock = DockStyle.Fill;
            this.mainLargeCard.ForeColor = SystemColors.Menu;
            this.mainLargeCard.Location = new Point(0, 0);
            this.mainLargeCard.Name = "mainLargeCard";
            this.mainLargeCard.Size = new Size(644, 569);
            this.mainLargeCard.TabIndex = 0;
            // 
            // smallAnimeCard1
            // 
            smallAnimeCard1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            smallAnimeCard1.BackColor = Color.DeepSkyBlue;
            smallAnimeCard1.BackgroundImageLayout = ImageLayout.Stretch;
            smallAnimeCard1.Location = new Point(3, 3);
            smallAnimeCard1.Name = "smallAnimeCard1";
            smallAnimeCard1.Padding = new Padding(3);
            smallAnimeCard1.Size = new Size(275, 140);
            smallAnimeCard1.TabIndex = 0;
            // 
            // AnimeListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(996, 616);
            Controls.Add(cmbGenre);
            Controls.Add(cmbStudio);
            Controls.Add(txtSearchTitle);
            Controls.Add(splitContainer1);
            Controls.Add(lblGenre);
            Controls.Add(btnAddToList);
            Controls.Add(txtAnimeName);
            Controls.Add(lblAnimeName);
            Controls.Add(lblStudio);
            Name = "AnimeListForm";
            Text = "Anime List";
            Load += AnimeListForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flpAnimeList.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudio;
        private Label lblAnimeName;
        private TextBox txtAnimeName;
        private Button btnAddToList;
        private Label lblGenre;
        private SplitContainer splitContainer1;
        private FlowLayoutPanel flpAnimeList;
        private Button txtSearchTitle;
        private ComboBox cmbStudio;
        private ComboBox cmbGenre;
        private SmallAnimeCard smallAnimeCard1;
        private mainLargeCard mainLargeCard;
    }
}
