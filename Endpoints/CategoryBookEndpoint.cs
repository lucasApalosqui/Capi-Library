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
    public static class CategoryBookEndpoint
    {
        public static void Create(BookTable book, CategoryTable category)
        {
            try
            {
                Repository<BookCategoryTable> repository = new Repository<BookCategoryTable>();
                BookCategoryTable bookCate = new BookCategoryTable { IdBook = book.Id, IdCategory = category.Id };
                repository.Create(bookCate);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DeleteByBookId(int id)
        {
            try
            {
                Repository<BookCategoryTable> writerRepo = new Repository<BookCategoryTable>();
                BookCategoryTable bookC = Database.Connection.QueryFirst<BookCategoryTable>("SELECT * FROM [BookCategory_Table] WHERE IdBook = @IdBook", new { IdBook = id });
                if (bookC != null)
                {
                    Database.Connection.Execute("DELETE [BookCategory_Table] WHERE IdBook = @IdBook", new { IdBook = bookC.IdBook });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public static void DeleteByCategoryAndBookId(int Cid, int Bid)
        {
            try
            {
                Repository<BookCategoryTable> writerRepo = new Repository<BookCategoryTable>();
                BookCategoryTable bookC = Database.Connection.QueryFirst<BookCategoryTable>("SELECT * FROM [BookCategory_Table] WHERE IdBook = @IdBook AND IdCategory = @IdCategory", new { IdBook = Bid, IdCategory = Cid });
                if (bookC != null)
                {
                    Database.Connection.Execute("DELETE [BookCategory_Table] WHERE IdBook = @IdBook AND IdCategory = @IdCategory", new { IdBook = bookC.IdBook, IdCategory = bookC.IdCategory });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

    }
}
