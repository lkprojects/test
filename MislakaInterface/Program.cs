using System.Threading;
using log4net;
using System;

namespace MislakaInterface
{

    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            Console.WindowHeight = 40;
            Console.WindowWidth = 150;
            int CycleInterval = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CycleInterval"]);

            log.Info("************************************************************************************************************");
            log.Info("Start Mislaka Interface");
            while (true)
            {
                MislakaDataFlow.ProcessCycle();
                Thread.Sleep(CycleInterval); // 1 minute sleep 
            }
            // log.Info("End Mislaka Interface");
        }

    }
}
