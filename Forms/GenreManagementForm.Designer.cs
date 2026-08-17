namespace TeamPiZAZCPW211TeamProject.Forms
{
    partial class GenreManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenreManagementForm));
            lstGenres = new ListBox();
            txtGenreName = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            btnAddGenre = new Button();
            panel4 = new Panel();
            btnUpdate = new Button();
            panel5 = new Panel();
            btnDelete = new Button();
            lblEditGenre = new Label();
            Load += GenreManagementForm_Load;
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // lstGenres
            // 
            lstGenres.BackColor = SystemColors.GradientActiveCaption;
            lstGenres.BorderStyle = BorderStyle.None;
            lstGenres.Dock = DockStyle.Fill;
            lstGenres.FormattingEnabled = true;
            lstGenres.Location = new Point(3, 3);
            lstGenres.Name = "lstGenres";
            lstGenres.Size = new Size(237, 148);
            lstGenres.TabIndex = 0;
            // 
            // txtGenreName
            // 
            txtGenreName.BackColor = SystemColors.GradientActiveCaption;
            txtGenreName.BorderStyle = BorderStyle.FixedSingle;
            txtGenreName.Dock = DockStyle.Fill;
            txtGenreName.Location = new Point(3, 3);
            txtGenreName.Name = "txtGenreName";
            txtGenreName.PlaceholderText = "Genre name";
            txtGenreName.Size = new Size(237, 23);
            txtGenreName.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Magenta;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lstGenres);
            panel1.Location = new Point(12, 51);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3);
            panel1.Size = new Size(245, 156);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Magenta;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtGenreName);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(3);
            panel2.Size = new Size(245, 33);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Magenta;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(btnAddGenre);
            panel3.Location = new Point(281, 55);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(3);
            panel3.Size = new Size(109, 33);
            panel3.TabIndex = 4;
            // 
            // btnAddGenre
            // 
            btnAddGenre.BackColor = Color.Lime;
            btnAddGenre.Dock = DockStyle.Fill;
            btnAddGenre.FlatStyle = FlatStyle.Popup;
            btnAddGenre.Location = new Point(3, 3);
            btnAddGenre.Name = "btnAddGenre";
            btnAddGenre.Size = new Size(101, 25);
            btnAddGenre.TabIndex = 0;
            btnAddGenre.Text = "Add";
            btnAddGenre.UseVisualStyleBackColor = false;
            btnAddGenre.Click += btnAdd_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Magenta;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(btnUpdate);
            panel4.Location = new Point(281, 109);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(3);
            panel4.Size = new Size(109, 33);
            panel4.TabIndex = 5;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Yellow;
            btnUpdate.Dock = DockStyle.Fill;
            btnUpdate.FlatStyle = FlatStyle.Popup;
            btnUpdate.Location = new Point(3, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(101, 25);
            btnUpdate.TabIndex = 0;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Magenta;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(btnDelete);
            panel5.Location = new Point(281, 167);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(3);
            panel5.Size = new Size(109, 36);
            panel5.TabIndex = 6;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Crimson;
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Location = new Point(3, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(101, 28);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblEditGenre
            // 
            lblEditGenre.BackColor = Color.Transparent;
            lblEditGenre.Font = new Font("Verdana", 12F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblEditGenre.ForeColor = Color.Magenta;
            lblEditGenre.Location = new Point(281, 16);
            lblEditGenre.Name = "lblEditGenre";
            lblEditGenre.Size = new Size(109, 23);
            lblEditGenre.TabIndex = 7;
            lblEditGenre.Text = "Edit Genre";
            lblEditGenre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GenreManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(402, 228);
            Controls.Add(lblEditGenre);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "GenreManagementForm";
            Text = "GenreManagementForm";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstGenres;
        private TextBox txtGenreName;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Label lblEditGenre;
        private Button btnAddGenre;
        private Button btnUpdate;
        private Button btnDelete;
    }
}