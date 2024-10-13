using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE_Project.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key][Required]
        [StringLength(4)]
        public string CustomerID { get; set; }

        [Required, MaxLength(100)]
        public string CustomerName { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string Pass { get; set; }
    }
}
