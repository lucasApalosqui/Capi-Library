using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Utilities.InsertsVerify
{
    public static class PhoneDataVerify
    {
        public static string Phone(string phone)
        {
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Numero de telefone: ");
                phone = Console.ReadLine();
                veri = MenuLogic.VerifyPhone(phone);
            }
            return phone;
        }
    }
}
