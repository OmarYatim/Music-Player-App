namespace Music_Player_App
{
    partial class AlbumForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlbumForm));
            albumName_Label = new Label();
            home_Button = new Button();
            artistName_Label = new Label();
            year_Label = new Label();
            description_Label = new Label();
            album_PictureBox = new PictureBox();
            panel1 = new Panel();
            edit_Button = new Button();
            delete_Button = new Button();
            label2 = new Label();
            addTrack_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)album_PictureBox).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // albumName_Label
            // 
            albumName_Label.AutoSize = true;
            albumName_Label.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            albumName_Label.Location = new Point(30, 51);
            albumName_Label.Name = "albumName_Label";
            albumName_Label.Size = new Size(171, 35);
            albumName_Label.TabIndex = 0;
            albumName_Label.Text = "Album Name";
            // 
            // home_Button
            // 
            home_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            home_Button.Location = new Point(1168, 12);
            home_Button.Name = "home_Button";
            home_Button.Size = new Size(153, 36);
            home_Button.TabIndex = 1;
            home_Button.Text = "Home";
            home_Button.UseVisualStyleBackColor = true;
            home_Button.Click += home_Button_Click;
            // 
            // artistName_Label
            // 
            artistName_Label.AutoSize = true;
            artistName_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            artistName_Label.Location = new Point(78, 149);
            artistName_Label.Name = "artistName_Label";
            artistName_Label.Size = new Size(116, 28);
            artistName_Label.TabIndex = 3;
            artistName_Label.Text = "Artist Name";
            // 
            // year_Label
            // 
            year_Label.AutoSize = true;
            year_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            year_Label.Location = new Point(78, 203);
            year_Label.Name = "year_Label";
            year_Label.Size = new Size(48, 28);
            year_Label.TabIndex = 4;
            year_Label.Text = "Year";
            // 
            // description_Label
            // 
            description_Label.AllowDrop = true;
            description_Label.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            description_Label.AutoEllipsis = true;
            description_Label.AutoSize = true;
            description_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            description_Label.Location = new Point(78, 343);
            description_Label.Margin = new Padding(3, 0, 0, 0);
            description_Label.MaximumSize = new Size(1200, 0);
            description_Label.MinimumSize = new Size(500, 0);
            description_Label.Name = "description_Label";
            description_Label.Size = new Size(1200, 112);
            description_Label.TabIndex = 5;
            description_Label.Text = resources.GetString("description_Label.Text");
            // 
            // album_PictureBox
            // 
            album_PictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            album_PictureBox.Location = new Point(1117, 149);
            album_PictureBox.Name = "album_PictureBox";
            album_PictureBox.Size = new Size(160, 160);
            album_PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            album_PictureBox.TabIndex = 6;
            album_PictureBox.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(edit_Button);
            panel1.Controls.Add(delete_Button);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 617);
            panel1.Name = "panel1";
            panel1.Size = new Size(1354, 101);
            panel1.TabIndex = 7;
            // 
            // edit_Button
            // 
            edit_Button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            edit_Button.Location = new Point(982, 45);
            edit_Button.Name = "edit_Button";
            edit_Button.Size = new Size(153, 36);
            edit_Button.TabIndex = 8;
            edit_Button.Text = "Edit Album";
            edit_Button.UseVisualStyleBackColor = true;
            edit_Button.Click += edit_Button_Click;
            // 
            // delete_Button
            // 
            delete_Button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            delete_Button.Location = new Point(1168, 45);
            delete_Button.Name = "delete_Button";
            delete_Button.Size = new Size(153, 36);
            delete_Button.TabIndex = 0;
            delete_Button.Text = "Delete Album";
            delete_Button.UseVisualStyleBackColor = true;
            delete_Button.Click += delete_Button_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(78, 501);
            label2.Name = "label2";
            label2.Size = new Size(78, 30);
            label2.TabIndex = 9;
            label2.Text = "Tracks";
            // 
            // addTrack_Button
            // 
            addTrack_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addTrack_Button.Location = new Point(1147, 495);
            addTrack_Button.Name = "addTrack_Button";
            addTrack_Button.Size = new Size(153, 36);
            addTrack_Button.TabIndex = 10;
            addTrack_Button.Text = "Add Track";
            addTrack_Button.UseVisualStyleBackColor = true;
            addTrack_Button.Click += addTrack_Button_Click;
            // 
            // AlbumForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1354, 718);
            Controls.Add(addTrack_Button);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(album_PictureBox);
            Controls.Add(description_Label);
            Controls.Add(year_Label);
            Controls.Add(artistName_Label);
            Controls.Add(home_Button);
            Controls.Add(albumName_Label);
            MinimumSize = new Size(750, 500);
            Name = "AlbumForm";
            Text = "Music Player";
            Resize += AlbumForm_Resize;
            ((System.ComponentModel.ISupportInitialize)album_PictureBox).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label albumName_Label;
        private Button home_Button;
        private Label artistName_Label;
        private Label year_Label;
        private Label description_Label;
        private PictureBox album_PictureBox;
        private Panel panel1;
        private Button edit_Button;
        private Button delete_Button;
        private Label label2;
        private Button addTrack_Button;
    }
}