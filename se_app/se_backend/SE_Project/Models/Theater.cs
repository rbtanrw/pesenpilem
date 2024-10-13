using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE_Project.Models
{
    [Table("Theater")]
    public class Theater
    {
        [Key][Required]
        [StringLength(4)]
        public string TheaterID { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required][ForeignKey("Movie")]
        public string MovieID { get; set; }
    }
}
