using CoreApplication3.Data.Interfaces;
using CoreApplication3.Data.Models;
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

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                cars = _carRepository.Cars.OrderBy(n => n.CarId);
                currentCategory = "All Cars";
            }
            else
            {
                if(string.Equals("Sport",_category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _carRepository.Cars.Where(p =>
                     p.Category.CategoryName.Equals("Sport")).OrderBy(n => n.Name);
                }
                else
                {
                    cars = _carRepository.Cars.Where(p =>
                         p.Category.CategoryName.Equals("Super Sport")).OrderBy(n => n.Name);
                    currentCategory = _category;
                }
         
            }

            var carListViewModel = new CarListViewModel
            {
                Cars = cars,
                CurrentCategory = currentCategory
            };

            return View(carListViewModel);

        }

    }
}





