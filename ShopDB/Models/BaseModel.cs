

namespace ShopDB.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
    }
}
