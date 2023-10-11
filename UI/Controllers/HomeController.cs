using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Client;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientEmployee _client;
        public HomeController(ILogger<HomeController> logger,IClientEmployee client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var x = await _client.GetAll();
            return View(x);
        }
        public async Task<IActionResult> AddEdit(int Id)
        { 
            if(Id == 0)
            {
                var x = new Employee();
                return View(x);
            }
            else
            {
                var x = await _client.GetById(Id);
                return View(x);
            }
        }
        public async Task<IActionResult> Save(Employee emp)
        {
           var result = await _client.AddEdit(emp);
           return RedirectToAction("Index");
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