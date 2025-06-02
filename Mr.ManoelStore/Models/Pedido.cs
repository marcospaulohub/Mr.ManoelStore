using System.Text.Json.Serialization;

namespace Mr.ManoelStore.Models
{
    public class Pedido
    {
        [JsonPropertyName("pedido_id")]
        public int PedidoId { get; set; }

        public List<Produto> Produtos { get; set; } = new();
    }
}
