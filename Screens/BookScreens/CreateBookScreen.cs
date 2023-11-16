using CapiLibrary.Endpoints;
using CapiLibrary.Models;
using CapiLibrary.Utilities;
using CapiLibrary.Utilities.InsertsVerify;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens.BookScreens
{
    public static class CreateBookScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Adicionar Livro");
            MenuWrite.Dotted();
            string title = "", synopsis = "", pagesS = "", generalAud = "", writerName = "";
            int pages = 0;

            title = BookDataVerify.Title(title);
            synopsis = BookDataVerify.Synopsis(synopsis);
            pages = BookDataVerify.Pages(pagesS);
            generalAud = BookDataVerify.GeneralAud(generalAud);
            while (generalAud.IsNullOrEmpty())
            {
                generalAud = BookDataVerify.GeneralAud(generalAud);
            }
            var book = BookEndpoint.Create(title, synopsis, pages, generalAud);
            AddCategory(book);

            bool veri = false;
            while (veri == false)
            {
                Console.WriteLine("Deseja cadastrar mais uma categoria?");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        AddCategory(book);
                        veri = false;
                        break;
                    case 2:
                        veri = true;
                        break;
                    default:
                        veri = false;
                        break;
                }
            }

            AddWriter(book);

            veri = false;
            while (veri == false)
            {
                Console.WriteLine("Deseja cadastrar mais um Autor?");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        AddWriter(book);
                        veri = false;
                        break;
                    case 2:
                        veri = true;
                        break;
                    default:
                        veri = false;
                        break;
                }
            }



            Console.Clear();
            Console.WriteLine("Livro Adicionado com sucesso!");
            Console.ReadKey();
            MenuBookScreen.Load();
        }
        public static void AddCategory(BookTable book)
        {
            Console.Clear();
            string categoryName = "";
            bool veri = false;
            Console.Clear();
            categoryName = CategoryDataVerify.NameVerify(categoryName);
            var category = CategoryEndpoint.Create(categoryName);
            CategoryBookEndpoint.Create(book, category);
        }

        public static void AddWriter(BookTable book)
        {
            Console.Clear();
            string writerName = "";
            bool veri = false;
            Console.Clear();
            writerName = WriterDataVerify.Name(writerName);
            var writerN = WriterEndpoint.Create(writerName);
            WriterBookEndpoint.Create(book, writerN);

        }
    }
}
