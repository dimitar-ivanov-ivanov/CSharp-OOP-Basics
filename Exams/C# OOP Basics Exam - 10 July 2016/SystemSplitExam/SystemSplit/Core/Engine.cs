using System;
using System.Linq;
using System.Reflection;

public class Engine
{
    private const string TerminatingCommand = "System Split";

    private CommandCenter commandCenter;


    public Engine()
    {
        this.commandCenter = new CommandCenter();
    }

    public void Run()
    {
        var input = Console.ReadLine();

        while (input != TerminatingCommand)
        {
            var args = input.Split(new[] { ' ', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            var methodName = args[0];

            var methodToInvoke = this.commandCenter
                .GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.Public | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == methodName);

            var nonParsedArgs = args.Skip(1).ToArray();
            var methodArgs = methodToInvoke.GetParameters();
            var parsedArgs = new object[methodArgs.Length];

            for (int i = 0; i < methodArgs.Length; i++)
            {
                var type = methodArgs[i].ParameterType;
                parsedArgs[i] = Convert.ChangeType(nonParsedArgs[i], type);
            }

            var res = methodToInvoke.Invoke(this.commandCenter, parsedArgs);

            if(res != null)
            {
                Console.WriteLine(res);
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(this.commandCenter.SystemSplit());
    }
}
