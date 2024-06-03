using API_P2.Model;
using System.ComponentModel.DataAnnotations;

namespace API_P2.DTO
{
    public class EntregaRequest
    {
        [Required]
        public string Motorista { get; set; }
        [Required]
        public string Destino { get; set; }
        [Required]
        public string Status { get; set; }
        public string Observacao { get; set; }


        public Entrega toModel()
            => new Entrega(Motorista, Destino, Status, Observacao);
    }
}