using Store.Models;
using Store.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using Store.Data;
using Microsoft.AspNetCore.Authorization;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository = null;
        private readonly ICategoryRepository _categoryRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductRepository productRepository,
                                 ICategoryRepository categoryRepository,
                                 IWebHostEnvironment webHostEnvironment) 
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("~/all-product")]
        public async Task<ViewResult> GetAllProduct()
        {
            var data = await _productRepository.GetAllProduct();
            return View(data);
        }
        [Route("product-details/{id}", Name ="ProductDetailsRoute")]
        public async Task<ViewResult> GetProduct(Guid id)
        {
            var data = await _productRepository.GetProductById(id);
			return View(data);
		}
        [Route("~/category")]
        public async Task<ViewResult> GetProductByCategory(Guid categoryId)
        {
            var data = await _productRepository.GetProductByCategoryId(categoryId);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> SearchProduct(string nameProduct)
        {
            var products = await _productRepository.SearchProducts(nameProduct);
            return View("SearchProduct", products);
        }
        [Authorize]
        public async Task<ViewResult> AddNewProduct(bool isSuccess = false, Guid? productId = null)
        {
            var model = new ProductModel();
            ViewBag.Category = new SelectList(await _categoryRepository.GetCategory(), "CategoryId", "Name");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.ProductId = productId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                if (productModel.CoverPhoto != null)
                {
                    string folder = "product/cover/";
                    productModel.CoverImageUrl = await UploadImage(folder, productModel.CoverPhoto);
                }

                if (productModel.GalleryFiles != null)
                {
                    string folder = "product/gallery/";

                    productModel.Gallery = new List<GalleryModel>();

                    foreach (var file in productModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            ImageURL = await UploadImage(folder, file)
                        };
                        productModel.Gallery.Add(gallery);
                    }
                }

                Guid id = await _productRepository.AddNewProduct(productModel);
                if (id != null)
                {
                    return RedirectToAction(nameof(AddNewProduct), new { isSuccess = true, productId = id });
                }
            }
            return View();
        }

        private async Task<string> UploadImage (string folderPath, IFormFile file)
        { 
            folderPath += Guid.NewGuid().ToString() + "-" + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }

    }
}
