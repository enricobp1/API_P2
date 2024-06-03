using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_P2.Model
{
    public class Entrega
    {
        [Key]
        public int Id { get; set; }
        public string Motorista { get; set; }
        public string Destino { get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }

        public Entrega(string motorista, string destino, string status, string observacao)
        {
            Motorista = motorista;
            Destino = destino;
            Status = status;
            Observacao = observacao;
        }
    }
}