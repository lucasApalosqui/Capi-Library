using CapiLibrary.Endpoints;
using CapiLibrary.Models;
using CapiLibrary.Utilities;
using CapiLibrary.Utilities.InsertsVerify;
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
            string phone = "";
            string street = "", district = "", state = "", numberS = "", complement = "";
            int number = 0;

            fName = UserDataVerify.FirstName(fName);
            lastName = UserDataVerify.LastName(lastName);
            email = UserDataVerify.Email(email);
            cpf = UserDataVerify.Cpf(cpf);
            UserEndpoint.Create(fName, lastName, email, cpf);


            UserTable user = UserEndpoint.GetByEmail(email);

            phone = PhoneDataVerify.Phone(phone);
            PhoneEndpoint.Create(phone, user.Id);

            street = AddressDataVerify.Street(street);
            district = AddressDataVerify.District(district);
            state = AddressDataVerify.State(state);
            number = AddressDataVerify.Number(numberS);
            complement = AddressDataVerify.Complement(complement);

            AddressEndpoint.Create(street, district, state, number, complement, user.Id);

            Console.Clear();
            Console.WriteLine("Usuário criado com sucesso!");
            Console.ReadKey();
            MenuUserScreen.Load();



        }
    }
}
