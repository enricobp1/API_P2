using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_P2.Model
{
    public class Veiculos
    {
        [Key]
        public int Id { get; set; }
        public string Veiculo { get; set; }
        public int Autonomia { get; set; }
        public int Capacidade { get; set; }

        public Veiculos(string veiculo, int autonomia, int capacidade)
        {
            Veiculo = veiculo;
            Autonomia = autonomia;
            Capacidade = capacidade;
        }
    }
}