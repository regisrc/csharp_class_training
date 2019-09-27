using System;
using ListagemDeCarros.Controller;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CarroController carroController = new CarroController();
            carroController.Listar().ForEach(i => Console.WriteLine($"id {i.Id}  marca {i.Marca}  modelo {i.Modelo}"));
        }
    }
}
