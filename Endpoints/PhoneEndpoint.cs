using CapiLibrary.Models;
using CapiLibrary.Repositories;
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
                PhoneTable phoneTable = new PhoneTable{ Phone = phone, UserId = userId };
                repo.Create(phoneTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar um telefone: {ex.Message}");
            }
        }
    }
}
