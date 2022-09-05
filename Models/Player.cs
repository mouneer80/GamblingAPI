using System.ComponentModel.DataAnnotations.Schema;

namespace GamblingAPI.Models
{
    [Table("players")]
    public class Player
    {
        public int ID { get; set; }
        public int OpeningPoints { get; set; }
        public int CurrentPoints { get; set; }
    }
}
