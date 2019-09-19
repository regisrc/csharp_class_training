using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeCadastroDeCarro.Model;

namespace SistemaDeCadastroDeCarro
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartApp();
            }
            catch
            {
                ErrorApp();
            }
            finally
            {
                EndApp();
            }
        }
        public static void StartApp()
        {
            var flag = "";
            var listaCarros = new List<Carros>();
            while (flag != "sair")
            {
                StartAppMesssage();
                flag = ReturnMarca();
                if (flag != "sair")
                {
                    var carro = new Carros();
                    carro.Marca = flag;
                    carro.Modelo = ReturnModelo();
                    carro.Ano = ReturnAno();
                    carro.Placa = ReturnPlaca();
                    carro.Valor = ReturnValor();
                    listaCarros.Add(carro);
                    Console.Clear();
                }
            }
            listaCarros.ForEach(i => Console.WriteLine($" Marca: {i.Marca} \n\r Modelo: {i.Modelo} \n\r Ano: {i.Ano} \n\r Placa: {i.Placa} \n\r Valor: {i.Valor.ToString("C2",CultureInfo.CreateSpecificCulture("pt-BR"))} \n"));
        }
        public static void EndApp()
        {
            Console.WriteLine("\n----- PRESSIONE QUALQUER TECLA PARA SAIR -----");
            Console.ReadKey();
        }
        public static void ErrorApp()
        {
            Console.WriteLine("--------- OCORREU UM ERRO ---------");
        }
        public static string ReturnModelo()
        {
            Console.Write("Digite o modelo do carro: ");
            return Console.ReadLine();
        }
        public static void StartAppMesssage()
        {
            Console.WriteLine("---- Cadastro de carros ----");
        }
        public static int ReturnAno()
        {
            Int16 variavel = 0;
            bool flag = true;
            while (flag)
            {
                Console.Write("Digite o ano do carro: ");
                variavel = Int16.Parse(Console.ReadLine());
                if (variavel >= DateTime.Now.Year - 100 && variavel <= DateTime.Now.Year)
                    flag = false;
                else
                    Console.WriteLine("Digite corretamente!");
            }
            return variavel;
        }
        public static string ReturnPlaca()
        {
            string variavel = "";
            bool flag = true;
            bool isWorking = true;
            while (flag)
            {
                Console.Write("Digite a placa do carro: ");
                variavel = Console.ReadLine().Replace("-", "");
                variavel = variavel.Trim();
                if (variavel.Length == 7)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Int32.TryParse(variavel[i].ToString(), out int num);
                        if (num != 0)
                        {
                            isWorking = false;
                        }
                        if (isWorking == false)
                            i = variavel.Length;
                    }
                    for (int i = variavel.Length - 1; i > 4; i--)
                    {

                        if (!Int32.TryParse(variavel[i].ToString(), out int num))
                        {
                            isWorking = false;
                        }
                        if (isWorking == false)
                            i = 0;
                    }
                    if (isWorking)
                    {
                        if (!Int32.TryParse(variavel.Substring(4, 1), out int numero) && Int32.TryParse(variavel.Substring(3, 1), out int nume))
                            flag = false;
                        else if (Int32.TryParse(variavel.Substring(4, 1), out int numer) && Int32.TryParse(variavel.Substring(3, 1), out int numeros))
                        {
                            variavel = $"{variavel.Substring(0, 3)}-{variavel.Substring(3)}";
                            flag = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Digite corretamente");
                    }
                }
                else
                    Console.WriteLine("Digite corretamente!");
            }
            return variavel.ToUpper();
        }
        public static double ReturnValor()
        {
            int variavel = 0;
            bool flag = true;
            while (flag)
            {
                Console.Write("Digite o valor do carro: R$");
                variavel = int.Parse(Console.ReadLine());
                if (variavel > 0 && variavel <= int.MaxValue)
                    flag = false;
                else
                    Console.WriteLine("Digite corretamente!");
            }
            return variavel;
        }
        public static string ReturnMarca()
        {
            string variavel = "";
            bool flag = true;
            bool isWorking = true;
            while (flag)
            {
                Console.Write("Digite a marca do carro (para fim digite 'sair'): ");
                variavel = Console.ReadLine();
                for (int i = 0; i < variavel.Length; i++)
                {
                    Int32.TryParse(variavel[i].ToString(), out int numero);
                    if (numero != 0)
                    {
                        Console.WriteLine("Digite corretamente");
                        isWorking = false;
                    }
                    if (isWorking == false)
                        i = variavel.Length;
                }
                if (isWorking)
                    flag = false;
                isWorking = true;
            }
            return variavel;
        }
    }
}
