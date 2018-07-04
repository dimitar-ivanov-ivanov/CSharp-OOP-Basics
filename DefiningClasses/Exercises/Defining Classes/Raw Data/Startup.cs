﻿namespace Raw_Data
{
    using Raw_Data.Models;
    using System;
    using System.Globalization;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Execute();
        }

        public static void Execute()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}