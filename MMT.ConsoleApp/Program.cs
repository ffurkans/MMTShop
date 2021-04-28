using MMT.Domain.Abstractions.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MMT.ConsoleApp
{
	class Program
	{
		static HttpClient client = new HttpClient();
		static void Main(string[] args)
		{
			client.BaseAddress = new Uri("https://localhost:44393/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
			var products = GetProductsAsync("Product/products/featured").GetAwaiter().GetResult();
			Console.WriteLine("Featured Products :");
			foreach (var item in products)
			{
				Console.WriteLine(" - " + item.Name);
			}

			Console.WriteLine("---------------------------");
			Console.WriteLine("");

			Console.WriteLine("All Categories :");
			var categories = GetCategoriesAsync("Category").GetAwaiter().GetResult();
			foreach (var item in categories)
			{
				Console.WriteLine(" - " + item.Id + "    " +item.Name );
			}

			Console.WriteLine("---------------------------");
			Console.WriteLine("---------------------------");

			Console.WriteLine("");


			Console.WriteLine("Products by category id:");
			Console.WriteLine("---------------------------");
			foreach (var item in categories)
			{
				var productsByCategory = GetProductsAsync("Product/products-by-category/" + item.Id).GetAwaiter().GetResult();
				Console.WriteLine("Products for category : " + item.Name);
				foreach (var product in productsByCategory)
				{
					Console.WriteLine(" - " + product.Name);
				}
				Console.WriteLine("---------------------------");
			}

			Console.ReadLine();
		}


		static async Task<List<ProductDTO>> GetProductsAsync(string path)
		{
			List<ProductDTO> products = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				products = await response.Content.ReadAsAsync<List<ProductDTO>>();
			}
			return products;
		}


		static async Task<List<CategoryDTO>> GetCategoriesAsync(string path)
		{
			List<CategoryDTO> products = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				products = await response.Content.ReadAsAsync<List<CategoryDTO>>();
			}
			return products;
		}
	}
}
