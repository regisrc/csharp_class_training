using LocacaoBiblioteca.Model;
using System.Collections.Generic;

namespace LocacaoBiblioteca.Controller
{
    public class UsuarioController
    {
        public UsuarioController()
        {
            ListaUsuarios = new List<Usuarios>
            {
                new Usuarios()
                {
                    Login = "admin",
                    Senha = "admin"
                }
            };
        }

        public List<Usuarios> ListaUsuarios { get; set; }

        /// <summary>
        /// Metodo para realizar o login no sistema, login padrão:
        /// - Login: admin
        /// - Senha: admin
        /// </summary>
        /// <param name="login">Login do usuário dentro do sistema</param>
        /// <param name="senha">Senha do usuário dentro do sistema</param>
        /// <returns>Retorna se login e senha condizem com o cadastrado</returns>

        public bool VerifyAllLoginPassword(Usuarios usuario) => ListaUsuarios.Exists(x => x.Login == usuario.Login && x.Senha == usuario.Senha);

    }
}
