namespace Online_Radio_Database
{
    using Online_Radio_Database.Exceptions;
    using Online_Radio_Database.Models;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var n = int.Parse(Console.ReadLine());
            var totalSongs = 0;
            var totalTime = new TimeSpan();

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    var minutes = int.Parse(args[2]);
                    var seconds = int.Parse(args[3]);

                    var song = new Song(args[0], args[1], minutes, seconds);
                    totalTime = totalTime.Add(new TimeSpan(0, minutes, seconds));

                    totalSongs++;
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Songs added: {totalSongs}");
            Console.WriteLine($"Playlist length: {totalTime.Hours}h {totalTime.Minutes}m {totalTime.Seconds}s");
        }
    }
}
