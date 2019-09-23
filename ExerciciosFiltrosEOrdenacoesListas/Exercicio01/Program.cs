using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            PessoasController pessoasController = new PessoasController();

            #region Exercicio1
            Console.WriteLine("LISTA CRESCENTE POR NOME");
            pessoasController.listaPessoas.OrderBy(x => x.Nome).ToList<Pessoas>().ForEach(i => Console.WriteLine(String.Format("{0,-4}: {1,-20} {2,-2}: {3,-3}", "Nome", i.Nome, "Id", i.Id)));
            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine("LISTA DECRESCENTE POR DATA DE NASCIMENTO");
            pessoasController.listaPessoas.OrderByDescending(x => x.DataNascimento).ToList<Pessoas>().ForEach(i => Console.WriteLine($"Data Nascimento: {i.DataNascimento.ToShortDateString()} - Nome: {i.Nome}"));
            #endregion

            #region Exercicio2
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("LISTA DE PESSOAS COM MAIS DE 500 REAIS NA CARTEIRA"); 
            pessoasController.listaPessoas.Where(x => x.Carteira > 500).ToList<Pessoas>().ForEach(i => Console.WriteLine(String.Format("{0,-4}: {1,-20} {2,-8}: {3,-8}", "Nome", i.Nome, "Carteira", i.Carteira.ToString("C2", CultureInfo.CreateSpecificCulture("pt-BR")))));
            #endregion

            #region Exercicio3
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("LISTA DE PESSOAS COM MAIS DE 18 ANOS");
            pessoasController.listaPessoas.Where(x => (DateTime.Now.Year - x.DataNascimento.Year) > 18).ToList<Pessoas>().ForEach(i => Console.WriteLine(String.Format("{0,-4}: {1,-20} {2,-5}: {3,-3}", "Nome", i.Nome, "Idade", DateTime.Now.Year - i.DataNascimento.Year)));
            #endregion

            #region Exercicio4
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("LISTA DE PESSOAS COM MENOS DE 16 ANOS");
            pessoasController.listaPessoas.Where(x => (DateTime.Now.Year - x.DataNascimento.Year) < 16).ToList<Pessoas>().ForEach(i => Console.WriteLine(String.Format("{0,-4}: {1,-20} {2,-5}: {3,-3}", "Nome", i.Nome, "Idade", DateTime.Now.Year - i.DataNascimento.Year)));
            #endregion

            Console.ReadKey();


        }
    }
}
