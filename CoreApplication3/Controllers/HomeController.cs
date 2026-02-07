using System.Diagnostics;
using CoreApplication3.Data.Interfaces;
using CoreApplication3.Data.Models;
using CoreApplication3.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository _carRepository;

        public HomeController(ILogger<HomeController> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult SpecialCars()
        {
            var homeViewModel = new HomeViewModel
            {
                SpecialCars = _carRepository.SpecialCars

            };

            return View(homeViewModel);
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










