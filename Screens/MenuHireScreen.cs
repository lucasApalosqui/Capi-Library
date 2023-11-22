using CapiLibrary.Screens.HireScreens;
using CapiLibrary.Screens.UserScreens;
using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens
{
    public static class MenuHireScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Locações");
            MenuWrite.Dotted();
            MenuWrite.OptionGen(new List<string> { "Ver locações", "Criar Locações", "Excluir Locações",  "Voltar" });
            MenuWrite.SkipLine(2);
            try
            {
                Console.Write("Selecione a opção: ");
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        //ListHireScreen.Load();
                        break;
                    case 2:
                        CreateHireScreen.Load();
                        break;
                    case 3:
                        //DeleteHireScreen.Load();
                        break;
                    case 4:
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
