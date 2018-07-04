namespace Online_Radio_Database.Models
{
    using Online_Radio_Database.Exceptions;

    public class Song
    {
        private string artistName;
        private string songName;
        private int minutes;
        private int seconds;

        private const int MinArtistNameLength = 3;
        private const int MaxArtistNameLength = 20;

        private const int MinSongNameLength = 3;
        private const int MaxSongNameLength = 30;

        private const int MaxSongMinutes = 14;
        private const int MaxSongHours = 59;

        public Song(string artistName, string songName, int minutes, int seconds)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public string ArtistName
        {
            get { return this.artistName; }
            set
            {
                if (value.Length >= MinArtistNameLength &&
                   value.Length <= MaxArtistNameLength)
                {
                    this.artistName = value;
                }
                else
                {
                    throw new InvalidArtistNameException();
                }
            }
        }

        public string SongName
        {
            get { return this.songName; }
            set
            {
                if (value.Length >= MinSongNameLength &&
                   value.Length <= MaxSongNameLength)
                {
                    this.songName = value;
                }
                else
                {
                    throw new InvalidSongNameException();
                }
            }
        }

        public int Minutes
        {
            get { return this.minutes; }
            set
            {
                if (value >= 0 && value <= MaxSongMinutes)
                {
                    this.minutes = value;
                }
                else
                {
                    throw new InvalidSongMinutesException();
                }
            }
        }

        public int Seconds
        {
            get { return this.seconds; }
            set
            {
                if (value >= 0 && value <= MaxSongHours)
                {
                    this.seconds = value;
                }
                else
                {
                    throw new InvalidSongSecondsException();
                }
            }
        }
    }
}
