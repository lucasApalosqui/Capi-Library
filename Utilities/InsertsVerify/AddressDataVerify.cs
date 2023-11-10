using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Utilities.InsertsVerify
{
    public static class AddressDataVerify
    {
        public static string Street(string street)
        {
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe a rua: ");
                street = Console.ReadLine();
                veri = MenuLogic.VerifyWord(street, true);
            }
            return street;
        }

        public static string District(string district)
        {
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe o bairro: ");
                district = Console.ReadLine();
                veri = MenuLogic.VerifyWord(district, true);
            }
            return district;
        }

        public static string State(string state)
        {
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Estado: ");
                state = Console.ReadLine();
                veri = MenuLogic.VerifyWord(state, true);
            }
            return state;
        }

        public static int Number(string number)
        {
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Numero: ");
                number = Console.ReadLine();
                veri = MenuLogic.VerifyNumber(number);

            }
            return int.Parse(number);

        }

        public static string Complement(string complement)
        {
            bool veri = false;
            Console.WriteLine("Endereço contém complemento?: ");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            var option = short.Parse(Console.ReadLine()!);
            switch (option)
            {
                case 1:
                    while (veri == false)
                    {
                        complement = Console.ReadLine();
                        veri = MenuLogic.VerifyWord(complement, true);

                    }
                    return complement;

                case 2:
                    complement = null;
                    return complement;

                default:
                    Console.WriteLine("Opção inválida tente novamente");
                    Console.ReadKey();
                    Complement("");
                    return complement = null;


            }
            
        }
    }
}
