

namespace CRM_side_project.Application.Product.Contract
{
    public class GetAllProductResponse
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long TypeId { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public long CreatedDateTime { get; set; }
        public string CreatedUser { get; set; }
        public byte UpdatedTimes { get; set; }
        public long UpdatedDateTime { get; set; }
        public string UpdatedUser { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] Rowversion { get; set; }
    }
}
