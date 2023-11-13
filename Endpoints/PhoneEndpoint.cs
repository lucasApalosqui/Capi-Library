using CapiLibrary.Models;
using CapiLibrary.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Endpoints
{
    public static class PhoneEndpoint
    {
        public static void Create(string phone, int userId)
        {
            try
            {
                Repository<PhoneTable> repo = new Repository<PhoneTable>();
                PhoneTable phoneTable = new PhoneTable { Phone = phone, UserId = userId };
                repo.Create(phoneTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar um telefone: {ex.Message}");
            }
        }

        public static PhoneTable GetByUserEmail(string email)
        {
            try
            {
                var user = UserEndpoint.GetByEmail(email);
                PhoneTable phone = Database.Connection.QueryFirst<PhoneTable>("SELECT * FROM [Phone_Table] WHERE UserId = @UserId", new { UserId = user.Id });
                return phone;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Telefone não encontrado: {ex.Message}");
                return null;
            }
        }
    }
}
