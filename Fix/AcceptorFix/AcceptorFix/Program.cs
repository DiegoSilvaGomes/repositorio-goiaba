using System;
using System.Collections.Generic;
using QuickFix;
using QuickFix.Fields;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace AcceptorFix
{
    public class MyApp
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            SessionSettings settings = new SessionSettings(@"C:\Projects\Fix\AcceptorFix\AcceptorFix\acceptor.cfg");
            IApplication myApp = new MyQuickFixApp();
            IMessageStoreFactory storeFactory = new FileStoreFactory(settings);
            ILogFactory logFactory = new FileLogFactory(settings);
            ThreadedSocketAcceptor acceptor = new ThreadedSocketAcceptor(
                myApp,
                storeFactory,
                settings,
                logFactory);

            acceptor.Start();
            while (true)
            {
                //System.Console.WriteLine("o hai");
                System.Threading.Thread.Sleep(1000);
            }
            acceptor.Stop();
        }
    }
}