using P2_EnricoEMedina.Model;

namespace P2_EnricoEMedina.DTO
{
    public class PedidoResponse
    {
        public string Nome { get; set; }
        public ItemPedido ItemPedido { get; set; }

        public PedidoResponse(Pedido pedido) 
        {
            Nome = pedido.Nome;
            ItemPedido = pedido.ItemPedido;
        }
    }
}
