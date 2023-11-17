using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Utilities
{
    public static class MenuWrite
    {
        public static void ColorP(string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void Dotted()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine();
        }

        public static void SkipLine(int line)
        {
            for (int i = 0; i < line; i++)
            {
                Console.WriteLine();
            }
        }

        public static void OptionGen(List<string> options)
        {
            Console.WriteLine("O que deseja fazer?");
            SkipLine(1);
            var num = 0;
            foreach (string option in options)
            {
                num++;
                Console.WriteLine($"{num} - {option}");
            }
        }
    }
}
