using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ListagemDeCervejas.Model;

namespace ApresentandoOsAlcoolatras
{
    class Program
    {
        static void Main(string[] args)
        {
            Cerveja cerva = new Cerveja();
            Type type = cerva.GetType();

            foreach (PropertyInfo item in type.GetProperties())
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadKey();
        }
        
    }
}
