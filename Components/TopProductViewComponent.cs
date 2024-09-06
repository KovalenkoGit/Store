using Microsoft.AspNetCore.Mvc;
using Store.Repository;
using System.Threading.Tasks;

namespace Store.Components
{
    public class TopProductViewComponent : ViewComponent
    {
        private readonly IProductRepository _productRepository;
        public TopProductViewComponent(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var product = await _productRepository.GetTopProduct(count);
            return View(product);
        }
    }
}
