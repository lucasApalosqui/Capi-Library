using CapiLibrary.Models;
using CapiLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Endpoints
{
    public static class UserEndpoint
    {
        public static void Create(string firstName, string lastName, string email, string cpf)
        {
            try
            {
                UserTable user = new UserTable { FirstName = firstName, LastName = lastName, Email = email, Cpf = cpf };
                var repository = new Repository<UserTable>();
                repository.Create(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel Cadastrar o usuário");
            }
        }
    }
}