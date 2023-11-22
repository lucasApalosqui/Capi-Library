using CapiLibrary.Endpoints;
using CapiLibrary.Screens;
using CapiLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Logics.HireLogic
{
    public static class ListHireLogic
    {
        public static void ListAllHire()
        {
            Console.Clear();
            Console.WriteLine("Todas as Locações");
            MenuWrite.Dotted();
            var hires = BookUserEndpoint.GetAll();
            if (hires != null)
            {
                foreach (var hire in hires)
                {
                    var user = UserEndpoint.GetById(hire.IdUser);
                    var book = BookEndpoint.GetById(hire.IdBook);
                    Console.WriteLine($"Usuário: {user.Email} Livro: {book.Title}");
                    Console.WriteLine($"Data de Locação {hire.GetDate.ToString("dd/MM/yyyy")} Data de Retorno {hire.ReturnDate.ToString("dd/MM/yyyy")}");
                    MenuWrite.Dotted();
                }
            }
            else
            {
                Console.WriteLine("Nenhuma Locação Ativa!");
                Console.ReadKey();
                MenuHireScreen.Load();
            }
            Console.ReadKey();
            MenuHireScreen.Load();

        }
    }
}
