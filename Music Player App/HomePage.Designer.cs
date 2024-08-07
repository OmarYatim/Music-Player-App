namespace Music_Player_App
{
    partial class HomePage
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
            addAlbum_Button = new Button();
            searchBox = new TextBox();
            SuspendLayout();
            // 
            // addAlbum_Button
            // 
            addAlbum_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addAlbum_Button.Location = new Point(1189, 20);
            addAlbum_Button.Name = "addAlbum_Button";
            addAlbum_Button.Size = new Size(153, 38);
            addAlbum_Button.TabIndex = 0;
            addAlbum_Button.Text = "Add New Album";
            addAlbum_Button.UseVisualStyleBackColor = true;
            addAlbum_Button.Click += addAlbum_Button_Click;
            // 
            // searchBox
            // 
            searchBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchBox.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            searchBox.Location = new Point(12, 20);
            searchBox.MinimumSize = new Size(400, 36);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(750, 36);
            searchBox.TabIndex = 2;
            searchBox.TextChanged += searchBox_TextChanged;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1354, 718);
            Controls.Add(searchBox);
            Controls.Add(addAlbum_Button);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(750, 500);
            Name = "HomePage";
            Text = "Music Player";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addAlbum_Button;
        private TextBox searchBox;
    }
}