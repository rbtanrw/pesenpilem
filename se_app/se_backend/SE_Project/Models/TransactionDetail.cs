using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE_Project.Models
{
    [Table("TransactionDetail")]
    public class TransactionDetail
    {
        [Key][Required]
        [StringLength(4)]
        public string TransactionID { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required][ForeignKey("Customer")]
        public string CustomerID { get; set; }

        [Required][ForeignKey("Seat")]
        public string SeatID { get; set; }
    }
}
