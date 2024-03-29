using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsApp
{
    public static class ServiceBusQueue
    {
        [FunctionName("ServiceBusQueue")]
        public static void Run([ServiceBusTrigger("queue001", Connection = "ConnectionStringQueue")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
