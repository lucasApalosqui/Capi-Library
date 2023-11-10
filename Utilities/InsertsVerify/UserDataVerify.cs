using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Utilities.InsertsVerify
{
    public static class UserDataVerify
    {
        public static string FirstName(string fName)
        {
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Primeiro nome: ");
                fName = Console.ReadLine();
                veri = MenuLogic.VerifyWord(fName, false);
            }
            return fName;
        }

        public static string LastName(string lastName)
        {
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Sobrenome: ");
                lastName = Console.ReadLine();
                veri = MenuLogic.VerifyWord(lastName, true);
            }
            return lastName;
        }

        public static string Email(string email)
        {
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Email: ");
                email = Console.ReadLine();
                veri = MenuLogic.VerifyEmail(email);
            }
            return email;
        }

        public static string Cpf(string cpf)
        {
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Cpf: ");
                cpf = Console.ReadLine();
                veri = MenuLogic.VerifyCpf(cpf);
            }
            return cpf;
        }
    }


}
