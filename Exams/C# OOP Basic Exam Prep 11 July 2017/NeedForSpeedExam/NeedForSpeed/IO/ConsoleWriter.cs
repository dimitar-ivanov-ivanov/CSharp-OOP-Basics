using System;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string contents)
    {
        Console.WriteLine(contents);
    }
}
