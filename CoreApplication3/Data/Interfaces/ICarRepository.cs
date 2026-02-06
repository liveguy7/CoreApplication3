using CoreApplication3.Data.Models;

namespace CoreApplication3.Data.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> Cars { get;  }
        IEnumerable<Car> SpecialCars { get; }
        Car GetCarById(int carId);
    }
}


