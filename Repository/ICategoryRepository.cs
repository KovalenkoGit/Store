using Store.Models;

namespace Store.Repository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModels>> GetCategory();
    }
}