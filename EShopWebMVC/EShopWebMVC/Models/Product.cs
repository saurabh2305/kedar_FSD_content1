using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EShopWebMVC.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage ="name can not be empty")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage ="price can not be empty")]
        public double Price { get; set; }

        [Required(ErrorMessage = "quantity can not be empty")]
        [Range(1,Int32.MaxValue,ErrorMessage ="Invalid quantity value")]
        public int Quantity { get; set; }

        [Required(ErrorMessage ="Brand name is required")]
        public string Brand { get; set; }

        [DataType(DataType.Date)]
        public DateTime ManufacturingDate { get; set; }

        [Display(Name="Category")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }

}
