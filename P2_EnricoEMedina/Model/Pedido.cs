using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_EnricoEMedina.Model
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        [ForeignKey("ItemPedido")]
        public int ItemPedidoId { get; set; }
        public ItemPedido ItemPedido { get; set; }

        public Pedido(string nome, int itemPedidoId)
        {
            Nome = nome;
            ItemPedidoId = itemPedidoId;
        }
    }
}
