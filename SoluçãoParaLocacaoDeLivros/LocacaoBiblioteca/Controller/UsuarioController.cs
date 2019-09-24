using LocacaoBiblioteca.Model;
using System.Collections.Generic;
using System;

namespace LocacaoBiblioteca.Controller
{
    public class UsuarioController
    {
        public UsuarioController()
        {
            LocacaoContext.ListaUsuarios = new List<Usuarios>
            {
                new Usuarios()
                {
                    Id = UsuarioController.Id++,
                    Login = "admin",
                    Senha = "admin",
                    Ativo = true
                }
            };
        }

        public static int Id { get; set; }
        

        /// <summary>
        /// Metodo para realizar o login no sistema, login padrão:
        /// - Login: admin
        /// - Senha: admin
        /// </summary>
        /// <param name="login">Login do usuário dentro do sistema</param>
        /// <param name="senha">Senha do usuário dentro do sistema</param>
        /// <returns>Retorna se login e senha condizem com o cadastrado</returns>

        public bool VerifyAllLoginPassword(Usuarios usuario) => LocacaoContext.ListaUsuarios.Exists(x => x.Login == usuario.Login && x.Senha == usuario.Senha);

        public void ExcluirUsuario()
        {
            Console.Clear();
            Console.WriteLine("------ REMOÇÃO DE USUÁRIOS ------");
            Console.Write("Digite o login do usuário: ");
            var usuarioItem = Console.ReadLine();
            bool removed = false;
            bool usuLogado = false;
            foreach (var item in LocacaoContext.ListaUsuarios)
            {
                if (item.Login == usuarioItem)
                {
                    if (item.Login != LocacaoContext.usuarioLogado)
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
                Console.WriteLine($"Usuário: {LocacaoContext.usuarioLogado} não pode ser excluido pois está em uso!");
            else
            {
                if (removed)
                    Console.WriteLine($"Usuário: {usuarioItem} foi excluido com sucesso!");
                else
                    Console.WriteLine($"Usuário: {usuarioItem} não foi encontrado!");
            }
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        private void ReturnUsuarioIDLogin(Usuarios usuario)
        {
            if (usuario.Ativo == true)
                Console.WriteLine(usuario.Login == LocacaoContext.usuarioLogado ? $"ID: {usuario.Id} / USUÁRIO: {usuario.Login} -> USUÁRIO LOGADO" : $"ID: {usuario.Id} / USUÁRIO: {usuario.Login}");
        }

        public void ListUsuarios()
        {
            Console.Clear();
            Console.WriteLine("------ LISTAGEM DE USUÁRIOS ------");
            if (LocacaoContext.ListaUsuarios == null || LocacaoContext.ListaUsuarios.Count == 0)
                Console.WriteLine("Não existem usuários cadastrados!");
            else
            {
                LocacaoContext.ListaUsuarios.ForEach(i => ReturnUsuarioIDLogin(i));
            }
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        public void RegisterUsuarios()
        {
            Console.Clear();
            Console.WriteLine("------ CADASTRO DE USUÁRIOS ------");

            LocacaoContext.ListaUsuarios.Add(new Usuarios()
            {
                Id = UsuarioController.Id,
                Login = TakeLoginUsuario(),
                Senha = TakePasswordUsuario(),
                Ativo = true
            });

            UsuarioController.Id++;
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        public string TakeLoginUsuario()
        {
            var login = "";
            var flag = true;
            while (flag)
            {
                flag = false;
                Console.Write("Digite o login do usuário: ");
                login = Console.ReadLine();
                foreach (var item in LocacaoContext.ListaUsuarios)
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

        public string TakePasswordUsuario()
        {
            Console.Write("Digite a senha do usuário: ");
            return Console.ReadLine();
        }

    }
}
