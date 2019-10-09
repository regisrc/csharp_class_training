using LocacaoBiblioteca.Model;
using System.Collections.Generic;
using System;
using System.Linq;

namespace LocacaoBiblioteca.Controller
{
    public class UsuarioController
    {

        static LivrosContextDB UsuarioDB = new LivrosContextDB();

        public IQueryable<Usuarios> GetUsuarios() => UsuarioDB.Usuarios.Where(x => x.Ativo == true);

        /// <summary>
        /// Metodo para realizar o login no sistema, login padrão:
        /// - Login: admin
        /// - Senha: admin
        /// </summary>
        /// <param name="login">Login do usuário dentro do sistema</param>
        /// <param name="senha">Senha do usuário dentro do sistema</param>
        /// <returns>Retorna se login e senha condizem com o cadastrado</returns>

        public bool VerifyAllLoginPassword(Usuarios usuario) => UsuarioDB.Usuarios.ToList<Usuarios>().Exists(x => x.Login == usuario.Login && x.Senha == usuario.Senha);

        public void ExcluirUsuario()
        {
            Console.Clear();
            Console.WriteLine("------ REMOÇÃO DE USUÁRIOS ------");
            Console.Write("Digite o login do usuário: ");
            var usuarioItem = Console.ReadLine();
            bool removed = false;
            bool usuLogado = false;
            var usuario = UsuarioDB.Usuarios.FirstOrDefault(i => i.Login == usuarioItem);
            if (usuario != null)
            {
                if (usuario.Login != LocacaoContext.usuarioLogado)
                {
                    removed = true;
                    usuario.Ativo = false;
                    UsuarioDB.SaveChanges();
                }
                else
                {
                    usuLogado = true;
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

        public void AtualizarUsuario()
        {
            Console.Clear();
            Console.WriteLine("------ ATULIZAÇÃO DE USUÁRIOS ------");
            Console.Write("Digite o login do usuário: ");
            var usuarioItem = Console.ReadLine();
            bool removed = false;
            bool usuLogado = false;
            var usuario = UsuarioDB.Usuarios.FirstOrDefault(i => i.Login == usuarioItem);
            if (usuario != null)
            {
                if (usuario.Login != LocacaoContext.usuarioLogado)
                {
                    removed = true;
                    usuario.Ativo = false;
                    UsuarioDB.SaveChanges();
                }
                else
                {
                    usuLogado = true;
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
            if (UsuarioDB.Usuarios.ToList<Usuarios>() == null || UsuarioDB.Usuarios.ToList<Usuarios>().Count == 0)
                Console.WriteLine("Não existem usuários cadastrados!");
            else
            {
                UsuarioDB.Usuarios.ToList<Usuarios>().ForEach(i => ReturnUsuarioIDLogin(i));
            }
            Console.WriteLine("------ PRESSIONE QUALQUER TECLA PARA SAIR ------");
        }

        public void RegisterUsuarios(int usuarioLogado)
        {
            Console.Clear();
            Console.WriteLine("------ CADASTRO DE USUÁRIOS ------");

            UsuarioDB.Usuarios.Add(new Usuarios()
            {
                Login = TakeLoginUsuario(),
                Senha = TakePasswordUsuario(),
                Ativo = true,
                UsuarioAlteracao = usuarioLogado,
                UsuarioCriacao = usuarioLogado
            });
            UsuarioDB.SaveChanges();
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
                foreach (var item in UsuarioDB.Usuarios.ToList<Usuarios>())
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
