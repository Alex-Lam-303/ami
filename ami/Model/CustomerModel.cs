using System.Threading.Tasks;
using ami.RefitInterfaces;
using Realms;

namespace ami.Model
{
    public class CustomerModel : RealmObject
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string BabyName { get; set; }
        public string RegistrationCode { get; set; }

        public static async Task<CustomerModel> Login(string email, string password)
        {
            var customerApi = SettingsModel.GetRestInterface<ICustomerApi>("Customer");
            var customer = new CustomerModel
            {
                Email = email,
                Password = password
            };
            await customerApi.Login(customer);
            return customer;
        }

        public async Task Register()
        {
            var customerAPI = SettingsModel.GetRestInterface<ICustomerApi>("Customer");
            await customerAPI.RegisterCustomer(this);
        }
    }
}