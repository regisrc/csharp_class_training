using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01
{
    public class PessoasController
    {
        public PessoasController()
        {
            listaPessoas = new List<Pessoas>
            {
                new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Spears",
                    DataNascimento = DateTime.Parse("07/11/2004"),
                    Carteira = 846.96
                },
                new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Swanson",
                    DataNascimento = DateTime.Parse("20/06/2003"),
                    Carteira = 233.09
                },
                new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Gay",
                    DataNascimento = DateTime.Parse("03/12/2001"),
                    Carteira = 911.92
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Gregory",
                    DataNascimento = DateTime.Parse("02/01/2000"),
                    Carteira = 469.01
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Olson",
                    DataNascimento = DateTime.Parse("18/07/2001"),
                    Carteira = 261.90
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Garza",
                    DataNascimento = DateTime.Parse("01/04/2000"),
                    Carteira = 360.41
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Sweet",
                    DataNascimento = DateTime.Parse("12/03/2003"),
                    Carteira = 312.76
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Cline",
                    DataNascimento = DateTime.Parse("26/03/2002"),
                    Carteira = 484.51
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Oliver",
                    DataNascimento = DateTime.Parse("05/07/2004"),
                    Carteira = 513.76
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Vang",
                    DataNascimento = DateTime.Parse("10/07/2000"),
                    Carteira = 271.05
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Maddox",
                    DataNascimento = DateTime.Parse("29/05/2004"),
                    Carteira = 783.97
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Garrett",
                    DataNascimento = DateTime.Parse("03/06/2006"),
                    Carteira = 154.11
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Mcintosh",
                    DataNascimento = DateTime.Parse("06/07/2006"),
                    Carteira = 902.80
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Yang",
                    DataNascimento = DateTime.Parse("29/04/2005"),
                    Carteira = 550.48
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Hendricks",
                    DataNascimento = DateTime.Parse("05/09/2003"),
                    Carteira = 410.56
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Cain",
                    DataNascimento = DateTime.Parse("12/01/2002"),
                    Carteira = 221.13
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Blackburn",
                    DataNascimento = DateTime.Parse("10/05/2000"),
                    Carteira = 135.67
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Howe",
                    DataNascimento = DateTime.Parse("27/09/2005"),
                    Carteira = 360.14
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Pratt",
                    DataNascimento = DateTime.Parse("18/09/2000"),
                    Carteira = 991.83
                },new Pessoas()
                {
                    Id = ++PessoasController.Id,
                    Nome = "Sherman",
                    DataNascimento = DateTime.Parse("20/02/2003"),
                    Carteira = 667.00
                },
            };
        }

        public static int Id { get; set; }
        public List<Pessoas> listaPessoas { get; set; }
    }
}
