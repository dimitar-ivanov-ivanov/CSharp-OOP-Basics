﻿namespace Online_Radio_Database.Exceptions
{
    public class InvalidSongNameException : InvalidSongException
    {
        public override string Message => $"Song name should be between 3 and 30 symbols.";
    }
}
