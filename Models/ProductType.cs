﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShope.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Type")]
        public string? ProductTypes { get; set; }
    }
}
