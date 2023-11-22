using CapiLibrary.Models;
using CapiLibrary.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Endpoints
{
    public static class BookUserEndpoint
    {
        public static void Create(int idBook, int idUser, DateTime getDate, DateTime returnDate)
        {
            try
            {
                Repository<UserBookTable> repository = new Repository<UserBookTable>();
                UserBookTable hire = new UserBookTable { IdBook = idBook, IdUser = idUser, GetDate = getDate, ReturnDate = returnDate };
                repository.Create(hire);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Operação inválida");
            }
        }

        public static UserBookTable GetByIdUser(int idUser)
        {
            try
            {
                var query = @"SELECT * FROM [UserBook_Table]
                              WHERE IdUser = @IdUser";
                var hire = Database.Connection.QueryFirst<UserBookTable>(query, new { IdUser = idUser});
                if (hire == null)
                {
                    return null;
                }
                return hire;
            }
            catch
            {
                
                return null;
            }
        }
    }
}
