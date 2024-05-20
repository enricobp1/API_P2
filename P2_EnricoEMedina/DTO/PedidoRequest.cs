using P2_EnricoEMedina.Model;
using System.ComponentModel.DataAnnotations;

namespace P2_EnricoEMedina.DTO
{
    public class PedidoRequest
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int ItemId { get; set; }

        public Pedido ToModel()
            => new Pedido(Nome, ItemId);
    }
}
