using LocacaoBiblioteca.Controller;
using LocacaoBiblioteca.Model;
using System;
using System.Collections.Generic;

namespace InterfaceBiblioteca
{
    class Program
    {
        public static LivrosController livroC = new LivrosController();
        public static UsuarioController usuC = new UsuarioController();
        public static string usuarioLogado;

        static void Main(string[] args)
        {
            ShowLogin();
        }

        /// <summary>
        /// Mostra a mensagem de login
        /// </summary>
        private static void ShowLoginMessage()
        {
            Console.WriteLine("SISTEMA DE LOCAÇÃO DE LIVRO 1.0");
            Console.WriteLine("Informe seu login e senha para acessar o sistema: ");
        }

        /// <summary>
        /// Mostra o login do sistema
        /// </summary>
        private static void ShowLogin()
        {
            ShowLoginMessage();
            Usuarios usuario = new Usuarios
            {
                Login = AskForLogin(),
                Senha = AskForPassword()
            };
            if (usuC.VerifyAllLoginPassword(usuario: usuario))
            {
                Console.WriteLine("Logado");
                usuarioLogado = usuario.Login;
                ShowSystemMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("NÃO FOI POSSIVEL REALIZAR O LOGIN!");
                ShowLogin();
            }
        }

        /// <summary>
        /// Pede que o usuario digite o login
        /// </summary>
        /// <returns>login string</returns>
        private static string AskForLogin()
        {
            Console.Write("Login: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Pede que o usuario digite a senha
        /// </summary>
        /// <returns>senha string</returns>
        public static string AskForPassword()
        {
            Console.Write("Senha: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Mostra o menu do sistema
        /// </summary>
        private static void ShowSystemMenu()
        {
            Console.Clear();
            Console.WriteLine("SISTEMA DE LOCAÇÃO DE LIVRO 1.0");
            Console.WriteLine($"MENU SISTEMA - BEM VINDO - {usuarioLogado}");
            Console.WriteLine("7 - Remover Usuário");
            Console.WriteLine("6 - Remover Livro");
            Console.WriteLine("5 - Cadastrar Usuários");
            Console.WriteLine("4 - Cadastrar Livros");
            Console.WriteLine("3 - Listar Livros");
            Console.WriteLine("2 - Listar Usuários");
            Console.WriteLine("1 - Trocar Usuário");
            Console.WriteLine("0 - Sair");
            var situacao = Console.ReadKey().KeyChar.ToString();
            switch (situacao)
            {
                case "1":
                    Console.Clear();
                    ShowLogin();
                    break;
                case "2":
                    ListUsuarios();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                case "3":
                    ListLivros();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                case "4":
                    RegisterLivros();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                case "5":
                    RegisterUsuarios();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                case "6":
                    ExcluirLivro();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                case "7":
                    ExcluirUsuario();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                default:
                    break;
            }
        }

        private static void RegisterLivros()
        {
            Console.Clear();
            Console.WriteLine("------ CADASTRO DE LIVROS ------");
            Console.Write("Digite o nome do livro: ");
            livroC.ListaLivros.Add(new Livros()
            {
                Id = LivrosController.Id,
                Nome = Console.ReadLine(),
                Ativo = true
            });
            LivrosController.Id++;
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        private static void ExcluirLivro()
        {
            Console.Clear();
            Console.WriteLine("------ REMOÇÃO DE LIVROS ------");
            if (livroC.ListaLivros.Count != 0)
            {
                Console.Write("Digite o nome do livro: ");
                var livroItem = Console.ReadLine();
                bool removed = false;
                foreach (var item in livroC.ListaLivros)
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

        private static void ExcluirUsuario()
        {
            Console.Clear();
            Console.WriteLine("------ REMOÇÃO DE USUÁRIOS ------");
            Console.Write("Digite o login do usuário: ");
            var usuarioItem = Console.ReadLine();
            bool removed = false;
            bool usuLogado = false;
            foreach (var item in usuC.ListaUsuarios)
            {
                if (item.Login == usuarioItem)
                {
                    if (item.Login != usuarioLogado)
                    {
                        removed = true;
                        item.Ativo = false;
                        break;
                    }
                    else
                    {
                        usuLogado = true;
                        break;
                    }
                }
            }
            if (usuLogado)
                Console.WriteLine($"Usuário: {usuarioLogado} não pode ser excluido pois está em uso!");
            else
            {
                if (removed)
                    Console.WriteLine($"Usuário: {usuarioItem} foi excluido com sucesso!");
                else
                    Console.WriteLine($"Usuário: {usuarioItem} não foi encontrado!");
            }
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        private static void ListLivros()
        {
            Console.Clear();
            Console.WriteLine("------ LISTAGEM DE LIVROS ------");
            if (livroC.ListaLivros == null || livroC.ListaLivros.Count == 0 || IsAllRemoved())
                Console.WriteLine("Não existem livros cadastrados!");
            else
            {
                livroC.ListaLivros.ForEach(i => ReturnLivroIDLogin(i));
            }
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        private static bool IsAllRemoved()
        {
            foreach (var item in livroC.ListaLivros)
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

        private static void ReturnUsuarioIDLogin(Usuarios usuario)
        {
            if(usuario.Ativo == true)
                Console.WriteLine(usuario.Login == usuarioLogado ? $"ID: {usuario.Id} / USUÁRIO: {usuario.Login} -> USUÁRIO LOGADO" : $"ID: {usuario.Id} / USUÁRIO: {usuario.Login}");
        }

        private static void ListUsuarios()
        {
            Console.Clear();
            Console.WriteLine("------ LISTAGEM DE USUÁRIOS ------");
            if (usuC.ListaUsuarios == null || usuC.ListaUsuarios.Count == 0)
                Console.WriteLine("Não existem usuários cadastrados!");
            else
            {
                usuC.ListaUsuarios.ForEach(i => ReturnUsuarioIDLogin(i));
            }
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        private static void RegisterUsuarios()
        {
            Console.Clear();
            Console.WriteLine("------ CADASTRO DE USUÁRIOS ------");

            usuC.ListaUsuarios.Add(new Usuarios()
            {
                Id = UsuarioController.Id,
                Login = TakeLoginUsuario(),
                Senha = TakePasswordUsuario(),
                Ativo = true
            });

            UsuarioController.Id++;
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        private static string TakeLoginUsuario()
        {
            var login = "";
            var flag = true;
            while (flag)
            {
                flag = false;
                Console.Write("Digite o login do usuário: ");
                login = Console.ReadLine();
                foreach (var item in usuC.ListaUsuarios)
                {
                    if (item.Login == login)
                    {
                        flag = true;
                        Console.WriteLine("Já existe um usuário com esse login, tente com outro login");
                        break;
                    }
                }
            }
            return login;
        }

        private static string TakePasswordUsuario()
        {
            Console.Write("Digite a senha do usuário: ");
            return Console.ReadLine();
        }


    }
}
