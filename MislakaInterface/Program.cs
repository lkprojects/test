using System.Threading;
using log4net;

namespace MislakaInterface
{

    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static MislakaDataFlow mislakaFileHandler = new MislakaDataFlow();
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            log.Info("************************************************************************************************************");
            log.Info("Start Mislaka Interface");

            while (true)
            {
                mislakaFileHandler.ProcessCycle();
                Thread.Sleep(60000); // 1 minute sleep 
            }
            // log.Info("End Mislaka Interface");
        }

    }
}
