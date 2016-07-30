using System;
using System.Threading;

namespace MailSystem
{
    class Program
    {
        static void a_MailArrived(object sender, MailArrivedEventArgs e)
        {
            Console.WriteLine("Title : "+e.Title+", Body : "+e.Body);
        }

        static void Main()
        {
            MailManager aMailManager = new MailManager();
            aMailManager.MailArrived += new EventHandler<MailArrivedEventArgs>(a_MailArrived);
            aMailManager.SimulateMailArrived();
            Timer timer = new Timer(delegate { aMailManager.SimulateMailArrived(); }, null ,0 ,1000);
            Console.Read();
        }
    }
}
