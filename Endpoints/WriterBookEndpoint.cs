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

        public static void DeleteByWriterAndBookId(int Wid, int Bid)
        {
            try
            {
                Repository<BookWriterTable> writerRepo = new Repository<BookWriterTable>();
                BookWriterTable bookW = Database.Connection.QueryFirst<BookWriterTable>("SELECT * FROM [BookWriter_Table] WHERE IdBook = @IdBook AND IdWriter = @IdWriter", new { IdBook = Bid, IdWriter = Wid });
                if (bookW != null)
                {
                    Database.Connection.Execute("DELETE [BookWriter_Table] WHERE IdBook = @IdBook AND IdWriter = @IdWriter", new { IdBook = bookW.IdBook, IdWriter = bookW.IdWriter });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static void DeleteByBookId(int id)
        {
            try
            {
                Repository<BookWriterTable> writerRepo = new Repository<BookWriterTable>();
                BookWriterTable bookW = Database.Connection.QueryFirst<BookWriterTable>("SELECT * FROM [BookWriter_Table] WHERE IdBook = @IdBook", new { IdBook = id });
                if (bookW != null)
                {
                    Database.Connection.Execute("DELETE [BookWriter_Table] WHERE IdBook = @IdBook", new { IdBook = bookW.IdBook });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
