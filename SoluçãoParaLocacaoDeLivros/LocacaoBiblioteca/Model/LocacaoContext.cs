using LocacaoBiblioteca.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoBiblioteca.Model
{
    public static class LocacaoContext
    {
        public static List<Usuarios> ListaUsuarios { get; set; }
        public static List<Livros> ListaLivros { get; set; }

        public static string usuarioLogado;


    }
}
