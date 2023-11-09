using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapiLibrary.Utilities
{
    public static class MenuLogic
    {
        public static bool VerifyWord(string word, bool moreThanOne)
        {
            try
            {
                short.Parse(word);
                Console.WriteLine("Numeros não são aceitos no campo");
                Console.ReadKey();
                Console.Clear();
                return false;

            }
            catch
            {
                if (moreThanOne == false)
                {
                    if (word.Contains(" "))
                    {
                        Console.WriteLine("Apenas Uma palavra é permitida no campo");
                        Console.ReadKey();
                        Console.Clear();
                        return false;
                    }
                }

                if (word.Any(char.IsPunctuation))
                {
                    Console.WriteLine("Pontuações não são permitidas nesse campo");
                    Console.ReadKey();
                    Console.Clear();
                    return false;

                }
                if (word.IsNullOrEmpty())
                {
                    Console.WriteLine("Campo não pode estar vazio");
                    Console.ReadKey();
                    Console.Clear();
                    return false;

                }
                if (ContainNumber(word) == true)
                {
                    Console.WriteLine("Campo não pode conter números");
                    Console.ReadKey();
                    Console.Clear();
                    return false;
                }
                else
                {
                    Console.WriteLine("Campo Preenchido!");
                    Console.ReadKey();
                    Console.Clear();
                    return true;

                }
            }
        }

        public static bool ContainNumber(string text)
        {
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool VerifyEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(email))
            {
                Console.WriteLine("Campo Preenchido!");
                Console.ReadKey();
                Console.Clear();
                return true;
            }
            else
            {
                Console.WriteLine("Email inválido");
                Console.ReadKey();
                Console.Clear();
                return false;
            }

        }

        public static bool VerifyCpf(string cpf)
        {
            try
            {
                UInt64.Parse(cpf);
             
                if (cpf.Length != 11)
                {
                    Console.WriteLine("Quantidade de caracteres inválido");
                    Console.ReadKey();
                    Console.Clear();
                    return false;
                }
                else
                {
                    Console.WriteLine("Campo Preenchido!");
                    Console.ReadKey();
                    Console.Clear();
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("Apenas números são aceitos no campo");
                Console.ReadKey();
                Console.Clear();
                return false;
            }
        }
    }
}
