using CapiLibrary.Screens.UserScreens;
using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Usuários");
            MenuWrite.Dotted();
            MenuWrite.OptionGen(new List<string> { "Ver Usuários", "Criar Usuários", "Atualizar Usuários", "Deletar Usuários", "Voltar" });
            MenuWrite.SkipLine(2);

            try
            {
                Console.Write("Selecione a opção: ");
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        ListUserScreen.Load();
                        break;
                    case 2:
                        CreateUserScreen.Load();
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
