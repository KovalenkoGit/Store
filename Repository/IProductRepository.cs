using Store.Models;
using System;

namespace Store.Repository
{
    public interface IProductRepository
    {
        Task<Guid> AddNewProduct(ProductModel product);
        Task<List<ProductModel>> GetAllProduct();
        Task<ProductModel> GetProductById(Guid productId);
        Task<List<ProductModel>> GetProductByCategoryId(Guid categoryId);
        Task<List<ProductModel>> GetTopProduct(int count);
        List<ProductModel> SearchProduct(string name);
    }
}