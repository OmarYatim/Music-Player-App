using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Music_Player_App
{
    internal class TracksDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=music";

        public List<Track> getTracksForAlbum(int albumID)
        {
            List<Track> tracks = new List<Track>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM `tracks` WHERE albums_ID = @albumid";
            command.Parameters.AddWithValue("@albumid", albumID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Track newTrack = new Track(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));

                    tracks.Add(newTrack);
                }
            }

            connection.Close();
            return tracks;
        }

        public List<JObject> getTracksUsingJoin(int albumID)
        {
            List<JObject> tracks = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT tracks.ID as trackID, albums.ALBUM_TITLE, `TRACK_TITLE`, `VIDEO_URL`, `LYRICS` FROM `tracks` JOIN albums ON albums_ID = albums.ID WHERE albums_ID = @albumid";
            command.Parameters.AddWithValue("@albumid", albumID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject newTrack = new JObject();
                    for (int i = 0; i < reader.FieldCount; i++)
                        newTrack.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());

                    tracks.Add(newTrack);
                }
            }

            connection.Close();
            return tracks;
        }

        public int deleteTrack(int trackID)
        {
            Track track = GetOneTrack(trackID);
            GoogleDriveHandler.DeleteFile(track.AudioFileID);

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("DELETE FROM tracks WHERE `tracks`.`ID` = @trackid", connection);

            command.Parameters.AddWithValue("@trackid", trackID);

            int deletedRows = command.ExecuteNonQuery();

            connection.Close();
            return deletedRows;
        }

        public int deleteTracksByAlbumID(int albumID) 
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("DELETE FROM tracks WHERE `tracks`.`albums_ID` = @albumid", connection);

            command.Parameters.AddWithValue("@albumid", albumID);

            int deletedRows = command.ExecuteNonQuery();

            connection.Close();
            return deletedRows;
        }

        private Track GetOneTrack(int trackID)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `tracks` WHERE ID=@trackID", connection);
            command.Parameters.AddWithValue("@trackID", trackID);

            Track track = new Track();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Track t = new Track(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(3), reader.GetInt32(5));                   

                    track = t;
                }
            }

            connection.Close();
            return track;
        }

        internal int AddOneTrack(Track newTrack)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO `tracks`(`TRACK_TITLE`, `NUMBER`, `AUDIO_FILE_ID`, `LYRICS`, `albums_ID`) VALUES (@trackTitle,@number,@fileID,@lyrics,@album_ID)", connection);

            command.Parameters.AddWithValue("@trackTitle", newTrack.Name);
            command.Parameters.AddWithValue("@number", newTrack.Number);
            command.Parameters.AddWithValue("@fileID", newTrack.AudioFileID);
            command.Parameters.AddWithValue("@lyrics", newTrack.Lyrics);
            command.Parameters.AddWithValue("@album_ID", newTrack.Album_ID);

            int newRows = command.ExecuteNonQuery();

            connection.Close();
            return newRows;
        }

        internal int UpdateTrack(Track newTrack, int iD)
        {
            Track updatedTrack = GetOneTrack(iD);
            int updatedRows = 0;
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            if (updatedTrack.Name != newTrack.Name)
            {
                MySqlCommand command = new MySqlCommand("UPDATE `tracks` SET `TRACK_TITLE`=@trackTitle WHERE `ID`=@trackID", connection);
                command.Parameters.AddWithValue("@trackTitle", newTrack.Name);
                command.Parameters.AddWithValue("@trackID", iD);
                updatedRows += command.ExecuteNonQuery();
            }

            if (updatedTrack.Number != newTrack.Number)
            {
                MySqlCommand command = new MySqlCommand("UPDATE `tracks` SET `NUMBER`=@number WHERE `ID`=@trackID", connection);
                command.Parameters.AddWithValue("@number", newTrack.Number);
                command.Parameters.AddWithValue("@trackID", iD);
                updatedRows += command.ExecuteNonQuery();
            }

            if (updatedTrack.AudioFileID != newTrack.AudioFileID)
            {
                MySqlCommand command = new MySqlCommand("UPDATE `tracks` SET `AUDIO_FILE_ID`=@fileID WHERE `ID`=@trackID", connection);
                command.Parameters.AddWithValue("@fileID", newTrack.AudioFileID);
                command.Parameters.AddWithValue("@trackID", iD);
                updatedRows += command.ExecuteNonQuery();
            }

            if (updatedTrack.Lyrics != newTrack.Lyrics)
            {
                MySqlCommand command = new MySqlCommand("UPDATE `tracks` SET `LYRICS`=@lyrics WHERE `ID`=@trackID", connection);
                command.Parameters.AddWithValue("@lyrics", newTrack.Lyrics);
                command.Parameters.AddWithValue("@trackID", iD);
                updatedRows += command.ExecuteNonQuery();
            }

            connection.Close();
            return updatedRows;
        }
    }
}
