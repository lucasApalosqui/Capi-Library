using CapiLibrary.Models;
using CapiLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Endpoints
{
    public static class WriterBookEndpoint
    {
        public static void Create(BookTable book, WriterTable writer)
        {
            try
            {
                Repository<BookWriterTable> repository = new Repository<BookWriterTable>();
                BookWriterTable bookWri = new BookWriterTable { IdBook = book.Id, IdWriter = writer.Id };
                repository.Create(bookWri);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
