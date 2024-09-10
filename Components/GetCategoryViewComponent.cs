using Microsoft.AspNetCore.Mvc;
using Store.Repository;
using System.Threading.Tasks;

namespace Store.Components
{
    public class GetCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryViewComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryRepository.GetCategory();
            return View(categories);
        }
    }
}
