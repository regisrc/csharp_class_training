using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeCadastroComListagem.Model;

namespace SistemaDeCadastroComListagem
{
    class Program
    {
        static void Main(string[] args)
        {
            StartApp();
        }
        private static void StartApp()
        {
            try
            {
                var flag = "";
                var listaPessoa = new List<Pessoas>();
                while (flag.ToLower() != "sair")
                {
                    StartAppMessage();
                    flag = ReturnName();
                    if (flag.ToLower() == "sair")
                        continue;
                    else
                    {
                        var pessoa = new Pessoas();
                        pessoa.Nome = flag;
                        pessoa.Idade = ReturnAge();
                        pessoa.Sexo = ReturnSex();
                        pessoa.Altura = ReturnHeight();
                        pessoa.Cpf = ReturnCPF();
                        pessoa.Rg = ReturnRG();
                        listaPessoa.Add(pessoa);
                    }
                    Console.Clear();
                }
                listaPessoa.ForEach(i => Console.WriteLine($"\n Nome: {i.Nome} \n\r Idade: {i.Idade} \n\r Sexo: {i.Sexo} \n\r Altura: {i.Altura} \n\r CPF: {i.Cpf} \n\r RG: {i.Rg} \n"));
            }
            catch
            {
                Console.WriteLine("--------- OCORREU UM ERRO ---------");
            }
            finally
            {
                Console.WriteLine("----- PRESSIONE QUALQUER TECLA PARA SAIR -----");
                Console.ReadKey();
            }
        }
        private static void StartAppMessage()
        {
            Console.WriteLine("-- Cadastrando Pessoa --");
        }
        private static string ReturnName()
        {
            string variavel = "";
            bool flag = true;
            bool isWorking = true;
            int numero = 1;
            while (flag)
            {
                Console.Write("Digite o nome da pessoa (para fim digite 'sair'): ");
                variavel = Console.ReadLine();
                for (int i = 0; i < variavel.Length; i++)
                {
                    Int32.TryParse(variavel[i].ToString(), out numero);
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
        private static int ReturnAge()
        {
            byte variavel = 0;
            bool flag = true;
            while (flag)
            {
                Console.Write("Digite a idade da pessoa: ");
                variavel = byte.Parse(Console.ReadLine());
                if (variavel >= 0 && variavel <= 150)
                    flag = false;
                else
                    Console.WriteLine("Digite corretamente!");
            }
            return variavel;
        }
        private static char ReturnSex()
        {
            char variavel = 'U';
            bool flag = true;
            while (flag)
            {
                Console.Write("Digite o sexo da pessoa (F ou M): ");
                variavel = char.Parse(Console.ReadLine().ToUpper());
                if (variavel == 'M' || variavel == 'F')
                    flag = false;
                else
                    Console.WriteLine("Digite corretamente!");
            }
            return variavel;
        }
        private static double ReturnHeight()
        {
            double variavel = 0.00;
            bool flag = true;
            while (flag)
            {
                Console.Write("Digite a altura da pessoa: ");
                variavel = double.Parse(Console.ReadLine());
                if (variavel >= 0.00 && variavel <= 300)
                    flag = false;
                else
                    Console.WriteLine("Digite corretamente!");
            }
            return variavel;
        }
        private static string ReturnRG()
        {
            var RG = "";
            var numero = 0;
            bool flag = true;
            bool isWorking = true;
            while (flag)
            {
                Console.Write("Digite o RG da pessoa: ");
                RG = RG.Trim();
                RG = Console.ReadLine().Replace(".", "");
                for (int i = 0; i < RG.Length; i++)
                {
                    
                    if (!Int32.TryParse(RG[i].ToString(), out numero))
                    {
                        Console.WriteLine("Digite corretamente");
                        isWorking = false;
                    }
                    if (isWorking == false)
                        i = RG.Length;
                }
                if (isWorking)
                    flag = false;
                isWorking = true;
                if (RG.Length == 7)
                {
                    RG = $"{RG.Substring(0, 1)}.{RG.Substring(1, 3)}.{RG.Substring(4)}";
                }
            }
            return RG;
        }
        private static string ReturnCPF()
        {
            var CPF = "";
            var numero = 0;
            bool flag = true;
            bool isWorking = true;
            while (flag)
            {
                Console.Write("Digite o CPF da pessoa: ");
                CPF = CPF.Trim();
                CPF = Console.ReadLine().Replace(".", "").Replace("-","");
                for (int i = 0; i < CPF.Length; i++)
                {

                    if (!Int32.TryParse(CPF[i].ToString(), out numero) || !IsCpf(CPF))
                    {
                        Console.WriteLine("Digite corretamente");
                        isWorking = false;
                    }
                    if (isWorking == false)
                        i = CPF.Length;
                }
                if (isWorking)
                    flag = false;
                isWorking = true;
                if (CPF.Length == 11)
                {
                    CPF = $"{CPF.Substring(0, 3)}.{CPF.Substring(3, 3)}.{CPF.Substring(6,3)}-{CPF.Substring(9)}";
                }
            }
            return CPF;
        }
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}