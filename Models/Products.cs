using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShope.Models
{
    public class Products
    {
        internal object ProductType;

        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Price { get; set; }
        [Display(Name = "Image")]
        public string? Img { get; set; }

        [Display(Name="Color")]
        public string? ProductColor { get; set; }
        [Required]
        public bool Available { get; set; }


        //Reation ProductTypes Table

        [Required]
        [Display(Name ="Product Type")]
        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductType? productType { get; set; }


        //Relation SpacialTag Table

        [Required]
        [Display(Name ="Conditon")]
        public int SpacialTagId { get; set; }
        [ForeignKey("SpacialTagId")]
        public SpacialTag? SpacialTag { get; set; }
       
    }
}
