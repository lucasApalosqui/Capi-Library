using CapiLibrary.Endpoints;
using CapiLibrary.Utilities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Listar Usuários");
            MenuWrite.Dotted();
            MenuWrite.OptionGen(new List<string> { "Listar Todos os Usuários", "Pesquisar por Email", "Voltar" });
            MenuWrite.SkipLine(2);

            try
            {
                Console.Write("Selecione a opção: ");
                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Todos os Usuários");
                        MenuWrite.Dotted();
                        var users = UserEndpoint.GetAllUsers();
                        if (users.IsNullOrEmpty())
                        {
                            Console.WriteLine("Nenhum Usuário cadastrado!");
                            Console.ReadKey();
                            Load();
                            break;
                        }
                        else
                        {
                            foreach (var user in users)
                            {
                                Console.WriteLine($"ID: {user.Id} | Nome: {user.FirstName} {user.LastName} | Email: {user.Email} | CPF: {TextMask.CpfMask(user.Cpf)}");
                            }
                            Console.ReadKey();
                            Load();
                            break;
                        }


                    case 2:
                        Console.Clear();
                        Console.WriteLine("Pesquisa por Email");
                        MenuWrite.Dotted();
                        Console.Write("Qual email deseja pesquisar: ");
                        var email = Console.ReadLine();
                        try
                        {
                            var user = UserEndpoint.GetByEmail(email);
                            var address = AddressEndpoint.GetByUserEmail(email);
                            var phone = PhoneEndpoint.GetByUserEmail(email);

                            if (user != null)
                            {
                                Console.Clear();
                                Console.WriteLine("Resultado da pesquisa");
                                MenuWrite.Dotted();
                                Console.WriteLine($"ID: {user.Id} | Nome: {user.FirstName} {user.LastName} | CPF: {TextMask.CpfMask(user.Cpf)}");
                                MenuWrite.SkipLine(1);
                                if (address == null)
                                {
                                    Console.WriteLine("Sem endereço cadastrado");
                                }
                                if (phone == null)
                                {
                                    Console.WriteLine("Sem Telefone cadastrado");
                                }
                                else
                                {
                                    Console.WriteLine("Endereço");
                                    Console.WriteLine($"{address.Street}, N°{address.Number}, {address.District}, {address.State}");
                                    if (address.Complement != null)
                                    {
                                        Console.Write($"Complemento: {address.Complement}");
                                    }
                                    MenuWrite.SkipLine(1);
                                    Console.WriteLine($"Telefone: {TextMask.NumberMask(phone.Phone)}");

                                }

                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Usuario não encontrado!");
                                Console.ReadKey();
                                Console.Clear();
                                Load();
                            }
                        }


                        catch (Exception ex)
                        {
                            Console.WriteLine($"não foi possivel pesquisar o email");
                            Console.ReadKey();
                            Console.Clear();
                            Load();
                        }
                        Load();
                        break;

                    case 3:
                        MenuUserScreen.Load();
                        break;


                    default:
                        Console.WriteLine("Opção inválida tente novamente");
                        Console.ReadKey();
                        Load();
                        break;
                }
            }
            

            catch (Exception ex)
            {
                Console.WriteLine("Opção inválida tente novamente");
                Console.ReadKey();
                Load();
            }
        }
    }
}
