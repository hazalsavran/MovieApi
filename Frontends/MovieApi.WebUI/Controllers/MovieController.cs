using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MovieApi.Dto.Dtos.MovieDtos;

namespace MovieApi.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> MovieList()
        {
            ViewBag.v1 = "Film Listesi";
            ViewBag.v2 = "Ana Sayfa";
            ViewBag.v3 = "Tüm Filmler";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7016/api/Movie");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> MovieDetail(int id)
        {
            ViewBag.pageType = "MovieDetail";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7016/api/Movie/GetMovie?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultMovieDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
