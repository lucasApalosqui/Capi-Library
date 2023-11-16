using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Utilities.InsertsVerify
{
    public static class BookDataVerify
    {
        public static string Title(string title)
        {
            Console.Clear();
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe o Titulo: ");
                title = Console.ReadLine();
                if (title.Length > 80)
                {
                    Console.WriteLine("Titulo não pode conter mais de 80 caracteres");
                    veri = false;
                }
                if (title.IsNullOrEmpty())
                {
                    Console.WriteLine("Titulo não pode estar vazio");
                    veri = false;
                }
                else
                {
                    Console.WriteLine("Campo Preenchido");
                    veri = true;
                }

                }
                return title;
        }

        public static string Synopsis(string synopsis)
        {
            Console.Clear();
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe a Sinopse: ");
                synopsis = Console.ReadLine();
                if (synopsis.Length > 400)
                {
                    Console.WriteLine("Sinopse não pode conter mais de 400 caracteres");
                    veri = false;
                }
                if (synopsis.IsNullOrEmpty())
                {
                    Console.WriteLine("Sinopse não pode estar vazia");
                    veri = false;
                }
                else
                {
                    Console.WriteLine("Campo Preenchido");
                    veri = true;
                }

            }
            return synopsis;
        }

        public static int Pages(string pages)
        {
            Console.Clear();
            bool veri = false;
            while (veri == false)
            {
                Console.Write("Informe o numero de páginas: ");
                pages = Console.ReadLine();
                veri = MenuLogic.VerifyNumber(pages);

            }
            return int.Parse(pages);
        }

        public static string GeneralAud(string generalAud)
        {
            Console.Clear();
            bool veri = false;
            while (veri == false)
            {
                Console.WriteLine("Informe a Classificação indicativa do livro: ");
                MenuWrite.OptionGen(new List<string> { "L", "10+", "12+", "14+", "16+", "18+" });
                Console.WriteLine();
                Console.WriteLine("Selecione a opção que deseja inserir");

                var option = short.Parse(Console.ReadLine()!);
                switch (option)
                {
                    case 1:
                        generalAud = "L";
                        return generalAud;
                    case 2:
                        generalAud = "10+";
                        return generalAud;
                    case 3:
                        generalAud = "12+";
                        return generalAud;
                    case 4:
                        generalAud = "14+";
                        return generalAud;
                    case 5:
                        generalAud = "16+";
                        return generalAud;
                    case 6:
                        generalAud = "18+";
                        return generalAud;
                    default:
                        Console.WriteLine("Opção inválida Selecione novamente");
                        return generalAud;


                }

            }
            return generalAud;
        }
    }
}
