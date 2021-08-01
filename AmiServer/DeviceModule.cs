using System;
using AmiServer.Models;
using Dapper.Contrib.Extensions;
using Nancy;

namespace AmiServer
{
    public class DeviceModule : NancyModule
    {
        public DeviceModule()
        {
            Get["/Device/{key}/Generate"] = arg =>
            {
                if (arg["key"] != "SuperSecureKeyLol") return HttpStatusCode.Forbidden;
                var code = Guid.NewGuid().ToString().Substring(0, 5);
                AddDevice(code);
                return code;
            };
        }

        private static void AddDevice(string code)
        {
            using (var connection = Database.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    var device = new DeviceModel
                    {
                        RegistrationCode = code,
                        RegistrationStatus = false
                    };
                    connection.Insert(device, transaction);
                    transaction.Commit();
                }
            }
        }
    }
}