using CoreApplication3.Data.Models;

namespace CoreApplication3.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

    }
}






