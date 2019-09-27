using Exercicio01.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Exercicio01.Controller
{
    public class CarrosController
    {
        public static void ReadExcel()
        {
            OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\hbsis\Desktop\excel.xls;" +
  @"Extended Properties='Excel 8.0;HDR=Yes;'");
            string comandoSql = "Select * from [Worksheet$]";
            OleDbCommand comando = new OleDbCommand(comandoSql, connect);
            try
            {
                connect.Open();
                OleDbDataReader rd = comando.ExecuteReader();

                while (rd.Read())
                {
                    ProgramContext.listaCarro.Add(new Carros()
                    {
                        Id = Convert.ToInt32(rd["id"]),
                        Nome = rd["Nome"].ToString(),
                        Valor = Convert.ToDouble(rd["Valor"]),
                        Quantidade = Convert.ToInt32(rd["Quantidade"]),
                        Data = Convert.ToDateTime(rd["Data"])
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void ExportExcel(List<Carros> carros)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 1] = "Id";
            xlWorkSheet.Cells[1, 2] = "Nome";
            xlWorkSheet.Cells[1, 3] = "Valor";
            xlWorkSheet.Cells[1, 4] = "Quantidade";
            xlWorkSheet.Cells[1, 5] = "Data";
            for (int i = 1; i <= carros.Count; i++)
            {
                xlWorkSheet.Cells[i + 1, 1] = carros[i - 1].Id.ToString();
                xlWorkSheet.Cells[i + 1, 2] = carros[i - 1].Nome;
                xlWorkSheet.Cells[i + 1, 3] = carros[i - 1].Valor.ToString("C3");
                xlWorkSheet.Cells[i + 1, 4] = carros[i - 1].Quantidade.ToString();
                xlWorkSheet.Cells[i + 1, 5] = carros[i - 1].Data.ToShortDateString();
            }
            xlWorkBook.SaveAs("arquivo.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
            Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
        }

        public static string FileName()
        {
            DirectoryInfo Dir = new DirectoryInfo(@"C:\\Users\\hbsis\\Desktop\\tabelas");
            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] Files = Dir.GetFiles("*", SearchOption.AllDirectories);
            var maiorNumero = 0;
            foreach (FileInfo File in Files)
            {
                if (File.FullName.Contains($"arquivo"))
                {
                    if (!(File.FullName.Substring(File.FullName.LastIndexOf("arquivo")).Replace(".html", "") == "arquivo"))
                    {
                        var arqv = File.FullName.Substring(File.FullName.LastIndexOf("arquivo")).Replace(".html", "").Replace("arquivo", "");
                        Int32.TryParse(arqv, out int numero);
                        if (numero > maiorNumero)
                        {
                            maiorNumero = numero;
                        }
                    }
                }
            }
            return $"C:\\Users\\hbsis\\Desktop\\tabelas\\arquivo{maiorNumero + 1}.html";
        }

        public static void ExportHTML(List<Carros> carros)
        {
            StreamWriter sw;
            string CaminhoNome = FileName();
            sw = File.CreateText(CaminhoNome);
            sw.WriteLine("<html>");
            sw.WriteLine("<meta charset=\"UTF - 8\">");
            sw.WriteLine("<title>ARQUIVO TEXTO!</title>");
            sw.WriteLine("<head>");
            sw.WriteLine("<link href=\"//cdn.datatables.net/1.10.15/css/jquery.dataTables.min.css\" rel=\"stylesheet\">");
            sw.WriteLine("</head>");
            sw.WriteLine("<body>");
            sw.WriteLine("<table border=\"1\" style=\"width: 500\">");
            sw.WriteLine("<thead>");
            sw.WriteLine("<th>");
            sw.WriteLine("ID");
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("Nome");
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("Valor");
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("Quantidade");
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("Data");
            sw.WriteLine("</th>");
            sw.WriteLine("</thead>");
            sw.WriteLine("<tbody>");
            for (int i = 0; i < carros.Count; i++)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine("<td>");
                sw.WriteLine(carros[i].Id);
                sw.WriteLine("</td>");
                sw.WriteLine("<td>");
                sw.WriteLine(carros[i].Nome);
                sw.WriteLine("</td>");
                sw.WriteLine("<td>");
                sw.WriteLine(carros[i].Valor.ToString("C3"));
                sw.WriteLine("</td>");
                sw.WriteLine("<td>");
                sw.WriteLine(carros[i].Quantidade);
                sw.WriteLine("</td>");
                sw.WriteLine("<td>");
                sw.WriteLine(carros[i].Data.ToShortDateString());
                sw.WriteLine("</td>");
                sw.WriteLine("</tr>");
            }
            sw.WriteLine("</tbody>");
            sw.WriteLine("</table>");
            sw.WriteLine("</html>");
            sw.WriteLine("</body>");
            sw.Close();
        }
    }
}
