using Microsoft.AspNetCore.Mvc;

namespace Pearogram.Models
{
    public class SupplierVewModel
    {
        [HiddenInput]
        public int SupplierID { get; set; }
        [MaxLength(100, ErrorMessage = "please enter Valid name")]
        [MinLength(5, ErrorMessage = "Please enter Valid name")]
        [Required]
        public string SupplierName { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
