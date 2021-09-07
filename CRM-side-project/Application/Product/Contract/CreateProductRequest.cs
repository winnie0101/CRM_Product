using System.ComponentModel.DataAnnotations;

namespace CRM_side_project.Application.Product.Contract
{
    public class CreateProductRequest
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public long TypeId { get; set; }
        public decimal Price { get; set; }
        [Range(1,99)]
        public int? Discount { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// 1:啟用 0:停用
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}
