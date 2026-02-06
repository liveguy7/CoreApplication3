using CoreApplication3.Data.Interfaces;
using CoreApplication3.Data.Models;

namespace CoreApplication3.Data.Mocks
{
    public class MockCarRepository : ICarRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        Name = "Sports Car 1",
                        Price = 45932,
                        LongDescription = "Fast Car",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "true",
                        IsInStock = true,
                        IsPreferredVehicle = true,
                        ImageThumbNail = "true"
                    },
                     new Car
                    {
                        Name = "Sports Car 2",
                        Price = 49139,
                        LongDescription = "Fast Car",
                        Category = _categoryRepository.Categories.First(),
                        ImageUrl = "true",
                        IsInStock = true,
                        IsPreferredVehicle = true,
                        ImageThumbNail = "true"
                    },


                };
            }
        }

    }
}
