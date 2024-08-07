
using System.Drawing.Imaging;

namespace Music_Player_App
{
    public partial class AddAlbumForm : Form
    {
        int albumToEditID = -1;
        public AddAlbumForm(bool editMode, Album albumToEdit = null)
        {
            InitializeComponent();
            if (editMode)
            {
                albumToEditID = albumToEdit.ID;
                addAlbum_Button.Click += editAlbum;
                home_Button.Click += returnToAlbumClick;
                label1.Text = "Edit " + albumToEdit.AlbumName.ToString() + " Album";
                home_Button.Text = "Return";
                addAlbum_Button.Text = "Confirm Edit";
                albumName_TextBox.Text = albumToEdit.AlbumName.ToString();
                artistName_TextBox.Text = albumToEdit.ArtistName.ToString();
                year_TextBox.Text = albumToEdit.Year.ToString();
                description_TextBox.Text = albumToEdit.AlbumDescription.ToString();
                using (MemoryStream memoryStream = new MemoryStream(albumToEdit.ImageData))
                {
                    if (albumToEdit.ImageData.Length > 0)
                    {
                        Image image = Image.FromStream(memoryStream);
                        album_PictureBox.Image = image;
                    }
                }
            }
            else
            {
                addAlbum_Button.Click += addAlbum;
                home_Button.Click += returnHomeClick;
            }
        }

        private void returnHomeClick(object sender, EventArgs e) => FormSwitcher.OpenNewForm<HomePage>(this);

        //Get Single ALbum by ID and return to edited Album
        private void returnToAlbumClick(object? sender, EventArgs e)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            FormSwitcher.OpenNewForm<AlbumForm>(this, albumsDAO.GetOneAlbum(albumToEditID));
        }
        private void album_PictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                // Load the image into a Bitmap object
                Bitmap selectedImage = new Bitmap(filePath);

                // Display the image in the PictureBox
                album_PictureBox.Image = selectedImage;
            }
        }

        private void addAlbum(object sender, EventArgs e)
        {
            if (!verifyValidAlbum()) return;
            Album newAlbum = new Album(albumName_TextBox.Text, artistName_TextBox.Text, Int32.Parse(year_TextBox.Text), imageToByteArray(album_PictureBox.Image != null ? album_PictureBox.Image : Properties.Resources.DefaultImage), description_TextBox.Text);

            AlbumsDAO albumsDAO = new AlbumsDAO();
            int result = albumsDAO.AddOneAlbum(newAlbum);
            if (result > 0)
                FormSwitcher.OpenNewForm<HomePage>(this);
        }

        private void editAlbum(object? sender, EventArgs e)
        {
            if (!verifyValidAlbum()) return;
            var result = MessageBoxHelper.ConfirmEditBox("Do you really want to edit the album?", "Confirm Edit");
            if (result == DialogResult.No) return;
            Album editedAlbum = new Album(albumName_TextBox.Text, artistName_TextBox.Text, Int32.Parse(year_TextBox.Text), imageToByteArray(album_PictureBox.Image != null ? album_PictureBox.Image : Properties.Resources.DefaultImage), description_TextBox.Text);

            AlbumsDAO albumsDAO = new AlbumsDAO();
            int itemsUpdated = albumsDAO.UpdateAlbum(editedAlbum, albumToEditID);
            if (itemsUpdated > 0)
                FormSwitcher.OpenNewForm<HomePage>(this);
        }

        private void year_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private byte[] imageToByteArray(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                album_PictureBox.Image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private bool verifyValidAlbum()
        {
            string msg = "";
            if (String.IsNullOrEmpty(albumName_TextBox.Text))
                msg += "Album has no name\n";
            if (String.IsNullOrEmpty(artistName_TextBox.Text))
                msg += "Album has no artist name\n";
            if (!verifyValidYear())
                msg += "Add a valid year\n";
            if (!String.IsNullOrEmpty(msg)) MessageBoxHelper.ShowErrorBox(msg, "Error");

            return String.IsNullOrEmpty(msg);
        }

        bool verifyValidYear()
        {
            if (Int32.TryParse(year_TextBox.Text, out int year))
                return (year > 1900 && year <= DateTime.Now.Year);
            return false;
        }
    }
}
