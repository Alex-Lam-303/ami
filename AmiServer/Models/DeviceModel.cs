using Dapper.Contrib.Extensions;

namespace AmiServer.Models
{
    [Table("Device")]
    public class DeviceModel
    {
        [Key]
        public int id { get; set; }

        public string RegistrationCode { get; set; }
        public bool RegistrationStatus { get; set; }
    }
}