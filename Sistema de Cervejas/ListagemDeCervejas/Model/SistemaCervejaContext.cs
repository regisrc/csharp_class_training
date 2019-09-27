using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListagemDeCervejas.Model
{
    public class SistemaCervejaContext
    {
        public List<Cerveja> listaCerveja { get; set; }
        public int IdAutoGerado { get; set; } = 1;

        public SistemaCervejaContext()
        {
            listaCerveja = new List<Cerveja>()
            {
                new Cerveja()
                {
                    Id = IdAutoGerado++,
                    Marca = "Skol",
                    Alcool = 4.7,
                    Litros = 1,
                    Valor = 6.80
                },
                new Cerveja()
                {
                    Id = IdAutoGerado++,
                    Marca = "Brahma",
                    Alcool = 4.8,
                    Litros = 0.6,
                    Valor = 6.20
                },
                new Cerveja()
                {
                    Id = IdAutoGerado++,
                    Marca = "Budweiser",
                    Alcool = 5,
                    Litros = 0.35,
                    Valor = 2.95
                },
                new Cerveja()
                {
                    Id = IdAutoGerado++,
                    Marca = "Bohemia",
                    Alcool = 6,
                    Litros = 0.35,
                    Valor = 2.75
                },
                new Cerveja()
                {
                    Id = IdAutoGerado++,
                    Marca = "Corona",
                    Alcool = 4.6,
                    Litros = 0.355,
                    Valor = 5.40
                }
            };
        }
    }
}
