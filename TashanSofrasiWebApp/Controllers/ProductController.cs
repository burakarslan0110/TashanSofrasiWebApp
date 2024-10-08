using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TashanSofrasiWebApp.DTOs.ProductDTOs;

namespace TashanSofrasiWebApp.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7053/api/Product/ListProductWithCategory");
			if (responseMessage.IsSuccessStatusCode) 
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
				return View(values);
			}
			return View();
		}

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createProductDTO);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7053/api/Product", stringContent);
			if(responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}


    }
}
