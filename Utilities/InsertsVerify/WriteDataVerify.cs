using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Utilities.InsertsVerify
{
    public static class WriteDataVerify
    {
        public static string NameVerify(string name)
        {
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Titulo: ");
                name = Console.ReadLine();
                if (name.Length > 80)
                {
                    Console.WriteLine("Titulo não pode conter mais de 80 caracteres");
                    veri = false;
                }
                if (name.IsNullOrEmpty())
                {
                    Console.WriteLine("Titulo não pode estar vazio");
                    veri = false;
                }
                else
                {
                    Console.WriteLine("Campo Preenchido");
                    veri = true;
                }

            }
            return name;
        }
    }
}
