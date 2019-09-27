using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListagemDeCarros.Model;

namespace ListagemDeCarros.Controller
{
    public class CarroController
    {
        public SistemaCarrosContext sistemaCarrosContext = new SistemaCarrosContext();

        /// <summary>
        /// Metodo para imprimir a lista de carros
        /// </summary>
        public void ListCarros() => sistemaCarrosContext.listaCarro.ForEach(i => Console.WriteLine(string.Format(TemplateList(), i.Id, i.Marca, i.Modelo, i.Ano, i.Cilindradas, i.Portas)));

        private string TemplateList() => "Id: {0,-3} Marca: {1,-12} Modelo: {2,-12} Ano: {3,-6} Cilindradas: {4,-6} Portas: {5,-2}";
    }
}
