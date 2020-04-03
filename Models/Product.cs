using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyEShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Code Cannot be empty")]
        [MaxLength(4, ErrorMessage = "Code should be of 4 character")]
        [MinLength(4, ErrorMessage = "Code should be of 4 character")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name Cannot be empty")]
        public string Name { get; set; }
        [Display(Name= "Product Type")]
        public string Type { get; set; }
        public string Image { get; set; }

        public List<Product> Products { set; get; }
    }
}
