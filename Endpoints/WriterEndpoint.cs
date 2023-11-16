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
    }
}
