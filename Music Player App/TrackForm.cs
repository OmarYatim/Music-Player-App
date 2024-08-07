using NAudio.Wave;
using System;
using Timer = System.Windows.Forms.Timer;

namespace Music_Player_App
{
    public partial class TrackForm : Form
    {
        private Timer progressTimer;
        private Track track;
        private AudioHandler audioHandler;

        public TrackForm(Track track)
        {
            InitializeComponent();
            play_Button.BackgroundImage = Properties.Resources.Play_Button;
            this.track = track;
            trackName_Label.Text = track.Name;
            lyrics_Label.Text = track.Lyrics;
            Load += async (sender, e) => await InitializeFormAsync();
        }

        public async Task InitializeFormAsync()
        {
            this.FlipInvisibility();
            byte[] fileBytes = await GoogleDriveHandler.DownloadFileFromDrive(track.AudioFileID);
            this.FlipInvisibility();
            audioHandler = new AudioHandler(fileBytes);
            audioHandler.PlayAudio();
            play_Button.BackgroundImage = Properties.Resources.Pause_Button;

            // Start progress update timer
            progressTimer = new Timer();
            progressTimer.Interval = 100; // Update progress every 100 milliseconds (adjust as needed)
            progressTimer.Tick += ProgressTimer_Tick;
            progressTimer.Start();
        }

        private void ProgressTimer_Tick(object? sender, EventArgs e)
        {
            if (audioHandler.GetAudioPlaybackState() == PlaybackState.Playing)
            {

                if (audioHandler. GetProgress() == 1) play_Button.BackgroundImage = Properties.Resources.Play_Button;

                progressPanel.Size = new Size((int)(audioHandler.GetProgress() * progressBox.Width), progressPanel.Height);
            }
        }

        private void home_Button_Click(object sender, EventArgs e) => ReturnToAlbum();


        private void replay_Button_Click(object sender, EventArgs e)
        {
            audioHandler.RestartAudio();
            play_Button.BackgroundImage = Properties.Resources.Pause_Button;
        }

        private void play_Button_Click(object sender, EventArgs e)
        {
            switch (audioHandler.GetAudioPlaybackState())
            {
                case PlaybackState.Playing:
                    audioHandler.PauseAudio();
                    play_Button.BackgroundImage = Properties.Resources.Play_Button;
                    break;
                case PlaybackState.Paused:
                    audioHandler.ResumeAudio();
                    play_Button.BackgroundImage = Properties.Resources.Pause_Button;
                    break;
                case PlaybackState.Stopped:
                    audioHandler.RestartAudio();   
                    play_Button.BackgroundImage = Properties.Resources.Pause_Button;
                    break;
                default:
                    audioHandler.StopAudio();
                    play_Button.BackgroundImage = Properties.Resources.Play_Button;
                    break;
            }
        }

        private void delete_Button_Click(object sender, EventArgs e)
        {
            int trackID = track.ID;
            GoogleDriveHandler.DeleteFile(track.AudioFileID);
            TracksDAO tracksDAO = new TracksDAO();
            int result = tracksDAO.deleteTrack(trackID);
            if (result == 0)
            {
                MessageBoxHelper.ShowErrorBox("An Error occured while deleting the Track, Please Try again at a later time", "Network Error");
                return;
            }
            ReturnToAlbum();
        }

        private void edit_Button_Click(object sender, EventArgs e)
        {
            audioHandler.StopAudio();
            FormSwitcher.OpenNewForm<AddTrack>(this, track.Album_ID, track);
        }

        private void FlipInvisibility()
        {
            foreach (Control control in this.Controls)
                control.Visible = !control.Visible;
        }

        private void ReturnToAlbum()
        {
            audioHandler.StopAudio();
            AlbumsDAO albumsDAO = new AlbumsDAO();
            FormSwitcher.OpenNewForm<AlbumForm>(this, albumsDAO.GetOneAlbum(track.Album_ID));
        }

        private void TrackForm_Resize(object sender, EventArgs e) => lyrics_Label.MaximumSize = new Size(ClientSize.Width - lyrics_Label.Left * 2, 0);
    }
}
