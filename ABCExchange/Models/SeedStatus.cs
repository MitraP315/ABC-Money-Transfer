using System.ComponentModel.DataAnnotations.Schema;

namespace ABCExchange.Models
{
    public class SeedStatus
    {
        public int Id { get; set; }
        public bool IsSeeded { get; set; }
        public DateTime LastSeededOn { get; set; }
    }

}
