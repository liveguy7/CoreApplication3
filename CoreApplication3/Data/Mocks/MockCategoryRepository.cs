using CoreApplication3.Data.Interfaces;
using CoreApplication3.Data.Models;

namespace CoreApplication3.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
       public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category {CategoryName = "Sport", Description="All Sport Cars"},
                    new Category {CategoryName = "Super Sport", Description="All Super Sport Cars"}
                };
            }
        }


    }
}
