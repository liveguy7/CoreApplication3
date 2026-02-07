using CoreApplication3.Data.Interfaces;
using CoreApplication3.Data.Models;

namespace CoreApplication3.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;
        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;

        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _appDbContext.orderTarget.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach(var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    CarId = item.Car.CarId,
                    OrderId = order.OrderId,
                    Price = item.Car.Price
                };
                _appDbContext.orderDetailTarget.Add(orderDetail);
            }
            _appDbContext.SaveChanges();
        }

    }
}
























