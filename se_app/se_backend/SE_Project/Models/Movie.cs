using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SE_Project.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key][Required]
        [StringLength(4)]
        public string MovieID { get; set; }

        [Required, MaxLength(100)]
        public string MovieName { get; set;}

        [Required, MaxLength(100)]
        public string Genre { get; set;}

        [Required]
        public DateTime MovieTime { get; set; }

        [Required]
        public int MovieDuration { get; set; }
    }
}
