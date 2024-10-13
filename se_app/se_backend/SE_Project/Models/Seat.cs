using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE_Project.Models
{
    [Table("Seat")]
    public class Seat
    {
        [Key][Required]
        [StringLength(3)]
        public string SeatID { get; set; }

        [Required][ForeignKey("Theater")]
        public string TheaterID { get; set; }

        [Required][ForeignKey("Customer")]
        public string CustomerID { get; set; } = "";
    }
}
