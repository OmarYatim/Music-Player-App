
namespace Music_Player_App
{
    public partial class AlbumForm : Form
    {
        private Album album;
        int xPosition = 78;
        int groupBoxHeight = 75;
        int groupBoxWidth = 1200;
        int verticalSpacing = 10;

        public AlbumForm(Album album)
        {
            InitializeComponent();
            albumName_Label.Text = album.AlbumName;
            artistName_Label.Text = album.ArtistName;
            year_Label.Text = album.Year.ToString();
            description_Label.Text = album.AlbumDescription;
            description_Label.MaximumSize = new Size(ClientSize.Width - description_Label.Left * 2, 0);
            int yPosition = description_Label.Location.Y + description_Label.Size.Height + 50;
            label2.Location = new Point(label2.Location.X, yPosition);
            addTrack_Button.Location = new Point(addTrack_Button.Location.X, yPosition);

            using (MemoryStream memoryStream = new MemoryStream(album.ImageData))
            {
                if (album.ImageData.Length > 0)
                {
                    Image image = Image.FromStream(memoryStream);
                    album_PictureBox.Image = image;
                }
            }

            for (int i = 0; i < album.Tracks.Count; i++)
                createTrackBox(album.Tracks[i], i);

            this.album = album;
        }

        private void createTrackBox(Track track, int index)
        {
            int yStartPosition = label2.Location.Y + label2.Size.Height + 20;

            GroupBox trackGroupBox = new GroupBox();
            trackGroupBox.Location = new Point(xPosition, yStartPosition + index * (groupBoxHeight + verticalSpacing));
            trackGroupBox.Size = new Size(groupBoxWidth, groupBoxHeight);
            trackGroupBox.Tag = track;
            trackGroupBox.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            Label trackLabel = new Label();
            trackLabel.Anchor = AnchorStyles.Left;
            trackLabel.AutoSize = true;
            trackLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            trackLabel.Location = new Point(15, 26);
            trackLabel.Text = track.Name;

            Button trackButton = new Button();
            trackButton.Anchor = AnchorStyles.Right;
            trackButton.Location = new Point(1003, 25);
            trackButton.Size = new Size(185, 30);
            trackButton.Text = "Play Track";
            trackButton.Click += OpenTrackPage;

            trackGroupBox.Controls.Add(trackButton);
            trackGroupBox.Controls.Add(trackLabel);

            this.Controls.Add(trackGroupBox);
        }

        private void home_Button_Click(object sender, EventArgs e) => FormSwitcher.OpenNewForm<HomePage>(this);

        private void edit_Button_Click(object sender, EventArgs e) => FormSwitcher.OpenNewForm<AddAlbumForm>(this, true, album);

        private void OpenTrackPage(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            FormSwitcher.OpenNewForm<TrackForm>(this, (Track)button.Parent.Tag);
        }

        private void delete_Button_Click(object sender, EventArgs e)
        {
            int albumID = album.ID;
            AlbumsDAO albumsDAO = new AlbumsDAO();
            int result = albumsDAO.deleteAlbum(albumID);
            if (result == 0)
            {
                MessageBoxHelper.ShowErrorBox("An Error occured while deleting the Album, Please Try again at a later time", "Network Error");
                return;
            }
            FormSwitcher.OpenNewForm<HomePage>(this);
        }

        private void addTrack_Button_Click(object sender, EventArgs e) => FormSwitcher.OpenNewForm<AddTrack>(this, album.ID, null);

        private void AlbumForm_Resize(object sender, EventArgs e)
        {
            description_Label.MaximumSize = new Size(ClientSize.Width - description_Label.Left * 2, 0);
            int oldYpos = label2.Location.Y;
            int newYpos = description_Label.Location.Y + description_Label.Size.Height + 50;
            int yDiff = newYpos - oldYpos;
            label2.Location = new Point(label2.Location.X, label2.Location.Y + yDiff);
            addTrack_Button.Location = new Point(addTrack_Button.Location.X, addTrack_Button.Location.Y + yDiff);
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox)
                    control.Location = new Point(control.Location.X, control.Location.Y + yDiff);
            }
        }
    }
}
