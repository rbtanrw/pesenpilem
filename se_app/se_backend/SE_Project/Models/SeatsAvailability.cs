using Microsoft.Identity.Client;

namespace SE_Project.Models
{
    public class SeatsAvailability
    {
        public string TheaterID { get; set; }
        public int Capacity { get; set; }
        public List<List<int>> Seats {  get; set; }
        public Movie Movie { get; set; }
    }
}
