using CapiLibrary.Endpoints;
using CapiLibrary.Logics.BookLogic;
using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens.BookScreens
{
    public static class ListBookScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Visualizar Livros");
            MenuWrite.Dotted();
            MenuWrite.OptionGen(new List<string> { "Todos os livros", "Livros por Classificação", "Livros por autor", "Livros por categoria", "Livro por Id", "Livros Por Nome", "Voltar" });
            MenuWrite.SkipLine(2);
            try
            {
                Console.Write("Selecione a opção: ");
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        ListBookLogic.ListAllBooks();
                        break;
                    case 2:
                        ListBookLogic.ListPerGeneralAud();
                        break;
                    case 3:
                        ListBookLogic.ListByWriter();
                        break;
                    default:
                        Console.WriteLine("Opção inválida tente novamente");
                        Console.ReadKey();
                        Load();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Opção inválida tente novamente");
                Console.ReadKey();
                Load();
            }
        }
    }
}
