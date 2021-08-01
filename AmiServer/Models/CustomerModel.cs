using Dapper.Contrib.Extensions;

namespace AmiServer.Models
{
    [Table("Customer")]
    public class CustomerModel
    {
        [Key]
        public int id { get; set; }

        public string Email { get; set; }
        public string BabyName { get; set; }
        public int BabyGender { get; set; }
        public string Password { get; set; }
        public string RegistrationCode { get; set; }
    }
}