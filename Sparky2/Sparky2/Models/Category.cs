using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sparky2.Models
{
    public class Category
    {
        [Key] //establishes this property as the primary key
        public int Id { get; set; }
        [Required] //ensures this field is not null
        [DisplayName("Category Name")] //provides a user-friendly name for the field in the view
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
