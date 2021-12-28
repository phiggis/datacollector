using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Assets.DTO;

namespace datacollectorfunction
{
    public static class Function1
    {
        [FunctionName("writedata")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            /*
            string name = req.Query["name"];


          string connectionString = "DefaultEndpointsProtocol=https;AccountName=phdstorageherts;AccountKey=/P9klPWf486z8gNDNXFMK6li2PrLURhgyJHXX4kmFpF/lyurKUFrdS3faEcSbels6iIElUKGLbEzDPRM0LuxOg==;EndpointSuffix=core.windows.net";

          var account = CloudStorageAccount.Parse(connectionString);
          var client = account.CreateCloudTableClient();

          var table = client.GetTableReference("phddata");
              */ 
        

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            ExperimentData data = JsonConvert.DeserializeObject<ExperimentData>(requestBody);
           
            /*
                        TableOperation insertOperation = TableOperation.Insert(data);
                        try
                        {
                            await table.ExecuteAsync(insertOperation);
                        }
                        catch (Exception a)
                        {
                      

                            Console.WriteLine(a);
                            throw;
                        }
     
                                                                  */

                        string responseMessage = $"written data successfully  {data.ToString()}";

                        Console.WriteLine(responseMessage);
                        return new OkObjectResult(responseMessage);
                    }

                    [FunctionName("keepalive")]
                    public static async Task<IActionResult> keepalive(
                        [HttpTrigger(AuthorizationLevel.Anonymous, "get",  Route = null)] HttpRequest req,
                        ILogger log)
                    {
                        log.LogInformation("C# HTTP trigger function processed a request.");

                     //   string name = req.Query["name"];

                        /*JsonObject->SetStringField(TEXT("identifier"), *FString::Printf(TEXT("%s"), *identifier));
                        JsonObject->SetStringField(TEXT("session"), *FString::Printf(TEXT("%s"), *session));
                        JsonObject->SetStringField(TEXT("trial"), *FString::Printf(TEXT("%s"), *trial));
                        JsonObject->SetStringField(TEXT("device"), *FString::Printf(TEXT("%s"), *device));
                        //JsonObject->SetStringField(TEXT("start"), *FString::Printf(TEXT("%s"), *start));
                        //JsonObject->SetStringField(TEXT("stop"), *FString::Printf(TEXT("%s"), *stop));
                        JsonObject->SetStringField(TEXT("duration"), *FString::Printf(TEXT("%s"), *duration));
                        // success or failure
                        JsonObject->SetStringField(TEXT("result"), *FString::Printf(TEXT("%s"), *result));
                          */
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            //    name = name ?? data?.name;
            //  data.
       

            string responseMessage = string.IsNullOrEmpty("ok")
                  ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                  : $"Hello, . This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
