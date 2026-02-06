using CoreApplication3.Data.Interfaces;
using CoreApplication3.Data.Models;

namespace CoreApplication3.Data.Repositories
{ 
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
        }

        public IEnumerable<Category> Categories => _appDbContext.categoryTarget;
        
    }
}
