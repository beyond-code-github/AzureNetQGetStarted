namespace Publisher
{
    using System;
    using AzureNetQ;
    using Messages;

    class Program
    {
        static void Main(string[] args)
        {
            const string connectionstring =
                   "Endpoint=sb://servicebus/ServiceBusDefaultNamespace;StsEndpoint=https://servicebus:10355/ServiceBusDefaultNamespace;RuntimePort=10354;ManagementPort=10355";

            using (var bus = AzureBusFactory.CreateBus(connectionstring))
            {
                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new TextMessage
                    {
                        Text = input
                    });
                }
            }
        }
    }
}
