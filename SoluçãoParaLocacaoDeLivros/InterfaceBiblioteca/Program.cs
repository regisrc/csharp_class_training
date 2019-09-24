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
                LocacaoContext.usuarioLogado = usuario.Login;
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
            Console.WriteLine($"MENU SISTEMA - BEM VINDO - {LocacaoContext.usuarioLogado}");
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
                    usuC.ListUsuarios();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                case "3":
                    livroC.ListLivros();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                case "4":
                    livroC.RegisterLivros();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                case "5":
                    usuC.RegisterUsuarios();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                case "6":
                    livroC.ExcluirLivro();
                    Console.ReadKey();
                    livroC.ListLivros();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                case "7":
                    usuC.ExcluirUsuario();
                    Console.ReadKey();
                    usuC.ListUsuarios();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                default:
                    break;
            }
        }

    }
}
