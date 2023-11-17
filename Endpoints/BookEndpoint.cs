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
    public static class BookEndpoint
    {
        public static BookTable Create(string Title, string Synopsis, int pages, string generalAud)
        {
            try
            {
                Repository<BookTable> repository = new Repository<BookTable>();
                BookTable bookTable = new BookTable();
                bookTable.Title = Title;
                bookTable.Synopsis = Synopsis;
                bookTable.Pages = pages;
                bookTable.GeneralAud = generalAud;

                repository.Create(bookTable);
                return bookTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possivel cadastrar o Livro: {ex.Message}");
                return null;
            }
        }

        public static BookTable GetById(int id)
        {
            try
            {
                Repository<BookTable> repo = new Repository<BookTable>();
                return repo.GetById(id);
            }
            catch
            {
                return null;
            }
        }

        public static void Delete(BookTable book)
        {
            try
            {
                Repository<BookTable> bookRepo = new Repository<BookTable>();
                WriterBookEndpoint.DeleteByBookId(book.Id);
                CategoryBookEndpoint.DeleteByBookId(book.Id);
                bookRepo.Delete(book.Id);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static IEnumerable<BookTable> GetAllBooks()
        {
            try
            {
                Repository<BookTable> repoB = new Repository<BookTable>();
                return repoB.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static IEnumerable<BookTable> GetByGeneralAud(string generalAud)
        {
            try
            {
                var query = @"SELECT * FROM [Book_Table]
                              WHERE [Book_Table].GeneralAud = @GeneralAud";
                var books = Database.Connection.Query<BookTable>(query, new { GeneralAud = generalAud });
                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static IEnumerable<BookTable> GetByWriterId(int id)
        {
            try
            {
                var query = @"SELECT [Book_Table].*
                              FROM (([BookWriter_Table]
                              INNER JOIN [Writer_Table] ON [BookWriter_Table].IdWriter = [Writer_Table].Id)
                              INNER JOIN [Book_Table] ON [BookWriter_Table].IdBook = [Book_Table].Id)
                              WHERE [BookWriter_Table].IdWriter = @IdWriter";
                var books = Database.Connection.Query<BookTable>(query, new { IdWriter = id });

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static IEnumerable<BookTable> GetByCategoryId(int id)
        {
            try
            {
                var query = @"SELECT [Book_Table].*
                              FROM (([BookCategory_Table]
                              INNER JOIN [Category_Table] ON [BookCategory_Table].IdCategory = [Category_Table].Id)
                              INNER JOIN [Book_Table] ON [BookCategory_Table].IdBook = [Book_Table].Id)
                              WHERE [BookCategory_Table].IdCategory = @IdCategory";
                var books = Database.Connection.Query<BookTable>(query, new { IdCategory = id });

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
