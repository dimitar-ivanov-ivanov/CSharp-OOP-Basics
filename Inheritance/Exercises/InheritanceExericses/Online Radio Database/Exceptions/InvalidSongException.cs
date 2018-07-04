namespace Online_Radio_Database.Exceptions
{
    using System;

    public class InvalidSongException : Exception
    {
        public override string Message => $"Invalid song.";
    }
}
