using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace kernetics.messenger.web
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = "http://localhost:8888";
            Console.WriteLine(uri);
            // initialize an instance of NancyHost (found in the Nancy.Hosting.Self package)
            var host = new NancyHost(new Uri(uri));
            host.Start();  // start hosting

            var smtpServer = new Rnwood.SmtpServer.DefaultServer();
            smtpServer.MessageReceived += smtpServer_MessageReceived;
            smtpServer.Start();

            Console.WriteLine("SMTP server state: " + (smtpServer.IsRunning ? "Running" : "Not running"));

            //Under mono if you deamonize a process a Console.ReadLine with cause an EOF 
            //so we need to block another way
            if (args.Any(s => s.Equals("-d", StringComparison.CurrentCultureIgnoreCase)))
            {
                // TODO Thread sleep looks stupid
                while (true) Thread.Sleep(10000000);
            }
            else
            {
                Console.ReadKey();
            }

            smtpServer.Stop();
            host.Stop();  // stop hosting
        }

        static void smtpServer_MessageReceived(object sender, Rnwood.SmtpServer.MessageEventArgs e)
        {
            Console.WriteLine("Message received: " + e.Message.ToString());
        }
    }
}
