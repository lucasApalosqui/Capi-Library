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
    }
}
