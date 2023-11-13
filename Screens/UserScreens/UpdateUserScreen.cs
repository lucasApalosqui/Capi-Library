using CapiLibrary.Endpoints;
using CapiLibrary.Models;
using CapiLibrary.Repositories;
using CapiLibrary.Utilities;
using CapiLibrary.Utilities.InsertsVerify;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens.UserScreens
{
    public static class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Usuário");
            MenuWrite.Dotted();
            try
            {
                Console.Write("Informe o Email Do usuário que deseja Alterar os dados: ");
                MenuWrite.SkipLine(1);
                string email = Console.ReadLine();
                var user = UserEndpoint.GetByEmail(email);
                if (user == null)
                {
                    Console.WriteLine("Usuário não encontrado, tente novamente");
                    Console.ReadKey();
                    Load();
                }
                Options(user.Email);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Nao foi possivel realizar a operação");
                Console.ReadKey();
                MenuUserScreen.Load();
            }
        }

        public static void Options(string email)
        {
            
            MenuWrite.SkipLine(1);
            MenuWrite.OptionGen(new List<string> { "Dados gerais do Usuário", "Telefone", "Endereço" });
            MenuWrite.SkipLine(2);
            Console.Write("Selecione a opção: ");
            var option = short.Parse(Console.ReadLine()!);
            string dataRead = "";
            switch (option)
            {
                case 1:
                    string fName = "", lastName = "", emailR = "", cpf = "";
                    Console.Clear();
                    var user = UserEndpoint.GetByEmail(email);
                    Console.WriteLine($"Escreva 1 e aperte ENTER para cadastrar um novo dado ou Aperte apenas ENTER para manter o dado antigo");
                    MenuWrite.SkipLine(1);

                    Console.Write($"First Name: ({user.FirstName}) ");
                    dataRead = Console.ReadLine();
                    if (dataRead.IsNullOrEmpty()) user.FirstName = user.FirstName;
                    else { fName = UserDataVerify.FirstName(fName); user.FirstName = fName; } 
                    

                    Console.Write($"Last Name: ({user.LastName})  ");
                    dataRead = Console.ReadLine();
                    if (dataRead.IsNullOrEmpty()) user.LastName = user.LastName;
                    else { lastName = UserDataVerify.LastName(lastName); user.LastName = lastName; }

                    Console.Write($"CPF: ({user.Cpf})  ");
                    dataRead = Console.ReadLine();
                    if (dataRead.IsNullOrEmpty()) user.Cpf = user.Cpf;
                    else { cpf = UserDataVerify.Cpf(cpf); user.Cpf = cpf; }

                    Console.Write($"Email: ({user.Email})  ");
                    dataRead = Console.ReadLine();
                    if (dataRead.IsNullOrEmpty()) user.Email = user.Email;
                    else { email = UserDataVerify.Email(email); user.Email = email; }

                    Repository<UserTable> repo = new Repository<UserTable>();
                    repo.Update(user);
                    Console.WriteLine("Usuário Atualizado com sucesso!");
                    Console.ReadKey();
                    ContinueUpdate(user.Email);
                    break;

                case 2:
                    string phone = "";
                    Console.Clear();
                    var phone2 = PhoneEndpoint.GetByUserEmail(email);
                    Console.WriteLine($"Escreva 1 e aperte ENTER para cadastrar um novo dado ou Aperte apenas ENTER para manter o dado antigo");
                    MenuWrite.SkipLine(1);

                    Console.Write($"Phone: ({TextMask.NumberMask(phone2.Phone)})  ");
                    dataRead = Console.ReadLine();
                    if (dataRead.IsNullOrEmpty()) phone2.Phone = phone2.Phone;
                    else { phone = PhoneDataVerify.Phone(phone); phone2.Phone = phone; }

                    Repository<PhoneTable> repo2 = new Repository<PhoneTable>();
                    repo2.Update(phone2);
                    Console.WriteLine("Número Atualizado com sucesso!");
                    Console.ReadKey();
                    ContinueUpdate(email);
                    break;

                case 3:
                    string street = "", district = "", state = "", numberS = "", complement = "";
                    int number = 0;
                    Console.Clear();
                    var address = AddressEndpoint.GetByUserEmail(email);
                    Console.WriteLine($"Escreva 1 e aperte ENTER para cadastrar um novo dado ou Aperte apenas ENTER para manter o dado antigo");
                    MenuWrite.SkipLine(1);

                    Console.Write($"Rua: ({address.Street})  ");
                    dataRead = Console.ReadLine();
                    if (dataRead.IsNullOrEmpty()) address.Street = address.Street;
                    else { street = AddressDataVerify.Street(street); address.Street = street; }

                    Console.Write($"Bairro: ({address.District})  ");
                    dataRead = Console.ReadLine();
                    if (dataRead.IsNullOrEmpty()) address.District = address.District;
                    else { district = AddressDataVerify.District(district); address.District = district; }

                    Console.Write($"Numero: ({address.Number})  ");
                    dataRead = Console.ReadLine();
                    if (dataRead.IsNullOrEmpty()) address.Number = address.Number;
                    else { number = AddressDataVerify.Number(numberS); address.Number = number; }

                    Console.Write($"Estado: ({address.State})  ");
                    dataRead = Console.ReadLine();
                    if (dataRead.IsNullOrEmpty()) address.State = address.State;
                    else { state = AddressDataVerify.State(state); address.State = state; }

                    if (address.Complement.IsNullOrEmpty())
                    {
                        Console.Write($"Complemento: (Vazio)  ");
                        dataRead = Console.ReadLine();
                        if (dataRead.IsNullOrEmpty()) address.Complement = address.Complement;
                        else { complement = AddressDataVerify.Complement(complement); address.Complement = complement; }
                    }
                    else
                    {
                        Console.Write($"Complemento: ({address.Complement})  ");
                        dataRead = Console.ReadLine();
                        if (dataRead.IsNullOrEmpty()) address.Complement = address.Complement;
                        else { complement = AddressDataVerify.Complement(complement); address.Complement = complement; }
                    }

                    Repository<AddressTable> repo3 = new Repository<AddressTable>();
                    repo3.Update(address);
                    Console.WriteLine("Endereço Atualizado com sucesso!");
                    Console.ReadKey();
                    ContinueUpdate(email);
                    break;

                default:
                    Console.WriteLine("Opção inválida tente novamente");
                    Console.ReadKey();
                    Load();
                    break;
            }
        }

        public static void ContinueUpdate(string email)
        {
            MenuWrite.SkipLine(1);
            Console.WriteLine("Deseja atualizar outros dados?");
            MenuWrite.OptionGen(new List<string> { "Sim", "Não" });
            var option = short.Parse(Console.ReadLine()!);
            switch (option)
            {
                case 1:
                    Options(email);
                    break;
                case 2:
                    MenuUserScreen.Load();
                    break;
                default:
                    Console.WriteLine("Opção inválida tente novamente");
                    Console.ReadKey();
                    ContinueUpdate(email);
                    break;
            }
        }
    }
}
