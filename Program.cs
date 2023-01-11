
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
            }
            else
            {
                Console.WriteLine("Cep nao encontrado!");
            }
        }
    }
}
