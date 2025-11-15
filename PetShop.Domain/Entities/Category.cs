using PetShop.Domain.Core;

namespace PetShop.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}