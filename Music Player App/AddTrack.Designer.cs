namespace Music_Player_App
{
    partial class AddTrack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTrack));
            addTrack_Button = new Button();
            lyrics_TextBox = new TextBox();
            number_TextBox = new TextBox();
            trackTitle_TextBox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            fileButton = new Button();
            fileLabel = new Label();
            uploadProgressBar = new ProgressBar();
            home_Button = new Button();
            pictureBox1 = new PictureBox();
            UploadLabel = new Label();
            fileNameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // addTrack_Button
            // 
            addTrack_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addTrack_Button.Location = new Point(1129, 717);
            addTrack_Button.Name = "addTrack_Button";
            addTrack_Button.Size = new Size(144, 39);
            addTrack_Button.TabIndex = 21;
            addTrack_Button.Text = "Add Track";
            addTrack_Button.UseVisualStyleBackColor = true;
            // 
            // lyrics_TextBox
            // 
            lyrics_TextBox.AcceptsReturn = true;
            lyrics_TextBox.AcceptsTab = true;
            lyrics_TextBox.AllowDrop = true;
            lyrics_TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lyrics_TextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lyrics_TextBox.Location = new Point(304, 253);
            lyrics_TextBox.Multiline = true;
            lyrics_TextBox.Name = "lyrics_TextBox";
            lyrics_TextBox.ScrollBars = ScrollBars.Vertical;
            lyrics_TextBox.Size = new Size(895, 317);
            lyrics_TextBox.TabIndex = 20;
            // 
            // number_TextBox
            // 
            number_TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            number_TextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            number_TextBox.Location = new Point(304, 175);
            number_TextBox.Name = "number_TextBox";
            number_TextBox.Size = new Size(629, 34);
            number_TextBox.TabIndex = 19;
            // 
            // trackTitle_TextBox
            // 
            trackTitle_TextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackTitle_TextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            trackTitle_TextBox.Location = new Point(306, 93);
            trackTitle_TextBox.Name = "trackTitle_TextBox";
            trackTitle_TextBox.Size = new Size(629, 34);
            trackTitle_TextBox.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(105, 253);
            label5.Name = "label5";
            label5.Size = new Size(59, 28);
            label5.TabIndex = 16;
            label5.Text = "Lyrics";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(105, 175);
            label4.Name = "label4";
            label4.Size = new Size(84, 28);
            label4.TabIndex = 15;
            label4.Text = "Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(105, 97);
            label2.Name = "label2";
            label2.Size = new Size(98, 28);
            label2.TabIndex = 13;
            label2.Text = "Track Title";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 756);
            panel1.Name = "panel1";
            panel1.Size = new Size(1333, 60);
            panel1.TabIndex = 24;
            // 
            // fileButton
            // 
            fileButton.Location = new Point(105, 607);
            fileButton.Name = "fileButton";
            fileButton.Size = new Size(210, 39);
            fileButton.TabIndex = 25;
            fileButton.Text = "Choose Audio File";
            fileButton.UseVisualStyleBackColor = true;
            fileButton.Click += fileButton_Click;
            // 
            // fileLabel
            // 
            fileLabel.AutoSize = true;
            fileLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fileLabel.Location = new Point(350, 652);
            fileLabel.Name = "fileLabel";
            fileLabel.Size = new Size(0, 28);
            fileLabel.TabIndex = 26;
            // 
            // uploadProgressBar
            // 
            uploadProgressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            uploadProgressBar.Location = new Point(53, 438);
            uploadProgressBar.Name = "uploadProgressBar";
            uploadProgressBar.Size = new Size(1228, 37);
            uploadProgressBar.Step = 1;
            uploadProgressBar.TabIndex = 27;
            uploadProgressBar.Visible = false;
            // 
            // home_Button
            // 
            home_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            home_Button.Location = new Point(1137, 12);
            home_Button.Name = "home_Button";
            home_Button.Size = new Size(153, 36);
            home_Button.TabIndex = 28;
            home_Button.Text = "Return";
            home_Button.UseVisualStyleBackColor = true;
            home_Button.Click += home_Button_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(235, 382);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // UploadLabel
            // 
            UploadLabel.AutoSize = true;
            UploadLabel.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            UploadLabel.Location = new Point(304, 390);
            UploadLabel.Name = "UploadLabel";
            UploadLabel.Size = new Size(167, 35);
            UploadLabel.TabIndex = 30;
            UploadLabel.Text = "Uploading . . .";
            UploadLabel.Visible = false;
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            fileNameLabel.Location = new Point(361, 612);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new Size(0, 28);
            fileNameLabel.TabIndex = 31;
            // 
            // AddTrack
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1354, 718);
            Controls.Add(fileNameLabel);
            Controls.Add(UploadLabel);
            Controls.Add(pictureBox1);
            Controls.Add(home_Button);
            Controls.Add(addTrack_Button);
            Controls.Add(uploadProgressBar);
            Controls.Add(fileLabel);
            Controls.Add(fileButton);
            Controls.Add(panel1);
            Controls.Add(lyrics_TextBox);
            Controls.Add(number_TextBox);
            Controls.Add(trackTitle_TextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Name = "AddTrack";
            Text = "AddTrack";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button addTrack_Button;
        private TextBox lyrics_TextBox;
        private TextBox number_TextBox;
        private TextBox trackTitle_TextBox;
        private Label label5;
        private Label label4;
        private Label label2;
        private Panel panel1;
        private Button fileButton;
        private Label fileLabel;
        private ProgressBar uploadProgressBar;
        private Button home_Button;
        private PictureBox pictureBox1;
        private Label UploadLabel;
        private Label fileNameLabel;
    }
}