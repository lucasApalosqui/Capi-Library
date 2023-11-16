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
    public static class CategoryEndpoint
    {
        public static CategoryTable Create(string name)
        {
            Repository<CategoryTable> repo = new Repository<CategoryTable>();
            name = name.ToLower();
            CategoryTable category = new CategoryTable { Name = name };
            var cat = GetByName(name);
            if (cat == null)
            {
                repo.Create(category);
                return category;
            }
            else
            {
                return cat;
            }
           
            
        }

        public static void GetAll()
        {
            try
            {
                Repository<CategoryTable> repo = new Repository<CategoryTable>();
                var category = repo.GetAll();
                int enu = 1;

                if (category != null)
                {
                    Console.WriteLine();
                    foreach (var item in category)
                    {
                        if (enu / 4 == 1)
                        {
                            enu = 1;
                            Console.WriteLine($"°{item.Name}");
                        }
                        else
                        {
                            Console.Write($"°{item.Name}  ");
                            enu++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nenhuma categoria cadastrada");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Nenhuma Categoria Cadastrada!");
            }
        }

        public static CategoryTable GetByName(string name)
        {
            try
            {
                name = name.ToLower();
                CategoryTable cate = Database.Connection.QueryFirst<CategoryTable>("SELECT * FROM [Category_Table] WHERE Name = @Name", new { Name = name });
                if (cate == null)
                {
                    return null;
                }
                else
                {
                    return cate;
                }
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
    }
}
