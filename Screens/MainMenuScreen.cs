using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens
{
    public static class MainMenuScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Capi Library");
            MenuWrite.Dotted();
            MenuWrite.OptionGen(new List<string> { "Gestão de Usuários" });
            MenuWrite.SkipLine(2);

            try
            {
                Console.Write("Selecione a opção: ");
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        MenuUserScreen.Load();
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
