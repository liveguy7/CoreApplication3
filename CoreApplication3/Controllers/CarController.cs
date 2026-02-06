using CoreApplication3.Data.Interfaces;
using CoreApplication3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CoreApplication3.Controllers
{
    public class CarController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICarRepository _carRepository;

        public CarController(ICategoryRepository categoryRepository, ICarRepository carRepository)
        {
            _carRepository = carRepository;
            _categoryRepository = categoryRepository;

        }

        public ViewResult List()
        {
            CarListViewModel cm = new CarListViewModel();
            cm.Cars = _carRepository.Cars;
            cm.CurrentCategory = "Category Name";

            return View(cm);
            
        }

    }
}





