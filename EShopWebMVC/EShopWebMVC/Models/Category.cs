using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EShopWebMVC.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int Id { get; set; }

        [Required(ErrorMessage ="Category name must not be empty")]
        //[MinLength(5,"Minimum length should be 5",string)]   
         public string Name { get; set; }
         public string Description { get; set; }
    }
}
