using CapiLibrary.Models;
using CapiLibrary.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

        public static UserTable GetById(int id)
        {
            try
            {
                Repository<UserTable> repository = new Repository<UserTable>();
                return repository.GetById(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IEnumerable<UserTable> GetAllUsers()
        {
            try
            {
                var repository = new Repository<UserTable>();
                return repository.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possivel listar os Usuários erro: {e.Message}");
                return null;
            }
        }

        public static UserTable GetByEmail(string email)
        {
            try
            {
                UserTable user = Database.Connection.QueryFirst<UserTable>("SELECT * FROM [User_Table] WHERE Email = @Email", new { Email = email });
                if (user == null)
                {
                    Console.WriteLine("Usuário não encontrado");
                    return null;
                }
                else
                {
                    return user;
                }


            }
            catch (Exception ex)
            {

                return null;

            }
        }

        public static void DeleteUser(UserTable user)
        {
            try
            {

                var address = AddressEndpoint.GetByUserEmail(user.Email);
                var phone = PhoneEndpoint.GetByUserEmail(user.Email);

                if (address != null)
                {
                    AddressEndpoint.DeleteAddress(address);
                }
                if (phone != null)
                {
                    PhoneEndpoint.DeletePhone(phone);
                }
                Repository<UserTable> repo = new Repository<UserTable>();
                repo.Delete(user.Id);


            }
            catch (Exception ex)
            {
                
            }
        }



    }
}