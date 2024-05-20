using P2_EnricoEMedina.Model;
using System.ComponentModel.DataAnnotations;

namespace P2_EnricoEMedina.DTO
{
    public class ItemRequest
    {
        [MinLength(4)]
        public string Nome { get; set; }
        [Required]
        public double Valor { get; set; }

        public ItemPedido toModel()
            => new ItemPedido(Nome, Valor);
    }
}
