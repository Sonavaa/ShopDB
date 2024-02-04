

namespace ShopDB.Models
{
    public class Categories:BaseModel
    {
        public string? Name { get; set; }
        public List<Products>? Products { get; set; }
    }
}
