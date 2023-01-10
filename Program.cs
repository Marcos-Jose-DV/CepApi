
using ApiCep.Models;
using ApiCep.Models.Service;

namespace ApiCep
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Informe o id: ");
            string cep = (Console.ReadLine());

            ServicesApi servicesApi = new ServicesApi();
            ServicesCep cepEncontrado = await servicesApi.Integracao(cep);

            if (!cepEncontrado.Vericacao)
            {
                Console.WriteLine("Aluno Encontrado");

                Console.WriteLine("Cep: " + cepEncontrado.Cep);
                Console.WriteLine("Cidade: " + cepEncontrado.City);
                Console.WriteLine("Rua: " + cepEncontrado.Street);
            }
            else
            {
                Console.WriteLine("Cep nao encontrado!");
            }
        }
    }
}