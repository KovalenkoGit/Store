﻿using Store.Models;
using Store.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Store.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext _context = null;
        public ProductRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddNewProduct(ProductModel product)
        {
            var newBook = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                DateAdded = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                CoverImageUrl = product.CoverImageUrl
            };

            newBook.ProductImages = new List<ProductImage>();
            // Додаємо фото до книги
            foreach (var image in product.Gallery)
            {
                newBook.ProductImages.Add(new ProductImage()
                {
                    Name = image.Name,
                    ImageURL = image.ImageURL
                });
            }

            await _context.Product.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.ProductId;
        }

        public async Task<List<ProductModel>> GetAllProduct()
        {
            return await _context.Product
                  .Select(product => new ProductModel()
                  {
                      ProductId = product.ProductId,
                      Name = product.Name,
                      Description = product.Description,
                      Price = product.Price,
                      CategoryId = product.CategoryId,
                      Category = product.Category.Name,
                      DateAdded = product.DateAdded,
                      DateUpdated = product.DateUpdated,
                      CoverImageUrl = product.CoverImageUrl
                  }).ToListAsync();
        }

        public async Task<List<ProductModel>> GetTopProduct(int count)
        {
            return await _context.Product
                  .Select(product => new ProductModel()
                  {
                      ProductId = product.ProductId,
                      Name = product.Name,
                      Description = product.Description,
                      Price = product.Price,
                      CategoryId = product.CategoryId,
                      Category = product.Category.Name,
                      DateAdded = product.DateAdded,
                      DateUpdated = product.DateUpdated,
                      CoverImageUrl = product.CoverImageUrl
                  }).OrderBy(x => Guid.NewGuid()).Take(count).ToListAsync() ?? new List<ProductModel>();
        }
        public async Task<ProductModel> GetProductById(Guid id)
        {
            return await _context.Product.Where(x => x.ProductId == id)
                .Select(product => new ProductModel()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    Category = product.Category != null ? product.Category.Name : "Без категорії",
                    DateAdded = product.DateAdded,
                    DateUpdated = product.DateUpdated,
                    CoverImageUrl = product.CoverImageUrl,
                    Gallery = product.ProductImages != null ? product.ProductImages.Select(g => new GalleryModel()
                    {
                        ImageId = g.ImageId,
                        Name = g.Name,
                        ImageURL = g.ImageURL
                    }).ToList() : new List<GalleryModel>(),
                }).FirstOrDefaultAsync();
        }
        public List<ProductModel> SearchProduct(string name)
        {
            return null;
        }
    }
}
