using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumLink
{
    class Program
    {
        static void Main(string[] args)
        {
            SomaBalasListaDeCriancas();
            Console.ReadKey();
        }

        private static void SomarInteirosPrimitivos()
        {
            int[] colecaoInteiros = new int[5] { 1, 2, 3, 4, 5 };

            Console.WriteLine(colecaoInteiros.Sum());
        }

        private static void SomaBalasListaDeCriancas()
        {
            List<Crianca> criancas = new List<Crianca>()
            {
                new Crianca()
                {
                    Nome = "Joaozinho",
                    Balas = 9
                },
                new Crianca()
                {
                    Nome = "Pedrinho",
                    Balas = 68
                }
            };

            Console.WriteLine(criancas.Sum(x => x.Balas));

        }
    }
}
