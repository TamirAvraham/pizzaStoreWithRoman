using ConsoleApp2;
using Newtonsoft.Json;
using PizzaBackEnd;
using System.Text.Json;

namespace WebApplication1.Services
{
    public static class PizzaService
    {
        static HttpClient client = new HttpClient();
        
        public static async Task<List<Pizza>> GetAllPizzasAsync(string path)
        {
            List<Pizza> pizzas = new List<Pizza>();
            RestResponce? rest = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                rest = await response.Content.ReadFromJsonAsync<RestResponce>();
                JsonElement json = rest?.Data["data"];
                foreach (var item in json.EnumerateArray())
                {
                    pizzas.Add(JsonConvert.DeserializeObject<Pizza>(item.ToString())!);
                }

            }
            return pizzas;
        }
        public static async Task<Uri?> CreatePizzaAsync(Pizza pizza,string path)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                path, pizza);
            response.EnsureSuccessStatusCode();
            RestResponce? rest = await response.Content.ReadFromJsonAsync<RestResponce>();
            JsonElement json = rest?.Data["data"];
            // return URI of the created resource.
            return response.Headers.Location;
        }
        public static async Task<Pizza?> UpdatePizzaAsync(Pizza pizza,string path)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
            $"path/{pizza.Id}", pizza);
            response.EnsureSuccessStatusCode();
            RestResponce? rest = await response.Content.ReadFromJsonAsync<RestResponce>();
            JsonElement json = rest?.Data["data"];
            foreach (var item in json.EnumerateArray())
            {
                return JsonConvert.DeserializeObject<Pizza>(item.ToString())!;
            }
        }

    }
}

