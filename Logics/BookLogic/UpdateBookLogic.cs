using CapiLibrary.Endpoints;
using CapiLibrary.Models;
using CapiLibrary.Repositories;
using CapiLibrary.Screens;
using CapiLibrary.Utilities;
using CapiLibrary.Utilities.InsertsVerify;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapiLibrary.Logics.BookLogic
{
    public static class UpdateBookLogic
    {
        public static void UpdateBookMenu(BookTable book)
        {
            MenuWrite.SkipLine(1);
            MenuWrite.OptionGen(new List<string> { "Dados gerais do Livro", "Categorias", "Autores" });
            MenuWrite.SkipLine(2);
            var option = short.Parse(Console.ReadLine()!);
            string dataRead = "";
            switch (option)
            {
                case 1:
                    UpdateGeneralBook(book);
                    break;
                case 2:
                    UpdateCategoryBook(book);
                    break;
                case 3:
                    UpdateWriterBook(book);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    MenuBookScreen.Load();
                    break;
            }
        }


        public static void UpdateGeneralBook(BookTable book)
        {
            string title = "", synopsis = "", pagesS = "", generalAud = "", writerName = "";
            int pages = 0;
            string dataRead = "";
            Console.Clear();
            Console.WriteLine($"Escreva 1 e aperte ENTER para cadastrar um novo dado ou Aperte apenas ENTER para manter o dado antigo");

            Console.Write($"Titulo: ({book.Title}) ");
            dataRead = Console.ReadLine();
            if (dataRead.IsNullOrEmpty()) book.Title = book.Title;
            else { title = BookDataVerify.Title(title); book.Title = title; }

            Console.Write($"Sinopse: ({book.Synopsis}) ");
            dataRead = Console.ReadLine();
            if (dataRead.IsNullOrEmpty()) book.Synopsis = book.Synopsis;
            else { synopsis = BookDataVerify.Synopsis(synopsis); book.Synopsis = synopsis; }

            Console.Write($"Páginas ({book.Pages}) ");
            dataRead = Console.ReadLine();
            if (dataRead.IsNullOrEmpty()) book.Pages = book.Pages;
            else { pages = BookDataVerify.Pages(dataRead); book.Pages = pages; }

            Console.Write($"Classificação ({book.GeneralAud}) ");
            dataRead = Console.ReadLine();
            if (dataRead.IsNullOrEmpty()) book.GeneralAud = book.GeneralAud;
            else { generalAud = BookDataVerify.GeneralAud(dataRead); book.GeneralAud = generalAud; }


            Repository<BookTable> repo = new Repository<BookTable>();
            repo.Update(book);
            Console.WriteLine("Livro Atualizado com sucesso!");
            Console.ReadKey();
            ContinueUpdate(book);
        }

        public static void UpdateWriterBook(BookTable book)
        {
            string writerName = "";
            Console.Clear();
            Console.WriteLine("O que deseja fazer");
            Console.WriteLine("1 - Adicionar novo Autor");
            Console.WriteLine("2 - Alterar Autores");
            var option = short.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Write("Digite o novo autor: ");
                    writerName = Console.ReadLine();
                    if (!writerName.IsNullOrEmpty())
                    {

                        if (WriterEndpoint.GetByName(writerName) == null)
                        {
                            WriterEndpoint.Create(writerName);
                            var writ = WriterEndpoint.GetByName(writerName);
                            WriterBookEndpoint.Create(book, writ);
                            Console.WriteLine("Alterado com sucesso!");
                        }
                        else
                        {

                            var writ = WriterEndpoint.GetByName(writerName);
                            WriterBookEndpoint.Create(book, writ);
                            Console.WriteLine("Alterado com sucesso!");
                        }

                    }
                    Console.WriteLine("Autor Adicionado com sucesso!");
                    Console.ReadKey();
                    ContinueUpdate(book);
                    break;
                case 2:
                    Console.WriteLine($"Escreva 1 e aperte ENTER para cadastrar um novo dado ou Aperte apenas ENTER para manter o dado antigo");
                    var writers = WriterEndpoint.GetWritersByBookId(book.Id);
                    foreach (var writer in writers)
                    {
                        Console.Write($"Categoria: ({writer.Name}) ");
                        Console.WriteLine("Deseja Alterar este autor?");
                        Console.WriteLine("1 - Sim");
                        Console.WriteLine("2 - Não");
                        option = short.Parse(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                Console.Write("Digite a nova categoria: ");
                                writerName = Console.ReadLine();
                                if (!writerName.IsNullOrEmpty())
                                {

                                    if (CategoryEndpoint.GetByName(writerName) == null)
                                    {

                                        WriterBookEndpoint.DeleteByWriterAndBookId(writer.Id, book.Id);
                                        WriterEndpoint.Create(writerName);
                                        var writ = WriterEndpoint.GetByName(writerName);
                                        WriterBookEndpoint.Create(book, writ);
                                        Console.WriteLine("Alterado com sucesso!");
                                    }
                                    else
                                    {
                                        WriterBookEndpoint.DeleteByWriterAndBookId(writer.Id, book.Id);
                                        var writ = WriterEndpoint.GetByName(writerName);
                                        WriterBookEndpoint.Create(book, writ);
                                        Console.WriteLine("Alterado com sucesso!");
                                    }

                                }
                                break;
                            case 2:
                                break;
                            default:
                                break;
                        }
                    }

                    Console.WriteLine("Autores atualizados com sucesso!");
                    Console.ReadKey();
                    ContinueUpdate(book);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    UpdateWriterBook(book);
                    break;
            }
        }

        public static void UpdateCategoryBook(BookTable book)
        {
            string categoryName = "";
            Console.Clear();
            Console.WriteLine("O que deseja fazer");
            Console.WriteLine("1 - Adicionar nova categoria");
            Console.WriteLine("2 - Alterar categorias");
            var option = short.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Write("Digite a nova categoria: ");
                    categoryName = Console.ReadLine();
                    if (!categoryName.IsNullOrEmpty())
                    {

                        if (CategoryEndpoint.GetByName(categoryName) == null)
                        {


                            CategoryEndpoint.Create(categoryName);
                            var cate = CategoryEndpoint.GetByName(categoryName);
                            CategoryBookEndpoint.Create(book, cate);
                            Console.WriteLine("Alterado com sucesso!");
                        }
                        else
                        {

                            var cate = CategoryEndpoint.GetByName(categoryName);
                            CategoryBookEndpoint.Create(book, cate);
                            Console.WriteLine("Alterado com sucesso!");
                        }

                    }
                    Console.WriteLine("Categoria Adicionada com sucesso!");
                    Console.ReadKey();
                    ContinueUpdate(book);
                    break;
                case 2:
                    Console.WriteLine($"Escreva 1 e aperte ENTER para cadastrar um novo dado ou Aperte apenas ENTER para manter o dado antigo");
                    var categories = CategoryEndpoint.GetCategoriesByBookId(book.Id);
                    foreach (var category in categories)
                    {
                        Console.Write($"Categoria: ({category.Name}) ");
                        Console.WriteLine("Deseja Alterar esta categoria?");
                        Console.WriteLine("1 - Sim");
                        Console.WriteLine("2 - Não");
                        option = short.Parse(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                Console.Write("Digite a nova categoria: ");
                                categoryName = Console.ReadLine();
                                if (!categoryName.IsNullOrEmpty())
                                {

                                    if (CategoryEndpoint.GetByName(categoryName) == null)
                                    {

                                        CategoryBookEndpoint.DeleteByCategoryAndBookId(category.Id, book.Id);
                                        CategoryEndpoint.Create(categoryName);
                                        var cate = CategoryEndpoint.GetByName(categoryName);
                                        CategoryBookEndpoint.Create(book, cate);
                                        Console.WriteLine("Alterado com sucesso!");
                                    }
                                    else
                                    {
                                        CategoryBookEndpoint.DeleteByCategoryAndBookId(category.Id, book.Id);
                                        var cate = CategoryEndpoint.GetByName(categoryName);
                                        CategoryBookEndpoint.Create(book, cate);
                                        Console.WriteLine("Alterado com sucesso!");
                                    }

                                }
                                break;
                            case 2:
                                break;
                            default:
                                break;
                        }
                    }

                    Console.WriteLine("Categoria Atualizada com sucesso!");
                    Console.ReadKey();
                    ContinueUpdate(book);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    UpdateCategoryBook(book);
                    break;
                        
            }




        }

        public static void ContinueUpdate(BookTable book)
        {
            MenuWrite.SkipLine(1);
            Console.WriteLine("Deseja atualizar outros dados?");
            MenuWrite.OptionGen(new List<string> { "Sim", "Não" });
            var option = short.Parse(Console.ReadLine()!);
            switch (option)
            {
                case 1:
                    UpdateBookMenu(book);
                    break;
                case 2:
                    MenuBookScreen.Load();
                    break;
                default:
                    Console.WriteLine("Opção inválida tente novamente");
                    Console.ReadKey();
                    ContinueUpdate(book);
                    break;
            }
        }
    }
}
