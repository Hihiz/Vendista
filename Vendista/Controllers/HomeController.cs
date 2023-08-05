using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using Vendista.Models;
using Vendista.ViewModels;

namespace Vendista.Controllers
{
    public class HomeController : Controller
    {      
      public HomeController() { }

        public ActionResult Index()
        {
            var client = new RestClient("http://178.57.218.210:398/token?login=<>&password=<>");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            DataToken respContext = JsonSerializer.Deserialize<DataToken>(response.Content);
            var token = respContext.token;

            client = new RestClient("http://178.57.218.210:398/commands/types?token=" + token);
            request = new RestRequest(Method.GET);
            response = client.Execute(request);
            Command command = JsonSerializer.Deserialize<Command>(response.Content);
            List<Data> items = new List<Data>();
            foreach (var item in command.items)
            {
                Data data = new Data();
                data.id = item.id;
                data.name = item.name;
                data.RawData = JsonSerializer.Serialize(item);
                data.Token = token;
                items.Add(data);
            }

            return View(items);
        }
    }
}