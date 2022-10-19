using ConsoleApp2;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace PizzaBackEnd
{
    public class Pizza
    {
        
        [Required]
        public string Name { get; set; }
        public List<Topping> toppings { get; set; }
        public float Price { get; set; }
        public int Size { get; set; }

        public string? Id { get; set; }
        public string? PngUrl { get; set; }

        public Pizza(string name, List<Topping> toppings, float price, int size, string id, string pngUrl)
        {
            Name = name;
            this.toppings = toppings;
            Price = price;
            Size = size;
            Id = id;
            PngUrl = pngUrl;
        }
        public Pizza(Pizza pizza)
        {
            Name = pizza.Name;
            this.toppings = pizza.toppings;
            Price = pizza.Price;
            Size = pizza.Size;
            Id = pizza.Id;
            PngUrl = pizza.PngUrl;
        }

    }
}
