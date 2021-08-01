using Dapper.Contrib.Extensions;

namespace AmiServer.Models
{
    [Table("CommandRecommendation")]
    public class CommandRecommendationModel
    {
        [Key]
        public int id { get; set; }

        public string Command { get; set; }
    }
}