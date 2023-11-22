using CapiLibrary.Endpoints;
using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Screens.HireScreens
{
    public static class DeleteHireScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Deletar Locação");
            MenuWrite.Dotted();
            Console.WriteLine("Informe o Email do Usuário que deseja excluir a locação: ");
            var email = Console.ReadLine();
            var user = UserEndpoint.GetByEmail(email);
            if (user == null)
            {
                Console.WriteLine("Usuário não encontrado");
                Console.ReadKey();
                MenuHireScreen.Load();
            }
            Console.WriteLine($"Deseja mesmo excluir a locação: ");
            var hire = BookUserEndpoint.GetByIdUser(user.Id);
            var book = BookEndpoint.GetById(hire.IdBook);
            Console.WriteLine($"Usuário: {user.Email} Livro: {book.Title}");
            Console.WriteLine($"Data de Locação: {hire.GetDate} Data de Retorno: {hire.ReturnDate}");
            MenuWrite.Dotted();
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - não");
            int option = short.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    BookUserEndpoint.DeleteByUser(user);
                    Console.WriteLine("Locação Excluida com sucesso!");
                    Console.ReadKey();
                    MenuHireScreen.Load();
                    break;
                case 2:
                    Console.WriteLine("Locação não excluida");
                    Console.ReadKey();
                    MenuHireScreen.Load();
                    break;
                default:
                    Console.WriteLine("opção inválida!");
                    Console.ReadKey();
                    MenuHireScreen.Load();
                    break;
            }

        }
    }
}
