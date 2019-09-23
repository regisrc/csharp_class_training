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
            ListaLivros = new List<Livros>();
        }

        public static int Id { get; set; }
        public List<Livros> ListaLivros { get; set; }
    }


}
