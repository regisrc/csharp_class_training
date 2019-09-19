using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercicioAmigaozao.Model;

namespace ExercicioAmigaozao
{
    class Program
    {
        static void Main(string[] args)
        {
            var listaAmigo = new List<Amigos>
            {
                new Amigos()
                {
                    Nome = "Filipe",
                    TempoAmizade = 15
                },
                new Amigos()
                {
                    Nome = "Naju",
                    TempoAmizade = 2
                },
                new Amigos()
                {
                    Nome = "Vilson",
                    TempoAmizade = 4
                }
            };
            listaAmigo.ForEach(i => Console.WriteLine($"Nome: {i.Nome}     Tempo Amizade: {i.TempoAmizade}"));
            Console.ReadKey();
        }
    }
}
