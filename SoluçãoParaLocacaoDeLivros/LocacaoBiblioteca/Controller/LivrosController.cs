using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocacaoBiblioteca.Model;

namespace LocacaoBiblioteca.Controller
{
    public class LivrosController
    {
        public LivrosController()
        {
            LocacaoContext.ListaLivros = new List<Livros>();
        }

        public static int Id { get; set; }

        private static bool IsAllRemoved()
        {
            foreach (var item in LocacaoContext.ListaLivros)
            {
                if (item.Ativo == true)
                    return false;
            }
            return true;
        }

        private static void ReturnLivroIDLogin(Livros livro)
        {
            if (livro.Ativo == true)
                Console.WriteLine($"ID: {livro.Id} NOME: {livro.Nome}");

        }

        public void ListLivros()
        {
            Console.Clear();
            Console.WriteLine("------ LISTAGEM DE LIVROS ------");
            if (LocacaoContext.ListaLivros == null || LocacaoContext.ListaLivros.Count == 0 || IsAllRemoved())
                Console.WriteLine("Não existem livros cadastrados!");
            else
            {
                LocacaoContext.ListaLivros.ForEach(i => ReturnLivroIDLogin(i));
            }
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        public void RegisterLivros()
        {
            Console.Clear();
            Console.WriteLine("------ CADASTRO DE LIVROS ------");
            Console.Write("Digite o nome do livro: ");
            LocacaoContext.ListaLivros.Add(new Livros()
            {
                Id = LivrosController.Id,
                Nome = Console.ReadLine(),
                Ativo = true
            });
            LivrosController.Id++;
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        public void ExcluirLivro()
        {
            Console.Clear();
            Console.WriteLine("------ REMOÇÃO DE LIVROS ------");
            if (LocacaoContext.ListaLivros.Count != 0)
            {
                Console.Write("Digite o nome do livro: ");
                var livroItem = Console.ReadLine();
                bool removed = false;
                foreach (var item in LocacaoContext.ListaLivros)
                {
                    if (item.Nome == livroItem)
                    {
                        removed = true;
                        item.Ativo = false;
                        break;
                    }
                }
                if (removed)
                    Console.WriteLine($"Livro: {livroItem} foi excluido com sucesso!");
                else
                    Console.WriteLine($"Livro: {livroItem} não foi encontrado!");
            }
            else
            {
                Console.WriteLine("NÃO EXISTEM LIVROS CADASTRADOS");
            }
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

    }


}
