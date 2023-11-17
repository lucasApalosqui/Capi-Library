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
    public static class WriterEndpoint
    {
        public static WriterTable Create(string name)
        {
            Repository<WriterTable> repo = new Repository<WriterTable>();
            name = name.ToLower();
            WriterTable writer = new WriterTable { Name = name };
            var wrt = GetByName(name);
            if (wrt == null)
            {
                repo.Create(writer);
                return writer;
            }
            else
            {
                return wrt;
            }

        }

        public static WriterTable GetByName(string name)
        {
            try
            {
                name = name.ToLower();
                WriterTable wrt = Database.Connection.QueryFirst<WriterTable>("SELECT * FROM [Writer_Table] WHERE Name = @Name", new { Name = name });
                if (wrt == null)
                {
                    return null;
                }
                else
                {
                    return wrt;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static IEnumerable<WriterTable> GetWritersByBookId(int id)
        {
            try
            {
                var query = @"SELECT [Writer_Table].Name, [Writer_Table].Id
                              FROM (([BookWriter_Table]
                              INNER JOIN [Writer_Table] ON [BookWriter_Table].IdWriter = [Writer_Table].Id)
                              INNER JOIN [Book_Table] ON [BookWriter_Table].IdWriter = [Book_Table].Id)
                              WHERE [BookWriter_Table].IdBook = @IdBook";
                var writers = Database.Connection.Query<WriterTable>(query, new { IdBook = id });

                return writers;

            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public static WriterTable GetWriterByName(string name)
        {
            try
            {
                var Query = @"SELECT * FROM [Writer_Table] 
                              WHERE [Writer_Table].Name = @Name";
                name = name.ToLower();
                var writer = Database.Connection.QueryFirst<WriterTable>(Query, new { Name = name});

                return writer;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
    }
}
