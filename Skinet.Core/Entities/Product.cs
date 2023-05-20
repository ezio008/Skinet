using System.ComponentModel.DataAnnotations;

namespace Skinet.Core.Entities
{
    public class Product : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(150)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}
