namespace Music_Player_App
{
    public class Track
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string AudioFileID { get; set; }
        public string Lyrics { get; set; }
        public int Album_ID { get; set; }

        public Track() 
        {
            ID = -1;
            Name = "";
            Number = 0;
            AudioFileID = "";
            Lyrics = "";
            Album_ID = -1;
        }

        public Track(int iD, string name, int number, string audioFileID, string lyrics, int album_ID)
        {
            ID = iD;
            Name = name;
            Number = number;
            AudioFileID = audioFileID;
            Lyrics = lyrics;
            Album_ID = album_ID;
        }

        public Track(string name, int number, string audioFileID, string lyrics, int album_ID)
        {
            Name = name;
            Number = number;
            AudioFileID = audioFileID;
            Lyrics = lyrics;
            Album_ID = album_ID;
        }

    }
}