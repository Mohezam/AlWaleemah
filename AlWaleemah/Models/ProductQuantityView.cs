namespace AlWaleemah.Models
{
    public class ProductQuantityView
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public IFormFile? ImageFile { get; set; }

        public string? ImageUrl { get; set; }
    }
}
