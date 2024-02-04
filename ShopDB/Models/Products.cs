

namespace ShopDB.Models
{
    public class Products:BaseModel
    {
        public string? Name { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Categories? Category { get; set; }
    }
}
