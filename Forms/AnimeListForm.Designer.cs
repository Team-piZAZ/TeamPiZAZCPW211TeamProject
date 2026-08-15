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
            flowLayoutPanel1 = new FlowLayoutPanel();
            txtAnimeName = new TextBox();
            btnAddToList = new Button();
            lblGenre = new Label();
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Location = new Point(12, 35);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.Size = new Size(972, 569);
            flowLayoutPanel1.TabIndex = 11;
            // 
            // txtAnimeName
            // 
            txtAnimeName.Location = new Point(452, 6);
            txtAnimeName.Name = "txtAnimeName";
            txtAnimeName.PlaceholderText = "Enter Anime Name";
            txtAnimeName.Size = new Size(279, 23);
            txtAnimeName.TabIndex = 12;
            // 
            // btnAddToList
            // 
            btnAddToList.BackColor = Color.BlueViolet;
            btnAddToList.FlatStyle = FlatStyle.Flat;
            btnAddToList.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddToList.Location = new Point(805, 5);
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
            lblGenre.Location = new Point(174, 9);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(39, 15);
            lblGenre.TabIndex = 14;
            lblGenre.Text = "Genre";
            // 
            // AnimeListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(996, 616);
            Controls.Add(lblGenre);
            Controls.Add(btnAddToList);
            Controls.Add(txtAnimeName);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(lblAnimeName);
            Controls.Add(lblStudio);
            Name = "AnimeListForm";
            Text = "Anime List";
            Load += AnimeListForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudio;
        private Label lblAnimeName;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox txtAnimeName;
        private Button btnAddToList;
        private Label lblGenre;
    }
}
