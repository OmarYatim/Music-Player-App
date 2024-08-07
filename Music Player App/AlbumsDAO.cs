using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Music_Player_App
{
    internal class AlbumsDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=music";

        public List<Album> getAllAlbums()
        {
            List<Album> albums = new List<Album>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM ALBUMS", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) 
                {
                    Album a = new Album(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), (byte[])reader["IMAGE_NAME"], reader.GetString(5));

                    TracksDAO tracksDAO = new TracksDAO();
                    a.Tracks = tracksDAO.getTracksForAlbum(a.ID);
                    
                    albums.Add(a);  
                }
            }

            connection.Close();
            return albums;
        }

        public List<Album> searchAlbums(string searchTerm)
        {
            List<Album> albums = new List<Album>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string searchWildPhrase = searchTerm + "%";
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM ALBUMS WHERE ALBUM_TITLE LIKE @search || ARTIST LIKE @search";
            command.Parameters.AddWithValue("@search", searchWildPhrase);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Album a = new Album(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), (byte[])reader["IMAGE_NAME"], reader.GetString(5));
                    
                    albums.Add(a);
                }
            }

            connection.Close();
            return albums;
        }

        internal int AddOneAlbum(Album newAlbum)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO `albums`(`ALBUM_TITLE`, `ARTIST`, `YEAR`, `IMAGE_NAME`, `DESCRIPTION`) VALUES (@albumTitle, @artist, @year, @imageData, @description)", connection);

            command.Parameters.AddWithValue("@albumTitle", newAlbum.AlbumName);
            command.Parameters.AddWithValue("@artist", newAlbum.ArtistName);
            command.Parameters.AddWithValue("@year", newAlbum.Year);
            command.Parameters.AddWithValue("@imageData",newAlbum.ImageData);
            command.Parameters.AddWithValue("@description", newAlbum.AlbumDescription);

            int newRows = command.ExecuteNonQuery();

            connection.Close();
            return newRows;
        }

        internal int UpdateAlbum(Album newAlbum, int editedEntryID)
        {
            Album updatedAlbum = GetOneAlbum(editedEntryID);
            int updatedRows = 0;
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            if(updatedAlbum.AlbumName != newAlbum.AlbumName)
            { 
                MySqlCommand command = new MySqlCommand("UPDATE `albums` SET `ALBUM_TITLE`=@albumTitle WHERE `ID`=@albumID", connection);
                command.Parameters.AddWithValue("@albumTitle", newAlbum.AlbumName);
                command.Parameters.AddWithValue("@albumID", editedEntryID);
                updatedRows += command.ExecuteNonQuery();
            }

            if (updatedAlbum.ArtistName != newAlbum.ArtistName)
            {
                MySqlCommand command = new MySqlCommand("UPDATE `albums` SET `ARTIST`=@artistName WHERE `ID`=@albumID", connection);
                command.Parameters.AddWithValue("@artistName", newAlbum.ArtistName);
                command.Parameters.AddWithValue("@albumID", editedEntryID);
                updatedRows += command.ExecuteNonQuery();
            }

            if (updatedAlbum.Year != newAlbum.Year)
            {
                MySqlCommand command = new MySqlCommand("UPDATE `albums` SET `YEAR`=@Year WHERE `ID`=@albumID", connection);
                command.Parameters.AddWithValue("@Year", newAlbum.Year);
                command.Parameters.AddWithValue("@albumID", editedEntryID);
                updatedRows += command.ExecuteNonQuery();
            }

            if (newAlbum.ImageData != null && !updatedAlbum.ImageData.SequenceEqual(newAlbum.ImageData))
            {
                MySqlCommand command = new MySqlCommand("UPDATE `albums` SET `IMAGE_NAME`=@ImageData WHERE `ID`=@albumID", connection);
                command.Parameters.AddWithValue("@ImageData", newAlbum.ImageData);
                command.Parameters.AddWithValue("@albumID", editedEntryID);
                updatedRows += command.ExecuteNonQuery();
            }

            if (newAlbum.AlbumDescription != updatedAlbum.AlbumDescription)
            {
                MySqlCommand command = new MySqlCommand("UPDATE `albums` SET `DESCRIPTION`=@description WHERE `ID`=@albumID", connection);
                command.Parameters.AddWithValue("@description", newAlbum.AlbumDescription);
                command.Parameters.AddWithValue("@albumID", editedEntryID);
                updatedRows += command.ExecuteNonQuery();
            }

            connection.Close();
            return updatedRows;
        }

        public Album GetOneAlbum(int albumID) 
        { 
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM ALBUMS WHERE ID=@albumID", connection);
            command.Parameters.AddWithValue("@albumID", albumID);

            Album album = new Album();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Album a = new Album(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), (byte[])reader["IMAGE_NAME"], reader.GetString(5));

                    TracksDAO tracksDAO = new TracksDAO();
                    a.Tracks = tracksDAO.getTracksForAlbum(a.ID);

                    album = a;
                }
            }
        

            connection.Close();
            return album;

        }

        internal int deleteAlbum(int albumID)
        {
            var tracks = GetOneAlbum(albumID).Tracks;

            foreach (var track in tracks)
                GoogleDriveHandler.DeleteFile(track.AudioFileID);

            TracksDAO tracksDAO = new TracksDAO();
            tracksDAO.deleteTracksByAlbumID(albumID);

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("DELETE FROM ALBUMS WHERE ID = @albumID", connection);

            command.Parameters.AddWithValue("@albumID", albumID);

            int deletedRows = command.ExecuteNonQuery();

            connection.Close();
            return deletedRows;
        }
    }
}
