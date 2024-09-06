using Store.Models;
using System;

namespace Store.Repository
{
    public interface IProductRepository
    {
        Task<Guid> AddNewProduct(ProductModel product);
        Task<List<ProductModel>> GetAllProduct();
        Task<ProductModel> GetProductById(Guid id);
        Task<List<ProductModel>> GetTopProduct(int count);
        List<ProductModel> SearchProduct(string name);
    }
}