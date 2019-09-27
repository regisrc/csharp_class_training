using ListagemDeCervejas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListagemDeCervejas.Controller
{
    public class CervejaController
    {
        public SistemaCervejaContext sistemaCervejaContext = new SistemaCervejaContext();

        public void ListInfo(List<Cerveja> listaCerveja) => listaCerveja.ForEach(i => Console.WriteLine(string.Format(ReturnTemplate(), i.Id, i.Marca, i.Litros, i.Alcool, i.Valor.ToString("C2"))));

        public void ListValorTotal() => Console.WriteLine($"Valor Total das Cervejas Cadastradas: {sistemaCervejaContext.listaCerveja.Sum(i => i.Valor).ToString("C2")}");

        public void ListLitrosTotal() => Console.WriteLine($"Litros Total das Cervejas Cadastradas: {sistemaCervejaContext.listaCerveja.Sum(i => i.Litros)} Litros");

        /// <summary>
        /// METODO PRINCIPAL, USE ELE XD
        /// </summary>
        public void ShowMenu()
        {
            do
            {
                Console.Write(
            "MENU DE CERVEJAS DA AMBEV" +
            "\n0 - SAIR" +
            "\n1 - LISTA CERVEJAS" +
            "\n2 - ADICIONAR CERVEJA                             " +
            "\n3 - LISTA VALOR TOTAL DE CERVEJAS CADASTRADAS     " +
            "\n4 - LISTA LITROS TOTAL DE CERVEJAS CADASTRADAS    " +
            "\n5 - VERIFICA SE VOCÊ ESTÁ APTO A SER PRESO        " +
            "\nDigite a opção: ");
            } while (ValidateMenu());
        }

        public bool ValidateMenu()
        {
            switch (Console.ReadKey().KeyChar.ToString())
            {
                case "0":
                    return false;
                case "1":
                    Console.Clear();
                    ListInfo(sistemaCervejaContext.listaCerveja);
                    WaitForRead();
                    return true;
                case "2":
                    Console.Clear();
                    AddBeer();
                    WaitForRead();
                    return true;
                case "3":
                    Console.Clear();
                    ListValorTotal();
                    WaitForRead();
                    return true;
                case "4":
                    Console.Clear();
                    ListLitrosTotal();
                    WaitForRead();
                    return true;
                case "5":
                    Console.Clear();
                    CalculateBeerBlood();
                    WaitForRead();
                    return true;
                default:
                    return false;
            }
        }

        public void WaitForRead()
        {
            Console.Write("------- PRESSIONE QUALQUER TECLA PARA SAIR -------");
            Console.ReadKey();
            Console.Clear();
        }

        public void AddBeer() =>
            sistemaCervejaContext.listaCerveja.Add(
                    new Cerveja()
                    {
                        Id = sistemaCervejaContext.IdAutoGerado++,
                        Marca = RequestMarca(),
                        Litros = RequestLitros(),
                        Alcool = RequestTeorAlcool(),
                        Valor = RequestValor()
                    }
                );

        public string RequestMarca()
        {
            Console.Write("Digite a marca da cerveja: ");
            return Console.ReadLine();
        }

        public void CalculateBeerBlood()
        {
            var cervejas = (sistemaCervejaContext.listaCerveja.Sum(i => i.Litros * 1000) * sistemaCervejaContext.listaCerveja.Sum(i => i.Alcool / 100)) * 0.79;
            var cervejaComPeso = cervejas / (RequestWeight() * 1.1);
            Console.WriteLine(cervejaComPeso);
            if (cervejaComPeso > 0.05)
                Console.WriteLine("SE TA LOCÃO MENOR, PARA DE BEBER, OLHA A PF AI");
            else
                Console.WriteLine("Bebe mais ( ͡° ͜ʖ ͡°)");
        }

        public double RequestWeight()
        {
            Console.Write("Digite o seu peso: ");
            return double.Parse(Console.ReadLine());
        }

        public double RequestLitros()
        {
            Console.Write("Digite o litro da cerveja: ");
            return double.Parse(Console.ReadLine());
        }

        public double RequestTeorAlcool()
        {
            Console.Write("Digite o teor alcoólico da cerveja: ");
            return double.Parse(Console.ReadLine());
        }

        public double RequestValor()
        {
            Console.Write("Digite o valor da cerveja: ");
            return double.Parse(Console.ReadLine());
        }

        public string ReturnTemplate() => "Id {0,-3} | Marca {1,-15} | Litros {2,-6}L | Teor Alcoólico {3,4}% | Valor {4,-5}";
    }
}
