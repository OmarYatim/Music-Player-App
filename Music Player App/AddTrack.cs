
namespace Music_Player_App
{
    public partial class AddTrack : Form
    {
        Track trackToEdit;
        string selectedAudio = "";
        int albumID = -1;
        public AddTrack(int albumID, Track? trackToEdit = null)
        {
            InitializeComponent();
            this.albumID = albumID;
            if (trackToEdit != null)
            {
                this.trackToEdit = trackToEdit;
                trackTitle_TextBox.Text = trackToEdit.Name;
                number_TextBox.Text = trackToEdit.Number.ToString();
                lyrics_TextBox.Text = trackToEdit.Lyrics;
                addTrack_Button.Click += editTrack_Click;
                addTrack_Button.Text = "Confirm Edit";
            }
            else
                addTrack_Button.Click += addTrack_Click;
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "WAV files (*.wav)|*.wav";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedAudio = openFileDialog.FileName;
                fileNameLabel.Text = Path.GetFileName(selectedAudio);
            }
        }

        private async void addTrack_Click(object? sender, EventArgs e)
        {
            if (!verifyValidTrack()) return;
            UploadLabel.Location = new Point(304, 290);
            pictureBox1.Location = new Point(235, UploadLabel.Location.Y);
            uploadProgressBar.Location = new Point(53, 438);

            FlipVisisbility();
            // Do something with the selected file path
            string fileID = await GoogleDriveHandler.UploadFileToDrive(selectedAudio, progressPercentage =>
            {
                // Update the progress bar value or perform any other action
                uploadProgressBar.Invoke((MethodInvoker)(() =>
                {
                    uploadProgressBar.Value = progressPercentage;
                }));
            });


            Track newTrack = new Track(trackTitle_TextBox.Text, Int32.Parse(number_TextBox.Text), fileID, lyrics_TextBox.Text, this.albumID);

            TracksDAO tracksDAO = new TracksDAO();
            int result = tracksDAO.AddOneTrack(newTrack);
            if (result > 0)
                returnHome();
        }

        private async void editTrack_Click(object? sender, EventArgs e)
        {
            if (!verifyValidTrack()) return;
            var result = MessageBoxHelper.ConfirmEditBox("Do you really want to edit this Track?", "Confirm Edit");
            if (result == DialogResult.No) return;
            FlipVisisbility();
            Track editedTrack = new Track(
                trackTitle_TextBox.Text,
                Int32.Parse(number_TextBox.Text),
                String.IsNullOrEmpty(selectedAudio) ? trackToEdit.AudioFileID : await GoogleDriveHandler.UploadFileToDrive(selectedAudio, progressPercentage =>
                    {
                        // Update the progress bar value or perform any other action
                        uploadProgressBar.Invoke((MethodInvoker)(() =>
                        {
                            uploadProgressBar.Value = progressPercentage;
                        }));
                    }),
                lyrics_TextBox.Text,
                this.albumID);

            TracksDAO tracksDAO = new TracksDAO();
            int itemsUpdated = tracksDAO.UpdateTrack(editedTrack, trackToEdit.ID);
            if (itemsUpdated > 0)
                returnHome();
        }

        private void returnHome()
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            FormSwitcher.OpenNewForm<AlbumForm>(this, albumsDAO.GetOneAlbum(albumID));
        }

        private void home_Button_Click(object sender, EventArgs e) => this.returnHome();

        private void FlipVisisbility()
        {
            foreach (Control control in this.Controls)
                control.Visible = !control.Visible;
        }

        bool verifyValidTrack()
        {
            string msg = "";
            if (String.IsNullOrEmpty(trackTitle_TextBox.Text))
                msg += "Track has no title\n";
            if (String.IsNullOrEmpty(selectedAudio))
                msg += "You need to choose an audio file\n";
            if (!String.IsNullOrEmpty(msg)) MessageBoxHelper.ShowErrorBox(msg, "Error");

            return String.IsNullOrEmpty(msg);

        }
    }
}
