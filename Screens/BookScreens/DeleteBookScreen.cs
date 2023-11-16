using CapiLibrary.Endpoints;
using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens.BookScreens
{
    public static class DeleteBookScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar Livros");
            MenuWrite.Dotted();
            try
            {
                Console.Write("Informe o Id Do Livro que deseja deletar: ");
                int id = short.Parse(Console.ReadLine()!);
                var book = BookEndpoint.GetById(id);
                if (book == null)
                {
                    Console.WriteLine("Livro não encontrado, tente novamente");
                    Console.ReadKey();
                    Load();
                }
                else
                {
                    Console.WriteLine($"Deseja mesmo deletar o Livro: {book.Title}");
                    MenuWrite.SkipLine(1);
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");
                    var option = short.Parse(Console.ReadLine()!);
                    switch (option)
                    {
                        case 1:
                            BookEndpoint.Delete(book);
                            Console.WriteLine("Livro Deletado com sucesso!");
                            Console.ReadKey();
                            MenuBookScreen.Load();
                            break;
                        case 2:
                            Console.WriteLine("Livro Não foi Deletado");
                            Console.ReadKey();
                            MenuBookScreen.Load();
                            break;
                        default:
                            Console.WriteLine("Opção inválida, Voltando ao menu!");
                            Console.ReadKey();
                            MenuUserScreen.Load();
                            break;
                    }
                }

            }
            catch
            {
                Console.WriteLine("Nao foi possivel realizar a operação");
            }
        }
    }
}
