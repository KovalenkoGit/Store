using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Store.Data;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class ProductModel
    {
        [Key]
        public Guid ProductId { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Введіть назву")]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
        public Guid? CategoryId { get; set; }
        [ValidateNever]
        public string Category { get; set; }
        [Required]
        public IFormFile CoverPhoto { get; set; }
        [ValidateNever]
        public string CoverImageUrl { get; set; }
        [Display(Name = "Виберіть галерею зображень для товару")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }
        [ValidateNever]
        public List<GalleryModel> Gallery { get; set; }
    }
}
