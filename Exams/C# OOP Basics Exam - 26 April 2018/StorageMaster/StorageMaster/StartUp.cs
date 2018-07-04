using StorageMaster.Core;
using System.Globalization;
using System.Threading;

namespace StorageMaster
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = new Engine();
            engine.Run();
        }
    }
}
