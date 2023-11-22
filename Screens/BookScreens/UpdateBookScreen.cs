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
    public static class UpdateBookScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Livros");
            MenuWrite.Dotted();
            MenuWrite.SkipLine(2);
            Console.WriteLine("Qual o ID do livro que deseja Atualizar");
            try
            {
                int id = short.Parse(Console.ReadLine());
                var book = BookEndpoint.GetById(id);
                if (book == null)
                {
                    Console.WriteLine("Livro não encontrado! Tente novamente");
                    Load();
                }
                Console.WriteLine($"Deseja Editar o livro {book.Title} ?");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");
                var option = short.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        UpdateBookLogic.UpdateBookMenu(book);
                        break;
                    case 2:
                        Console.WriteLine("Livro Não Editado!");
                        MenuBookScreen.Load();
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente Novamente");
                        Load();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Apenas Numeros são aceitos, tente novamente!");
                Load();
            }

        }
    }
}
