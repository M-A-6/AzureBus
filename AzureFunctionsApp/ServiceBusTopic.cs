using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsApp
{
    public static class ServiceBusTopic
    {
        [FunctionName("ServiceBusTopic")]
        public static void Run([ServiceBusTrigger("topic001", "subscribe001", Connection = "ConnectionStringtopic001")]string mySbMsg, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");

        }
    }
}
