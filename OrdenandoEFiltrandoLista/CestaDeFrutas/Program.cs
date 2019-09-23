using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CestaDeFrutas
{
    class Program
    {
        static void Main(string[] args)
        {
            var cestaDeFrutas = new List<Fruta>
            {
                new Fruta()
                {
                    Id = 0,
                    Nome = "Tomate",
                    Cor = "Vermelho",
                    Peso = 212
                },
                new Fruta()
                {
                    Id = 1,
                    Nome = "Goiaba",
                    Cor = "Verde",
                    Peso = 95
                },
                new Fruta()
                {
                    Id = 2,
                    Nome = "Manga",
                    Cor = "Amarelado",
                    Peso = 350
                }
            };

            cestaDeFrutas.OrderByDescending(x => x.Id).ToList<Fruta>().ForEach(i => Console.WriteLine($"Id: {i.Id} Nome: {i.Nome}"));

            Console.WriteLine("");

            var filtroCesta = cestaDeFrutas.Where(x => x.Peso > 100);

            filtroCesta.ToList<Fruta>().ForEach(i => Console.WriteLine(i.Nome));

            var mostrandoFind = cestaDeFrutas.Find(x => x.Cor == "Amarela" || x.Cor == "Vermelha");

            var mostrandoFindAll = cestaDeFrutas.FindAll(x => x.Cor == "Amarela" || x.Cor == "Vermelha");

            var outroFiltro = from Fruta in cestaDeFrutas
                              where Fruta.Nome == "Manga"
                              select Fruta;
            Console.WriteLine("");
            foreach (var item in outroFiltro.ToList<Fruta>())
            {
                Console.WriteLine(item.Nome);
            }
            
            Console.ReadKey();
        }
    }
}
