
namespace ApiCep.Models
{
    internal class ServicesCep
    {
        public string Cep { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string Service { get; set; }
        public bool Vericacao = false;
    }
}