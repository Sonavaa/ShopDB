

namespace ShopDB.Models
{
    internal class Products
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
    }
}
