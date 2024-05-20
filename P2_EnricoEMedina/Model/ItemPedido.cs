using System.ComponentModel.DataAnnotations;

namespace P2_EnricoEMedina.Model
{
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        public ItemPedido(string nome, double valor)
        {
            Nome = nome;
            Valor = valor;
        }
    }
}
