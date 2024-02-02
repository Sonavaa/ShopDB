

namespace ShopDB.Models
{
    internal class Categories
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsDeleted { get; set; } 
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
    }
}
