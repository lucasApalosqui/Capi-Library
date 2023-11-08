using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Repositories
{
    public class Repository<T> where T : class
    {
        //Get Methods
        public IEnumerable<T> GetAll()
        {
            try
            {
                var gets = Database.Connection.GetAll<T>();
                if (gets != null)
                {
                    return gets;
                }
                else
                {
                    return Enumerable.Empty<T>();
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public T GetById(int id)
        {
            try
            {
                var get = Database.Connection.Get<T>(id);
                if (get != null)
                {
                    return get;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Create
        public void Create(T model)
        {
            try
            {
                Database.Connection.Insert<T>(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir dados: {ex.Message}");
            }

        }

        // Update
        public void Update(T model)
        {
            try
            {
                Database.Connection.Update<T>(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar dados: {ex.Message}");
            }
        }

        // Delete
        public void Delete(int id)
        {
            try
            {
                T model = GetById(id);
                Database.Connection.Delete<T>(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar dados: {ex.Message}");
            }
        }




    }
}