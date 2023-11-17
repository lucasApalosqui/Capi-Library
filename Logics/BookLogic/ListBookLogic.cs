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

        public static void ListBooks(BookTable book)
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

        public static void ListByWriter()
        {
            Console.Clear();
            Console.WriteLine("Livros por autor");
            MenuWrite.Dotted();
            Console.Write("Informe o nome do autor que deseja pesquisar: ");
            string name = Console.ReadLine();
            var writer = WriterEndpoint.GetWriterByName(name);
            if (writer == null)
            {
                Console.WriteLine($"Nenhum autor com o nome {name} Encontrado");
                Console.ReadKey();
                ListBookScreen.Load();
            }
            var books = BookEndpoint.GetByWriterId(writer.Id);
            if (books.Count<BookTable>() == 0)
            {
                Console.WriteLine($"Nenhum Livro com o autor {writer.Name} encontrado");
            }
            else
            {
                ListBooks(books);
            }
            Console.ReadKey();
            ListBookScreen.Load();
        }

        public static void ListByCategory()
        {
            Console.Clear();
            Console.WriteLine("Livros por Categoria");
            MenuWrite.Dotted();
            Console.Write("Informe o nome da categoria que deseja pesquisar: ");
            string name = Console.ReadLine();
            var category = CategoryEndpoint.GetCategoryByName(name);
            if (category == null)
            {
                Console.WriteLine($"Nenhuma Categoria com o nome {name} Encontrada");
                Console.ReadKey();
                ListBookScreen.Load();
            }
            var books = BookEndpoint.GetByCategoryId(category.Id);
            if (books.Count<BookTable>() == 0)
            {
                Console.WriteLine($"Nenhum Livro com a categoria {category.Name} encontrada");
            }
            else
            {
                ListBooks(books);
            }
            Console.ReadKey();
            ListBookScreen.Load();
        }

        public static void ListById()
        {
            Console.Clear();
            Console.WriteLine("Livro por Id");
            MenuWrite.Dotted();
            Console.Write("Informe o Id que deseja pesquisar: ");
            string id = Console.ReadLine();
            var book = BookEndpoint.GetById(short.Parse(id));
            if (book == null)
            {
                Console.WriteLine("Id Não Encontrado");
                Console.ReadKey();
                ListBookScreen.Load();
            }
            ListBooks(book);
            Console.ReadKey();
            ListBookScreen.Load();


        }
    }
}
