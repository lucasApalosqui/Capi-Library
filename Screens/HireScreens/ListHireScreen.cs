using CapiLibrary.Logics.HireLogic;
using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens.HireScreens
{
    public static class ListHireScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Listar Locações");
            MenuWrite.Dotted();
            MenuWrite.OptionGen(new List<string> { "Ver Todas as Locações", "Pesquisar por Livro", "Pesquisar por Usuário", "Voltar" });
            MenuWrite.SkipLine(2);
            try
            {
                Console.Write("Selecione a opção: ");
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        ListHireLogic.ListAllHire();
                        break;
                    case 2:
                        ListHireLogic.ListByBook();
                        break;
                    case 3:
                        ListHireLogic.ListByUser();
                        break;
                    case 4:
                        MenuHireScreen.Load();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Console.ReadKey();
                        Load();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Opção inválida tente novamente");
                Console.ReadKey();
                Load();
            }
        }
    }
}
