using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListagemDeCarros.Controller;

namespace ListarCarrosDoAmigo
{
    class Program
    {
        static void Main(string[] args)
        {
            CarroController carroController = new CarroController();
            carroController.Listar();   
        }
    }
}
