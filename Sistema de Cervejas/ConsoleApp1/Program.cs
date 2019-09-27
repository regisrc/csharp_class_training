using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListagemDeCervejas.Controller;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CervejaController cervejaController = new CervejaController();
            cervejaController.ShowMenu();
        }
    }
}
