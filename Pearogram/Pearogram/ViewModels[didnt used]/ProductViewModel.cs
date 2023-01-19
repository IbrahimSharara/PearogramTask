using Microsoft.AspNetCore.Mvc;
namespace Pearogram.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Suppliers = new List<Supplier>();
        }
        [HiddenInput]
        public int productId { get; set; }
        [MaxLength(100 ,ErrorMessage ="please enter Valid name")]
        [MinLength(5 , ErrorMessage = "Please enter Valid name")]
        [Required (ErrorMessage ="Product Name is Required")]
        [Display(Name ="Product Name")]
        public string productName { get; set; }
        [Range(1 , 20 , ErrorMessage ="Please enter Valid data")]
        [Display(Name = "Quentity Per Unit")]
        public double? QuentityPerUnit { get; set; }
        [MinLength(1)]
        [Display(Name = "Reorder Level")]
        public int? ReorderLevel { get; set; }
        [Required]
        [Display(Name = "Supplier")]
        public int? SupplierID { get; set; }
        [MinLength(1)]
        [Display(Name = "unit In Stock")]
        public double? unitInStock { get; set; }
        [MinLength(1)]
        [Display(Name = "Units In Order")]
        public double? UnitsInOrder { get; set; }
        public virtual List<Supplier> Suppliers { get; set; }
    }
}
