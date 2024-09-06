using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApiDbContext _context = null;

        public CategoryRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryModels>> GetCategory()
        {
            return await _context.Category.Select(x => new CategoryModels()
            {
                CategoryId = x.CategoryId,
                Description = x.Description,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
