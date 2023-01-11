
using ApiCep.Models;
using ApiCep.Service;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;

namespace ApiCep
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Write("Informe o Cep: ");
            string cep = (Console.ReadLine());


            ServicesApi servicesApi = new ServicesApi();
            ServicesCep cepEncontrado = await servicesApi.Integracao(cep);


            if (!cepEncontrado.Vericacao)
            {

                Console.WriteLine("Cep: " + cepEncontrado.Cep);
                Console.WriteLine("Estado: " + cepEncontrado.State);
                Console.WriteLine("Cidade: " + cepEncontrado.City);
                Console.WriteLine("Bairo: " + cepEncontrado.Neighborhood);
                Console.WriteLine("Rua: " + cepEncontrado.Street);
                Console.WriteLine("Serviço: " + cepEncontrado.Service);

                CreateExcel(cepEncontrado.Cep);
            }
            else
            {
                Console.WriteLine("Cep nao encontrado!");
            }

        }
        static void CreateExcel(string cep)
        {
            
          
            var ws = new XLWorkbook();
            var planilha = ws.Worksheets.Add("Cep Service");
            var table = planilha.Cell(1, 1).InsertTable(cep, "Cep Service", true);

            ws.SaveAs(@"c:\C#\testeXML.ExcelDinamico.xlsx");
            Process.Start(new ProcessStartInfo(@"c:\C#\testeXML.ExcelDinamico.xlsx") { UseShellExecute = true });

        }
    }

    //static void ListaPastelaria()
    //{
    //    var pastelaria = new List<Pastelaria>()
    //    {
    //      new Pastelaria("Croissant", 150, "Apr"),
    //      new Pastelaria("Croissant", 250, "May"),
    //      new Pastelaria("Croissant", 134, "June"),
    //      new Pastelaria("Doughnut", 250, "Apr"),
    //      new Pastelaria("Doughnut", 225, "May"),
    //      new Pastelaria("Doughnut", 210, "June"),
    //      new Pastelaria("Bearclaw", 134, "Apr"),
    //      new Pastelaria("Bearclaw", 184, "May"),
    //      new Pastelaria("Bearclaw", 124, "June"),
    //      new Pastelaria("Danish", 394, "Apr"),
    //      new Pastelaria("Danish", 190, "May"),
    //      new Pastelaria("Danish", 221, "June"),
    //      new Pastelaria("Scone", 135, "Apr"),

    //    };

    //    Tabela(pastelaria);
    //}
    //static void Tabela(List<Pastelaria> pastelaria)
    //{
    //    var workbook = new XLWorkbook();
    //    var sheet = workbook.Worksheets.Add("Dados de vendas de pastelaria");

    //    // Insert our list of pastry data into the "PastrySalesData" sheet at cell 1,1
    //    var table = sheet.Cell(1, 1).InsertTable(pastelaria, "Dados de vendas de pastelaria", true);


    //    // Add a new sheet for our pivot table
    //    var ptSheet = workbook.Worksheets.Add("Tabela Dinâmica");

    //    // Create the pivot table, using the data from the "PastrySalesData" table
    //    var pt = ptSheet.PivotTables.Add("Tabela Dinâmica", ptSheet.Cell(1, 1), table.AsRange());

    //    // The rows in our pivot table will be the names of the pastries
    //    pt.RowLabels.Add("Name");

    //    // The columns will be the monthm
    //    pt.ColumnLabels.Add("Month");

    //    // The values in our table will come from the "NumberOfOrders" field
    //    // The default calculation setting is a total of each row/column
    //    pt.Values.Add("NumberOfOrders");

    //    var ws = workbook.Worksheets.Add("Column Settings");

    //    var col1 = ws.Column("A");
    //    col1.Style.Fill.BackgroundColor = XLColor.Red;
    //    col1.Width = 20;

    //    workbook.SaveAs(@"c:\C#\testeXML.ExcelDinamico.xlsx");
    //    Process.Start(new ProcessStartInfo(@"c:\C#\testeXML.ExcelDinamico.xlsx") { UseShellExecute = true });

    //}

}
}