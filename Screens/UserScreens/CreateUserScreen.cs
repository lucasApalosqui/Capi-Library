using CapiLibrary.Endpoints;
using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criação de Usuário");
            MenuWrite.Dotted();
            string fName = "", lastName = "", email = "", cpf = "";
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Primeiro nome: ");
                fName = Console.ReadLine();
                veri = MenuLogic.VerifyWord(fName, false);
            }
            
            veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Sobrenome: ");
                lastName = Console.ReadLine();
                veri = MenuLogic.VerifyWord(lastName, true);
            }
            veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Email: ");
                email = Console.ReadLine();
                veri = MenuLogic.VerifyEmail(email);
            }
            veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Cpf: ");
                cpf = Console.ReadLine();
                veri = MenuLogic.VerifyCpf(cpf);
            }

            UserEndpoint.Create(fName, lastName, email, cpf);
            Console.Clear();
            Console.WriteLine("Usuário criado com sucesso!");
            Console.ReadKey();
            MenuUserScreen.Load();



        }
    }
}
