using CapiLibrary.Endpoints;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Utilities.InsertsVerify
{
    public static class CategoryDataVerify
    {
        public static string NameVerify(string name)
        {
            bool veri = false;
            while (veri == false)
            {
                CategoryEndpoint.GetAll();
                Console.WriteLine();
                Console.Write("Informe a categoria: ");
                name = Console.ReadLine();
                if (name.Length > 80)
                {
                    Console.WriteLine("Categoria não pode conter mais de 80 caracteres");
                    veri = false;
                }
                if (name.IsNullOrEmpty())
                {
                    Console.WriteLine("Categoria não pode estar vazio");
                    veri = false;
                }
                if (name.Any(char.IsPunctuation))
                {
                    Console.WriteLine("Pontuações não são permitidas nesse campo");
                    veri =  false;

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
