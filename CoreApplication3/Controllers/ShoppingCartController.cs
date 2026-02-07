using CoreApplication3.Data.Interfaces;
using CoreApplication3.Data.Models;
using CoreApplication3.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreApplication3.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(ICarRepository carRepository, ShoppingCart shoppingCart)
        {
            _carRepository = carRepository;
            _shoppingCart = shoppingCart;

        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(sCVM);
            
        }

        public RedirectToActionResult AddToShoppingCart(int carId)
        {
            var selectedCar = _carRepository.Cars.FirstOrDefault(p =>
                          p.CarId == carId);
            if(selectedCar  != null)
            {
                _shoppingCart.AddToCart(selectedCar, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int carId)
        {
            var selectedCar = _carRepository.Cars.FirstOrDefault(p =>
                   p.CarId == carId);
            if(selectedCar != null)
            {
                _shoppingCart.RemoveFromCart(selectedCar);
            }

            return RedirectToAction("Index");

        }
    }
}











































