namespace Music_Player_App
{
    partial class TrackForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackForm));
            play_Button = new Button();
            trackName_Label = new Label();
            subTitle_Label = new Label();
            lyrics_Label = new Label();
            panel1 = new Panel();
            edit_Button = new Button();
            delete_Button = new Button();
            progressPanel = new Panel();
            toolTip1 = new ToolTip(components);
            progressBox = new GroupBox();
            home_Button = new Button();
            replay_Button = new Button();
            LoadingPicture = new PictureBox();
            LoadingLabel = new Label();
            panel1.SuspendLayout();
            progressBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LoadingPicture).BeginInit();
            SuspendLayout();
            // 
            // play_Button
            // 
            play_Button.Anchor = AnchorStyles.Top;
            play_Button.BackgroundImage = Properties.Resources.Play_Button;
            play_Button.BackgroundImageLayout = ImageLayout.Zoom;
            play_Button.Location = new Point(606, 65);
            play_Button.Name = "play_Button";
            play_Button.Size = new Size(74, 74);
            play_Button.TabIndex = 2;
            play_Button.UseVisualStyleBackColor = true;
            play_Button.Click += play_Button_Click;
            // 
            // trackName_Label
            // 
            trackName_Label.AutoSize = true;
            trackName_Label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            trackName_Label.Location = new Point(99, 231);
            trackName_Label.Name = "trackName_Label";
            trackName_Label.Size = new Size(124, 28);
            trackName_Label.TabIndex = 3;
            trackName_Label.Text = "Track Name";
            // 
            // subTitle_Label
            // 
            subTitle_Label.AutoSize = true;
            subTitle_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            subTitle_Label.Location = new Point(99, 316);
            subTitle_Label.Name = "subTitle_Label";
            subTitle_Label.Size = new Size(73, 28);
            subTitle_Label.TabIndex = 4;
            subTitle_Label.Text = "Lyrics : ";
            // 
            // lyrics_Label
            // 
            lyrics_Label.AutoSize = true;
            lyrics_Label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lyrics_Label.Location = new Point(99, 361);
            lyrics_Label.MaximumSize = new Size(1150, 0);
            lyrics_Label.Name = "lyrics_Label";
            lyrics_Label.Size = new Size(1145, 112);
            lyrics_Label.TabIndex = 5;
            lyrics_Label.Text = resources.GetString("lyrics_Label.Text");
            // 
            // panel1
            // 
            panel1.Controls.Add(edit_Button);
            panel1.Controls.Add(delete_Button);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 638);
            panel1.Name = "panel1";
            panel1.Size = new Size(1354, 80);
            panel1.TabIndex = 8;
            // 
            // edit_Button
            // 
            edit_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            edit_Button.Location = new Point(982, 23);
            edit_Button.Name = "edit_Button";
            edit_Button.Size = new Size(153, 36);
            edit_Button.TabIndex = 8;
            edit_Button.Text = "Edit Track";
            edit_Button.UseVisualStyleBackColor = true;
            edit_Button.Click += edit_Button_Click;
            // 
            // delete_Button
            // 
            delete_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            delete_Button.Location = new Point(1168, 23);
            delete_Button.Name = "delete_Button";
            delete_Button.Size = new Size(153, 36);
            delete_Button.TabIndex = 0;
            delete_Button.Text = "Delete Track";
            delete_Button.UseVisualStyleBackColor = true;
            delete_Button.Click += delete_Button_Click;
            // 
            // progressPanel
            // 
            progressPanel.BackColor = SystemColors.Highlight;
            progressPanel.Location = new Point(0, 12);
            progressPanel.Name = "progressPanel";
            progressPanel.Size = new Size(0, 8);
            progressPanel.TabIndex = 10;
            // 
            // progressBox
            // 
            progressBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBox.Controls.Add(progressPanel);
            progressBox.Location = new Point(99, 166);
            progressBox.Name = "progressBox";
            progressBox.Size = new Size(1173, 23);
            progressBox.TabIndex = 11;
            progressBox.TabStop = false;
            // 
            // home_Button
            // 
            home_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            home_Button.Location = new Point(1149, 12);
            home_Button.Name = "home_Button";
            home_Button.Size = new Size(153, 36);
            home_Button.TabIndex = 11;
            home_Button.Text = "Return";
            home_Button.UseVisualStyleBackColor = true;
            home_Button.Click += home_Button_Click;
            // 
            // replay_Button
            // 
            replay_Button.Anchor = AnchorStyles.Top;
            replay_Button.BackgroundImage = Properties.Resources.Replay_Button;
            replay_Button.BackgroundImageLayout = ImageLayout.Zoom;
            replay_Button.Location = new Point(716, 65);
            replay_Button.Name = "replay_Button";
            replay_Button.Size = new Size(74, 74);
            replay_Button.TabIndex = 12;
            replay_Button.UseVisualStyleBackColor = true;
            replay_Button.Click += replay_Button_Click;
            // 
            // LoadingPicture
            // 
            LoadingPicture.Anchor = AnchorStyles.None;
            LoadingPicture.Image = (Image)resources.GetObject("LoadingPicture.Image");
            LoadingPicture.Location = new Point(590, 175);
            LoadingPicture.Name = "LoadingPicture";
            LoadingPicture.Size = new Size(200, 200);
            LoadingPicture.SizeMode = PictureBoxSizeMode.Zoom;
            LoadingPicture.TabIndex = 13;
            LoadingPicture.TabStop = false;
            LoadingPicture.Visible = false;
            // 
            // LoadingLabel
            // 
            LoadingLabel.Anchor = AnchorStyles.None;
            LoadingLabel.AutoSize = true;
            LoadingLabel.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            LoadingLabel.Location = new Point(606, 387);
            LoadingLabel.Name = "LoadingLabel";
            LoadingLabel.Size = new Size(170, 46);
            LoadingLabel.TabIndex = 14;
            LoadingLabel.Text = "Loading ...";
            LoadingLabel.Visible = false;
            // 
            // TrackForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1354, 718);
            Controls.Add(LoadingLabel);
            Controls.Add(LoadingPicture);
            Controls.Add(replay_Button);
            Controls.Add(home_Button);
            Controls.Add(lyrics_Label);
            Controls.Add(progressBox);
            Controls.Add(panel1);
            Controls.Add(subTitle_Label);
            Controls.Add(trackName_Label);
            Controls.Add(play_Button);
            MinimumSize = new Size(750, 500);
            Name = "TrackForm";
            Text = "Music Player";
            Resize += TrackForm_Resize;
            panel1.ResumeLayout(false);
            progressBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LoadingPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button play_Button;
        private Label trackName_Label;
        private Label subTitle_Label;
        private Label lyrics_Label;
        private Panel panel1;
        private Button edit_Button;
        private Button delete_Button;
        private Panel progressPanel;
        private ToolTip toolTip1;
        private GroupBox progressBox;
        private Button home_Button;
        private Button replay_Button;
        private PictureBox LoadingPicture;
        private Label LoadingLabel;
    }
}