namespace P03_StudentSystem
{
    using P03_StudentSystem.Models;
    using System.Globalization;
    using System.Threading;

    public class StartUp
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Execute();
        }

        private static void Execute()
        {
            StudentSystem studentSystem = new StudentSystem();
            while (true)
            {
                studentSystem.ParseCommand();
            }
        }
    }
}
