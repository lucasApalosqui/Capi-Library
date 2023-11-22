using CapiLibrary.Endpoints;
using CapiLibrary.Screens;
using CapiLibrary.Screens.HireScreens;
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

        public static void ListByUser()
        {
            Console.Clear();
            Console.WriteLine("Locação por usuário");
            MenuWrite.Dotted();
            Console.Write("Qual o email do usuário que deseja pesquisar: ");
            var email = Console.ReadLine();
            var user = UserEndpoint.GetByEmail(email);
            if (user == null)
            {
                Console.WriteLine("Usuário Não Encontrado!");
                Console.ReadKey();
                ListHireScreen.Load();
            }
            var hires = BookUserEndpoint.GetByUser(user);
            if (hires != null)
            {
                foreach (var hire in hires)
                {
                  
                    var book = BookEndpoint.GetById(hire.IdBook);
                    Console.WriteLine();
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

        public static void ListByBook()
        {
            Console.Clear();
            Console.WriteLine("Locações por Livro");
            MenuWrite.Dotted();
            Console.Write("Qual o Id do livro que deseja pesquisar: ");
            int id = short.Parse(Console.ReadLine());
            var book = BookEndpoint.GetById(id);
            if (book == null)
            {
                Console.WriteLine("Livro Não Encontrado!");
                Console.ReadKey();
                ListHireScreen.Load();
            }
            var hires = BookUserEndpoint.GetByBook(book);
            if (hires != null)
            {
                foreach (var hire in hires)
                {
                    Console.WriteLine();
                    var user = UserEndpoint.GetById(hire.IdUser);
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
