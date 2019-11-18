using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.ServiceBus;
using System.Text;
using AzureFunctionsApp.Models;
using System.Collections.Generic;

namespace AzureFunctionsApp
{
    public static class HttpFunctionTopic
    {
        [FunctionName("HttpFunctionTopic")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            ITopicClient topicClient = new TopicClient(Environment.GetEnvironmentVariable("ConnectionStringtopic002"), "topic002");

            Message message = new Message(Encoding.UTF8.GetBytes(requestBody));

            await topicClient.SendAsync(message);
            await topicClient.CloseAsync();

            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(requestBody);

            return new OkObjectResult(employees);
        }
    }
}
