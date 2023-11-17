using CapiLibrary.Endpoints;
using CapiLibrary.Models;
using CapiLibrary.Screens.BookScreens;
using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

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
            ListBooks(books);

            Console.ReadKey();
            ListBookScreen.Load();
        }

        public static void ListPerGeneralAud()
        {
            Console.Clear();
            Console.WriteLine("Livros por Classificação Indicativa");
            MenuWrite.Dotted();
            var generalAud = "";
            Console.WriteLine("Qual classificação deseja pesquisar");
            MenuWrite.OptionGen(new List<string> { "L", "10+", "12+", "14+", "16+", "18+" });
            Console.WriteLine();

            var option = short.Parse(Console.ReadLine()!);
            switch (option)
            {
                case 1:
                    generalAud = "L";
                    break;
                case 2:
                    generalAud = "10+";
                    break;
                case 3:
                    generalAud = "12+";
                    break;
                case 4:
                    generalAud = "14+";
                    break;
                case 5:
                    generalAud = "16+";
                    break;
                case 6:
                    generalAud = "18+";
                    break;
                default:
                    Console.WriteLine("Opção inválida tente novamente");
                    Console.ReadKey();
                    ListBookScreen.Load();
                    break;
            }
            var books = BookEndpoint.GetByGeneralAud(generalAud);
            if (books.Count<BookTable>() == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado");
            }
            ListBooks(books);
            Console.ReadKey();
            ListBookScreen.Load();

        }

        public static void ListBooks(IEnumerable<BookTable> books)
        {
            var numer = 0;
            foreach (var book in books)
            {
                numer++;
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
        }
    }
}
