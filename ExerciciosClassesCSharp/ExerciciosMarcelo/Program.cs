using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosMarcelo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numeros = new List<int>();
            Random rdm = new Random();

            for (int i = 0; i < 10; i++)
            {
                int valorGeradoAleatoriamente = rdm.Next(10);
                if (!numeros.Contains(valorGeradoAleatoriamente))
                {
                    numeros.Add(valorGeradoAleatoriamente);
                }
                else
                {
                    i--;
                }
                
            }
            numeros.ForEach(i => Console.WriteLine(i));
            Console.ReadLine();
        }
    }
}
