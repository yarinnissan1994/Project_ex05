using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Project_ex05.entities;
using Project_ex05.model;
using System.Reflection;

namespace Project_ex05.microServer
{
    //public static class Products
    //{
    //    [FunctionName("Products")]
    //    public static async Task<IActionResult> Run(
    //        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
    //        ILogger log)
    //    {
    //        log.LogInformation("C# HTTP trigger function processed a request.");

    //        if (req.Method == "GET")
    //        {
    //            MainManager.Instance.ProductM.SendSqlQueryToReadFromDB("select * from Products");

    //            string responseMessage = System.Text.Json.JsonSerializer.Serialize(MainManager.Instance.ProductM.ProductsList);

    //            return new OkObjectResult(responseMessage);
    //        }
    //        else if (req.Method == "POST")
    //        {
    //            UserMessage data = new UserMessage();
    //            data = System.Text.Json.JsonSerializer.Deserialize<UserMessage>(req.Body);
    //            string sqlQuery = "insert into ContactUs values('"+data.name+"','"+data.message+"','"+data.phone+"','"+data.email+"',getdate())";
    //            MainManager.Instance.MessageM.SendSqlQueryWriteToDB(sqlQuery);
    //        }

    //        return null;
    //    }
    //}

    public static class Products
    {
        [FunctionName("Products")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", Route = "Users/{action}/{IdNumber?}")] HttpRequest req,
            string action, string IdNumber, ILogger log)
        {
            string requestBody;

            switch (action)
            {
                case "get":
                    MainManager.Instance.ProductM.CreateProductListFromDB();
                    string responseMessage = System.Text.Json.JsonSerializer.Serialize(MainManager.Instance.ProductM.ProductsList);
                    return new OkObjectResult(responseMessage);

                case "post-message":
                    UserMessage data = new UserMessage();
                    data = System.Text.Json.JsonSerializer.Deserialize<UserMessage>(req.Body);
                    MainManager.Instance.MessageM.SendUserMessageToDB(data);
                    break;

                case "update":

                    requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                    model.Product product = System.Text.Json.JsonSerializer.Deserialize<model.Product>(requestBody);
                    MainManager.Instance.ProductM.UpdateProduct(product);
                    break;

                case "delete":

                    MainManager.Instance.ProductM.DeleteAProductByProductID(IdNumber);

                    break;

                default:
                    break;

            }


            return null;
        }
    }
}
