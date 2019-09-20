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
            Console.WriteLine("5 - Logoff");
            Console.WriteLine("4 - Cadastrar Usuários");
            Console.WriteLine("3 - Cadastrar Livros");
            Console.WriteLine("2 - Listar Livros");
            Console.WriteLine("1 - Listar Usuários");
            Console.WriteLine("0 - Sair");
            var situacao = Console.ReadKey().KeyChar.ToString();
            switch (situacao)
            {
                case "1":
                    ListUsuarios();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                case "2":
                    ListLivros();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                case "3":
                    RegisterLivros();
                    Console.ReadKey();
                    ShowSystemMenu(); 
                    break;
                case "4":
                    RegisterUsuarios();
                    Console.ReadKey();
                    ShowSystemMenu();
                    break;
                case "5":
                    Console.Clear();
                    ShowLogin();
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
                Nome = Console.ReadLine()
            });
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        private static void ListLivros()
        {
            Console.Clear();
            Console.WriteLine("------ LISTAGEM DE LIVROS ------");
            if (livroC.ListaLivros == null || livroC.ListaLivros.Count == 0)
                Console.WriteLine("Não existem livros cadastrados!");
            else
            {
                livroC.ListaLivros.ForEach(i => Console.WriteLine($"NOME: {i.Nome}"));
            }
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        private static void ListUsuarios()
        {
            Console.Clear();
            Console.WriteLine("------ LISTAGEM DE USUÁRIOS ------");
            if (usuC.ListaUsuarios == null || usuC.ListaUsuarios.Count == 0)
                Console.WriteLine("Não existem usuários cadastrados!");
            else
            {
                usuC.ListaUsuarios.ForEach(i => Console.WriteLine($"USUÁRIO: {i.Login}"));
            }
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        private static void RegisterUsuarios()
        {
            Console.Clear();
            Console.WriteLine("------ CADASTRO DE USUÁRIOS ------");

            usuC.ListaUsuarios.Add(new Usuarios()
            {
                Login = TakeLoginUsuario(),
                Senha = TakePasswordUsuario()
            });
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        private static string TakeLoginUsuario()
        {
            Console.Write("Digite o login do usuário: ");
            return Console.ReadLine();
        }

        private static string TakePasswordUsuario()
        {
            Console.Write("Digite a senha do usuário: ");
            return Console.ReadLine();
        }


    }
}
