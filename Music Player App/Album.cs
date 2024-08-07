using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player_App
{
    public class Album
    {
        public int ID { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public int Year { get; set; }
        public byte[] ImageData { get; set; }
        public string AlbumDescription { get; set; }
        public List<Track> Tracks { get; set; }


        public Album()
        {
            this.ID = -1;
            this.AlbumName = "";
            this.ArtistName = "";
            this.Year = 0;
            this.ImageData = Array.Empty<Byte>();
            this.AlbumDescription = "";
            this.Tracks = new List<Track>();
        }

        public Album(string albumName, string artistName, int year, byte[] imgeData, string albumDescription)
        {
            this.ID = -1;
            this.AlbumName = albumName;
            this.ArtistName = artistName;
            this.Year = year;
            this.ImageData = imgeData;
            this.AlbumDescription = albumDescription;
        }

        public Album(int iD, string albumName, string artistName, int year, byte[] imgeData, string albumDescription)
        {
            this.ID = iD;
            this.AlbumName = albumName;
            this.ArtistName = artistName;
            this.Year = year;
            this.ImageData = imgeData;
            this.AlbumDescription = albumDescription;
        }

        public Album(int iD, string albumName, string artistName, int year, byte[] imgeData, string albumDescription, List<Track> tracks) 
        {
            this.ID               = iD;
            this.AlbumName        = albumName;
            this.ArtistName       = artistName;
            this.Year             = year;
            this.ImageData        = imgeData;
            this.AlbumDescription = albumDescription;
            this.Tracks           = tracks;
        }
    }
}
