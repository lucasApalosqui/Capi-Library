using CapiLibrary.Models;
using CapiLibrary.Repositories;
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
    }
}
