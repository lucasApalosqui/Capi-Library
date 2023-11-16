using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Utilities.InsertsVerify
{
    public static class WriterDataVerify
    {
        public static string Name(string name)
        {
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Autor: ");
                name = Console.ReadLine();
                veri = MenuLogic.VerifyWord(name, true);
            }
            return name;
        }
    }
}
