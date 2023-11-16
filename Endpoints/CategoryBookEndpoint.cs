using CapiLibrary.Models;
using CapiLibrary.Repositories;
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
    }
}
