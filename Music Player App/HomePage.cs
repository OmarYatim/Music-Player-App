
namespace Music_Player_App
{
    public partial class HomePage : Form
    {
        int xPosition = 12;
        int yStartPosition = 100;
        int groupBoxHeight = 100;
        int groupBoxWidth = 1330;
        int verticalSpacing = 10;

        public HomePage()
        {
            InitializeComponent();

            AlbumsDAO albumsDAO = new AlbumsDAO();

            List<Album> albums = albumsDAO.getAllAlbums();

            for (int i = 0; i < albums.Count; i++)
                createAlbumGroupBox(albums[i], i);

            Panel panel = new Panel();
            panel.Dock = DockStyle.Bottom;
            panel.Size = new Size(this.ClientSize.Width, 49);
            this.Controls.Add(panel);
        }

        void createAlbumGroupBox(Album album, int index)
        {
            GroupBox albumGroupBox = new GroupBox();
            albumGroupBox.Location = new Point(xPosition, yStartPosition + index * (groupBoxHeight + verticalSpacing));
            albumGroupBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            albumGroupBox.Name = "groupBox" + index;
            albumGroupBox.Size = new Size(groupBoxWidth, groupBoxHeight);
            albumGroupBox.Tag = album;

            PictureBox albumpictureBox = new PictureBox();
            albumGroupBox.Controls.Add(albumpictureBox);
            albumpictureBox.Anchor = AnchorStyles.Left;
            albumpictureBox.Location = new Point(5, 15);
            albumpictureBox.Size = new Size(80, 80);
            albumpictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            using (MemoryStream memoryStream = new MemoryStream(album.ImageData))
            {
                if (album.ImageData.Length > 0)
                {
                    Image image = Image.FromStream(memoryStream);
                    albumpictureBox.Image = image;
                }
            }

            Label albumNameLabel = new Label();
            albumGroupBox.Controls.Add(albumNameLabel);
            albumNameLabel.Anchor = AnchorStyles.Left;
            albumNameLabel.AutoSize = true;
            albumNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            albumNameLabel.Location = new Point(160, 30);
            albumNameLabel.Text = album.AlbumName;

            Label artistNameLabel = new Label();
            albumGroupBox.Controls.Add(artistNameLabel);
            artistNameLabel.Anchor = AnchorStyles.Left;
            artistNameLabel.AutoSize = true;
            artistNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            artistNameLabel.Location = new Point(160, 65);
            artistNameLabel.Text = album.ArtistName;

            Button checkAlbumButton = new Button();
            albumGroupBox.Controls.Add(checkAlbumButton);
            checkAlbumButton.Anchor = AnchorStyles.Right;
            checkAlbumButton.Location = new Point(1100, 40);
            checkAlbumButton.Name = "checkAlbum_Button";
            checkAlbumButton.Size = new Size(185, 30);
            checkAlbumButton.Text = "Open Album";
            checkAlbumButton.Click += openAlbumButton_Click;

            this.Controls.Add(albumGroupBox);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            TextBox searchtextBox = (TextBox)sender;
            if (searchtextBox == null) return;

            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                Control childControl = this.Controls[i];

                // If the control is a GroupBox, remove it
                if (childControl is GroupBox)
                {
                    this.Controls.Remove(childControl);
                    childControl.Dispose();
                }
            }

            AlbumsDAO albumsDAO = new AlbumsDAO();
            List<Album> resultAlbums = albumsDAO.searchAlbums(searchtextBox.Text);
            for (int i = 0; i < resultAlbums.Count; i++)
                createAlbumGroupBox(resultAlbums[i], i);
        }

        private void addAlbum_Button_Click(object sender, EventArgs e) => FormSwitcher.OpenNewForm<AddAlbumForm>(this, false, null);

        private void openAlbumButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            FormSwitcher.OpenNewForm<AlbumForm>(this, (Album)button.Parent.Tag);
        }
    }
}