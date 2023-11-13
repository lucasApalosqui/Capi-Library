using CapiLibrary.Endpoints;
using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar um Usuário");
            MenuWrite.Dotted();
            try
            {
                Console.Write("Informe o Email Do usuário que deseja deletar: ");
                string email = Console.ReadLine();
                var user = UserEndpoint.GetByEmail(email);
                if (user == null)
                {
                    Console.WriteLine("Usuário não encontrado, tente novamente");
                    Console.ReadKey();
                    Load();
                }
                Console.WriteLine($"Deseja mesmo deletar o usuário: {user.FirstName} {user.LastName}");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");
                var option = short.Parse(Console.ReadLine()!);
                

                switch (option)
                {
                    case 1:
                        UserEndpoint.DeleteUser(user);
                        Console.WriteLine("Usuário Deletado com sucesso!");
                        Console.ReadKey();
                        MenuUserScreen.Load();
                        break;
                    case 2:
                        Console.WriteLine("Usuário Não foi Deletado");
                        Console.ReadKey();
                        MenuUserScreen.Load();
                        break;
                    default:
                        Console.WriteLine("Opção inválida, Voltando ao menu!");
                        Console.ReadKey();
                        MenuUserScreen.Load();
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Nao foi possivel realizar a operação");
            }
        }
    }
}
