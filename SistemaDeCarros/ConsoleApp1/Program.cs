using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListagemDeCarros.Controller;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CarroController carroControler = new CarroController();
            carroControler.ListCarros();
            Console.ReadKey();
        }
    }
}
