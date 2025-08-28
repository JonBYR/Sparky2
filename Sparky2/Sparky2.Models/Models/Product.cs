using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky2.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required] //ensures this field is not null
        [DisplayName("Product Title")] //provides a user-friendly name for the field in the view
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }
        [Required]
        [Display(Name = "Price")]
        [Range(1, 1000)]
        public double Price { get; set; }
        [Required]
        [Display(Name = "50+ Price")]
        [Range(1, 1000)]
        public double FiftyPrice { get; set; }
        [Required]
        [Display(Name = "100+ Price")]
        [Range(1, 1000)]
        public double HundredPrice { get; set; }
    }
}
