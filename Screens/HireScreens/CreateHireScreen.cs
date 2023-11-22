using CapiLibrary.Endpoints;
using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens.HireScreens
{
    public static class CreateHireScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Adicionar Locação");
            MenuWrite.Dotted();
            int IdBook = 0;
            string email = "";
            DateTime getDate = DateTime.Now, returnDate = DateTime.Now;
            try
            {
                Console.Write("Informe o Email do usuário que deseja alugar um livro: ");
                email = Console.ReadLine();
                var user = UserEndpoint.GetByEmail(email);
                if (user == null)
                {
                    Console.WriteLine("Usuário não encontrado! Tente novamente");
                    Console.ReadKey();
                    Load();
                }
                Console.WriteLine($"Email: {email}");
                Console.Write("Informe o Id do Livro que deseja alugar: ");
                try
                {
                    IdBook = short.Parse(Console.ReadLine()!);
                    var book = BookEndpoint.GetById(IdBook);
                    if (book == null)
                    {
                        Console.WriteLine("Livro não encontrado! Tente novamente");
                        Console.ReadKey();
                        Load();
                    }
                    Console.WriteLine($"Deseja Vincular o livro: {book.Title} ao Usuário {user.Email}");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");
                    var option = short.Parse(Console.ReadLine()!);
                    switch (option)
                    {
                        case 1:
                            returnDate = returnDate.AddMonths(1);
                            var hireT = BookUserEndpoint.GetByIdUser(user.Id);
                            if (hireT == null)
                            {
                                BookUserEndpoint.Create(book.Id, user.Id, getDate, returnDate);
                                Console.WriteLine("Locação Adicionada");
                                Console.ReadKey();
                                MenuHireScreen.Load();
                            }
                            else
                            {
                                Console.WriteLine("Usuário já tem uma locação ativa, Exclua-a para poder cadastrar uma nova");
                                Console.ReadKey();
                                MenuHireScreen.Load();
                            }
                            
                            break;
                        case 2:
                            Console.WriteLine("Não vinculado");
                            MenuHireScreen.Load();
                            break;
                        default:
                            Console.WriteLine("Não vinculado");
                            MenuHireScreen.Load();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Email Inválido Tente novamente");
                    Load();
                }
                
            }
            catch
            {
                Console.WriteLine("Opção inválida! Tente novamente");
                Console.ReadKey();
                Load();
            }
        }
    }
}
