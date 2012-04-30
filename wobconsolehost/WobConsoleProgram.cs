using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using wobsvclib;

namespace wobconsolehost
{
    class WobConsoleProgram
    {
        static void Main(string[] args)
        {
            string command;
            Uri baseAddress = new Uri("http://localhost:8000/wob/Login");
            ServiceHost selfHost = null;
            try
            {
                selfHost = new ServiceHost(typeof(LoginService), baseAddress);
                selfHost.AddServiceEndpoint(typeof(ILogin), new WSDualHttpBinding(), "LoginService");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("Open");
                while (true)
                {
                    command = Console.ReadLine();
                    if (command == "e")
                        break;
                }
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Failure!");
                Console.WriteLine(ce);
                Console.ReadLine();
                selfHost.Abort();
            }
        }
    }
}
