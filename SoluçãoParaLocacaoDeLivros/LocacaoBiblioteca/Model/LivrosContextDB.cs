using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoBiblioteca.Model
{
    public class LivrosContextDB : DbContext
    {
        public DbSet<Livros> Livros { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
