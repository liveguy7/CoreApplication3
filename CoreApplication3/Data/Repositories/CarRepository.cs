using CoreApplication3.Data.Interfaces;
using CoreApplication3.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CoreApplication3.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public IEnumerable<Car> Cars => _appDbContext.carTarget.Include(c => c.Category);
        public IEnumerable<Car> SpecialCars => _appDbContext.carTarget.Where(p =>
                        p.IsPreferredVehicle).Include(c => c.Category);
        public Car GetCarById(int carId) =>
            _appDbContext.carTarget.FirstOrDefault(p => p.CarId == carId);


    }
}




















