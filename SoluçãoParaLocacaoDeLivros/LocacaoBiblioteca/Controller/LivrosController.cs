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
        static LivrosContextDB LivrosDB = new LivrosContextDB();

        public IQueryable<Livros> GetLivros() => LivrosDB.Livros.Where(x => x.Ativo == true);


        private static bool IsAllRemoved()
        {
            foreach (var item in LivrosDB.Livros.ToList<Livros>())
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
            if (LivrosDB.Livros == null || LivrosDB.Livros.ToList<Livros>().Count == 0 || IsAllRemoved())
                Console.WriteLine("Não existem livros cadastrados!");
            else
            {
                LivrosDB.Livros.ToList<Livros>().ForEach(i => ReturnLivroIDLogin(i));
            }
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        public void RegisterLivros(int usuarioLogado)
        {
            Console.Clear();
            Console.WriteLine("------ CADASTRO DE LIVROS ------");
            Console.Write("Digite o nome do livro: ");
            LivrosDB.Livros.Add(new Livros()
            {
                Nome = Console.ReadLine(),
                UsuarioAlteracao = usuarioLogado,
                UsuarioCriacao = usuarioLogado
            });
            LivrosDB.SaveChanges();
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        public void UpdateLivros(int usuarioLogado)
        {
            var semDados = 0;
            foreach (var item in LivrosDB.Livros.ToList<Livros>())
            {
                if (item.Ativo == true)
                {
                    semDados++;
                }
            }
            if (semDados > 0)
            {
                Console.Clear();
                Console.WriteLine("------ ATUALIZAÇÃO DE LIVROS ------");
                Console.Write("Digite o antigo nome do livro: ");
                var Nome = Console.ReadLine();
                Console.Write("Digite o novo nome do livro: ");
                var NomeNovo = Console.ReadLine();
                var livro = LivrosDB.Livros.FirstOrDefault(i => i.Ativo == true && i.Nome == Nome);
                if (livro != null)
                {
                    livro.Nome = NomeNovo;
                    livro.UsuarioAlteracao = usuarioLogado;
                    livro.UsuarioCriacao = usuarioLogado;
                    LivrosDB.SaveChanges();
                }
                else
                    Console.WriteLine("NÃO FOI ENCONTRADO UM LIVRO COM ESSE NOME!");
                Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
            }
        }

        public void ExcluirLivro()
        {
            Console.Clear();
            Console.WriteLine("------ REMOÇÃO DE LIVROS ------");
            if (LivrosDB.Livros.ToList<Livros>().Count != 0)
            {
                Console.Write("Digite o nome do livro: ");
                var livroItem = Console.ReadLine();
                bool removed = false;
                var livro = LivrosDB.Livros.FirstOrDefault(i => i.Nome == livroItem);
                if (livro != null)
                {
                    removed = true;
                    livro.Ativo = false;
                    LivrosDB.SaveChanges();
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
