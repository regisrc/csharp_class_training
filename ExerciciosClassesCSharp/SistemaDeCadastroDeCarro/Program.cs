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
            listaCarros.ForEach(i => Console.WriteLine($" Marca: {i.Marca} \n\r Modelo: {i.Modelo} \n\r Ano: {i.Ano} \n\r Placa: {i.Placa} \n\r Valor: {i.Valor.ToString("C2", CultureInfo.CreateSpecificCulture("pt-BR"))} \n"));
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
            string variavel = "";
            bool flag = true;
            while (flag)
            {
                Console.Write("Digite o ano do carro: ");
                variavel = Console.ReadLine();
                if (TestingCaracters(variavel, 0))
                {
                    if (int.Parse(variavel) >= DateTime.Now.Year - 100 && int.Parse(variavel) <= DateTime.Now.Year)
                        flag = false;
                    else
                        ShowError(flag, "o Ano");
                }
                else
                    ShowError(flag, "o Ano");
            }
            return int.Parse(variavel);
        }

        /// <summary>
        /// Metodo para formatar a placa (nova ou antiga)
        /// </summary>
        /// <returns>Placa formatada</returns>
        public static string ReturnPlaca()
        {
            string placa = "";
            bool flag = true;
            bool error = false;
            while (flag)
            {
                Console.Write("Digite a placa do carro: ");
                placa = Console.ReadLine().Replace("-", "").Replace(" ", "");
                if (placa.Length == 7)
                {
                    if (TestingCaracters(placa.Substring(0, 3), 1) && TestingCaracters(placa.Substring(placa.Length - 2), 0))
                    {
                        if (TestingCaracters(placa.Substring(3, 1), 0) && TestingCaracters(placa.Substring(4, 1), 1))
                            flag = false;
                        else if (TestingCaracters(placa.Substring(3, 1), 0) && TestingCaracters(placa.Substring(4, 1), 0))
                        {
                            flag = false;
                            placa = $"{placa.Substring(0, 3)}-{placa.Substring(3)}";
                        }
                        else
                            error = true;
                    }
                    else
                        error = true;
                }
                else
                    error = true;
                error = ShowError(error, "a Placa");
            }
            return placa.ToUpper();
        }

        /// <summary>
        /// Classe para teste de caracteres
        /// </summary>
        /// <param name="palavra">Palavra a ser testada (Utilizar substring e/ou toString)</param>
        /// <param name="type">0 - int, 1 - string</param>
        /// <returns>Retorna se a palavra testada tem todas as letras iguais ao tipo</returns>
        public static bool TestingCaracters(string palavra, int type)
        {
            var QuantidadeCaracteres = 0;
            for (int i = 0; i < palavra.Length; i++)
            {
                switch (type)
                {
                    case 0:
                        if (Char.IsNumber(palavra, i))
                            QuantidadeCaracteres++;
                        break;
                    case 1:
                        if (!Char.IsNumber(palavra, i))
                            QuantidadeCaracteres++;
                        break;
                    default:
                        break;
                }
            }
            return QuantidadeCaracteres == palavra.Length;
        }

        public static bool ShowError(bool IfError, string contexto)
        {
            if (IfError) Console.WriteLine($"Digite {contexto} corretamente");
            return false;
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
