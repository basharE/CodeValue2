using System;
using System.Threading;

namespace MailSystem
{
    class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;

        public void SimulateMailArrived()
        {
            OnMailArrived(new MailArrivedEventArgs("hello","hello world"));
        }

        protected virtual void OnMailArrived(MailArrivedEventArgs e)
        {
            MailArrived?.Invoke(this, e);
        }
    }

    class MailArrivedEventArgs :EventArgs
    {
        public string Title { get; }
        public string Body { get; }

        public MailArrivedEventArgs(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}
