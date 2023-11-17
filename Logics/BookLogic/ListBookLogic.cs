using CapiLibrary.Endpoints;
using CapiLibrary.Screens.BookScreens;
using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Logics.BookLogic
{
    public static class ListBookLogic
    {
        public static void ListAllBooks()
        {
            Console.Clear();
            Console.WriteLine("Todos os livros");
            MenuWrite.Dotted();
            var books = BookEndpoint.GetAllBooks();
            foreach (var book in books)
            {
                MenuWrite.ColorP("Id "); Console.Write(book.Id);
                MenuWrite.ColorP(" Título "); Console.Write(book.Title);
                MenuWrite.ColorP(" Páginas "); Console.Write(book.Pages);
                MenuWrite.ColorP(" Classificação "); Console.Write(book.GeneralAud);
                MenuWrite.ColorP(" Categoria ");


                var categories = CategoryEndpoint.GetCategoriesByBookId(book.Id);
                int nume = 0;
                foreach (var category in categories)
                {
                    Console.Write($"{category.Name}");
                    Console.Write(" | ");
                    nume++;
                }
                if (nume == 0)
                {
                    Console.Write(" Nenhum");
                }
                MenuWrite.ColorP(" Autores ");
                var writers = WriterEndpoint.GetWritersByBookId(book.Id);
                nume = 0;
                foreach (var writer in writers)
                {
                    Console.Write($"{writer.Name}");
                    Console.Write(" | ");
                    nume++;
                }
                if (nume == 0)
                {
                    Console.Write(" Nenhum");
                }

                Console.WriteLine();
            }
            Console.ReadKey();
            ListBookScreen.Load();
        }
    }
}
