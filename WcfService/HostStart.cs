using System;
using System.ServiceModel;

namespace WcfService
{
    internal class HostStart
    {
        private static void Main(string[] args)
        {
            try
            {
                var selfHost = new ServiceHost(typeof (ServiceAlias));
                selfHost.Open();

                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
            }
        }
    }
}