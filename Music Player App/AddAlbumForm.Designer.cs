namespace Music_Player_App
{
    partial class AddAlbumForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAlbumForm));
            home_Button = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            albumName_TextBox = new TextBox();
            artistName_TextBox = new TextBox();
            year_TextBox = new TextBox();
            description_TextBox = new TextBox();
            album_PictureBox = new PictureBox();
            addAlbum_Button = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)album_PictureBox).BeginInit();
            SuspendLayout();
            // 
            // home_Button
            // 
            home_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            home_Button.Location = new Point(1189, 12);
            home_Button.Name = "home_Button";
            home_Button.Size = new Size(153, 36);
            home_Button.TabIndex = 0;
            home_Button.Text = "Home";
            home_Button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(30, 51);
            label1.Name = "label1";
            label1.Size = new Size(210, 35);
            label1.TabIndex = 1;
            label1.Text = "Add New Album";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(105, 155);
            label2.Name = "label2";
            label2.Size = new Size(127, 28);
            label2.TabIndex = 2;
            label2.Text = "Album Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(105, 218);
            label3.Name = "label3";
            label3.Size = new Size(116, 28);
            label3.TabIndex = 3;
            label3.Text = "Artist Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(105, 281);
            label4.Name = "label4";
            label4.Size = new Size(48, 28);
            label4.TabIndex = 4;
            label4.Text = "Year";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(105, 375);
            label5.Name = "label5";
            label5.Size = new Size(112, 28);
            label5.TabIndex = 5;
            label5.Text = "Description";
            // 
            // albumName_TextBox
            // 
            albumName_TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            albumName_TextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            albumName_TextBox.Location = new Point(306, 151);
            albumName_TextBox.Name = "albumName_TextBox";
            albumName_TextBox.Size = new Size(671, 34);
            albumName_TextBox.TabIndex = 6;
            // 
            // artistName_TextBox
            // 
            artistName_TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            artistName_TextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            artistName_TextBox.Location = new Point(306, 215);
            artistName_TextBox.Name = "artistName_TextBox";
            artistName_TextBox.Size = new Size(671, 34);
            artistName_TextBox.TabIndex = 7;
            // 
            // year_TextBox
            // 
            year_TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            year_TextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            year_TextBox.Location = new Point(306, 278);
            year_TextBox.Name = "year_TextBox";
            year_TextBox.Size = new Size(671, 34);
            year_TextBox.TabIndex = 8;
            year_TextBox.KeyPress += year_TextBox_KeyPress;
            // 
            // description_TextBox
            // 
            description_TextBox.AcceptsReturn = true;
            description_TextBox.AcceptsTab = true;
            description_TextBox.AllowDrop = true;
            description_TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            description_TextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            description_TextBox.Location = new Point(304, 375);
            description_TextBox.Multiline = true;
            description_TextBox.Name = "description_TextBox";
            description_TextBox.ScrollBars = ScrollBars.Vertical;
            description_TextBox.Size = new Size(937, 317);
            description_TextBox.TabIndex = 9;
            // 
            // album_PictureBox
            // 
            album_PictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            album_PictureBox.Image = (Image)resources.GetObject("album_PictureBox.Image");
            album_PictureBox.Location = new Point(1041, 151);
            album_PictureBox.Name = "album_PictureBox";
            album_PictureBox.Size = new Size(200, 200);
            album_PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            album_PictureBox.TabIndex = 10;
            album_PictureBox.TabStop = false;
            album_PictureBox.Click += album_PictureBox_Click;
            // 
            // addAlbum_Button
            // 
            addAlbum_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addAlbum_Button.Location = new Point(1160, 738);
            addAlbum_Button.Name = "addAlbum_Button";
            addAlbum_Button.Size = new Size(144, 39);
            addAlbum_Button.TabIndex = 11;
            addAlbum_Button.Text = "Add Album";
            addAlbum_Button.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 777);
            panel1.Name = "panel1";
            panel1.Size = new Size(1354, 60);
            panel1.TabIndex = 12;
            // 
            // AddAlbumForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1354, 837);
            Controls.Add(panel1);
            Controls.Add(addAlbum_Button);
            Controls.Add(album_PictureBox);
            Controls.Add(description_TextBox);
            Controls.Add(year_TextBox);
            Controls.Add(artistName_TextBox);
            Controls.Add(albumName_TextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(home_Button);
            MinimumSize = new Size(750, 500);
            Name = "AddAlbumForm";
            Text = "Music Player";
            ((System.ComponentModel.ISupportInitialize)album_PictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button home_Button;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox albumName_TextBox;
        private TextBox artistName_TextBox;
        private TextBox year_TextBox;
        private TextBox description_TextBox;
        private PictureBox album_PictureBox;
        private Button addAlbum_Button;
        private Panel panel1;
    }
}