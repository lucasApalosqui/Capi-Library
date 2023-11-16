using CapiLibrary.Screens.BookScreens;
using CapiLibrary.Screens.UserScreens;
using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens
{
    public static class MenuBookScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Livros");
            MenuWrite.Dotted();
            MenuWrite.OptionGen(new List<string> { "Ver Livros", "Adicionar Livros", "Atualizar Livros", "Deletar Livros", "Voltar" });
            MenuWrite.SkipLine(2);

            try
            {
                Console.Write("Selecione a opção: ");
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        //ListUserScreen.Load();
                        break;
                    case 2:
                        CreateBookScreen.Load();
                        break;
                    case 3:
                        //UpdateUserScreen.Load();
                        break;
                    case 4:
                        //DeleteUserScreen.Load();
                        break;

                    case 5:
                        MainMenuScreen.Load();
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
