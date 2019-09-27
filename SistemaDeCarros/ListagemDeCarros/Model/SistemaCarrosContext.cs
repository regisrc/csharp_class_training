using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListagemDeCarros.Model
{
    public class SistemaCarrosContext
    {
        public int Id { get; set; } = 1;
        public List<Carro> listaCarro { get; set; }

        public SistemaCarrosContext()
        {
            listaCarro = new List<Carro>()
            {
                new Carro()
                {
                    Id = this.Id++,
                    Marca = "Renault",
                    Modelo = "Fluence",
                    Ano = 2019,
                    Cilindradas = 400,
                    Portas = 4
                },
                new Carro()
                {
                    Id = this.Id++,
                    Marca = "Peugeout",
                    Modelo = "308",
                    Ano = 2015,
                    Cilindradas = 200,
                    Portas = 2
                },
                new Carro()
                {
                    Id = this.Id++,
                    Marca = "Fiat",
                    Modelo = "Uno",
                    Ano = 2014,
                    Cilindradas = 1200,
                    Portas = 2
                },
                new Carro()
                {
                    Id = this.Id++,
                    Marca = "Chevrolet",
                    Modelo = "Jaguar",
                    Ano = 2004,
                    Cilindradas = 400,
                    Portas = 4
                },
                new Carro()
                {
                    Id = this.Id++,
                    Marca = "Toro",
                    Modelo = "Fusca",
                    Ano = 2019,
                    Cilindradas = 400,
                    Portas = 4
                },
                new Carro()
                {
                    Id = this.Id++,
                    Marca = "Flamengo",
                    Modelo = "Ganso",
                    Ano = 2019,
                    Cilindradas = 400,
                    Portas = 4
                },
                new Carro()
                {
                    Id = this.Id++,
                    Marca = "Citroen",
                    Modelo = "C4 Pallas",
                    Ano = 2019,
                    Cilindradas = 400,
                    Portas = 4
                },
                new Carro()
                {
                    Id = this.Id++,
                    Marca = "Ford",
                    Modelo = "KA",
                    Ano = 2019,
                    Cilindradas = 400,
                    Portas = 4
                },
                new Carro()
                {
                    Id = this.Id++,
                    Marca = "Ford",
                    Modelo = "Fusion",
                    Ano = 2019,
                    Cilindradas = 400,
                    Portas = 4
                },
                new Carro()
                {
                    Id = this.Id++,
                    Marca = "RangeRover",
                    Modelo = "LandRover",
                    Ano = 2077,
                    Cilindradas = 100000,
                    Portas = 0
                }
            };
        }
    }
}
