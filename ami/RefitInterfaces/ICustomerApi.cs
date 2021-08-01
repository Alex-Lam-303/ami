using System.Threading.Tasks;
using ami.Model;
using Refit;

namespace ami.RefitInterfaces
{
    public interface ICustomerApi
    {
        [Post("/Register")]
        Task RegisterCustomer([Body] CustomerModel customer);

        [Post("/Login")]
        Task Login([Body] CustomerModel customer);
    }
}