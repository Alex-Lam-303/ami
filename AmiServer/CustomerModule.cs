using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AmiServer.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Nancy;
using Nancy.ModelBinding;

//using System.Net;

namespace AmiServer
{
    public class CustomerModule : NancyModule
    {
        public CustomerModule()
        {
            Post["/Customer/Register"] = arg =>
            {
                var customer = this.Bind<CustomerModel>();
                return Register(customer) ? HttpStatusCode.OK : HttpStatusCode.Forbidden;
            };


            Post["/Customer/Login"] = arg =>
            {
                var customer = this.Bind<CustomerModel>();
                return Login(customer) ? HttpStatusCode.OK : HttpStatusCode.Forbidden;
            };
        }

        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        private static bool Register(CustomerModel customer)
        {
            using (var connection = Database.GetConnection())
            {
                const string sql = "Select * From Device where RegistrationCode = @code and RegistrationStatus = 0";
                var query = connection.Query<DeviceModel>(sql, new {code = customer.RegistrationCode});
                if (!query.Any()) return false;
                using (var transaction = connection.BeginTransaction())
                {
                    var device = query.FirstOrDefault();
                    device.RegistrationStatus = true;
                    connection.Update(device, transaction);
                    connection.Insert(customer, transaction);
                    transaction.Commit();
                    return true;
                }
            }
        }

        private static bool Login(CustomerModel customer)
        {
            using (var connection = Database.GetConnection())
            {
                const string sql = "Select Email From Customer where Email = @email and Password = @password";
                if (connection.Query(sql, new {email = customer.Email, password = customer.Password}).Any())
                    return true;
            }
            return false;
        }
    }
}