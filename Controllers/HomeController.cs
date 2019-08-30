using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealerCapstone.Models;
using System.Net.Http;
using CarDealerCapstone.Context;

namespace CarDealerCapstone.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient _client { get; set; }
        public HomeController()
        {
            HttpClient clien = new HttpClient();
            clien.BaseAddress = new Uri("https://localhost:44322/api/Car");
            
            _client = clien;
        }
        public async Task<IActionResult> Index()
        {
            var response =  _client.GetAsync("").Result;
            var result = await response.Content.ReadAsAsync<CarModel[]>();
            return View(result);
        }
        public async Task<IActionResult> Details(int id)
        {
            var response = _client.GetAsync($"{id}").Result;
            var result = await response.Content.ReadAsAsync<CarModel>();
            return View(result);
        }
        public async Task<IActionResult> Search(string Make,string Model, string Color, int Year)
        {
            var searchParams = new CarModel() { Model = Model, Color = Color, Year = Year, Make = Make };
            var response = _client.GetAsync("").Result;
            var listFull = await response.Content.ReadAsAsync<List<CarModel>>();
            var ListSearch = new List<CarModel>();
            foreach (var item in listFull)
            {
                if((searchParams.Make == item.Make || searchParams.Make == "All")
                  &&  (searchParams.Model == item.Model || searchParams.Model == "All")
                   && (searchParams.Color == item.Color || searchParams.Color == "All")
                   && (searchParams.Year == item.Year || searchParams.Year == 0000))
                {
                    ListSearch.Add(item);
                }
            }
            
            return View(ListSearch);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
