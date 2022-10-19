using Newtonsoft.Json;
using PizzaBackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Order
    {
        static HttpClient client = new HttpClient();
        public string Id { get; set; }
        public Pizza Pizza { get; set; }
        public Order(string id, Pizza pizza)
        {
            Id = id;
            Pizza = pizza;
        }
        public static async Task<List<Order>> GetAllOrdersAsync(string path)
        {
            List<Order> Orders = new List<Order>();
            RestResponce? rest = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                rest = await response.Content.ReadFromJsonAsync<RestResponce>();
                JsonElement json = rest.Data["data"];
                foreach (var item in json.EnumerateArray())
                {
                    Orders.Add(JsonConvert.DeserializeObject<Order>(item.ToString())!);
                }

            }
            return Orders;
        }
    }
}
