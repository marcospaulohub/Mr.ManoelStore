using System.Text.Json.Serialization;

namespace Mr.ManoelStore.Models
{
    public class Produto
    {
        [JsonPropertyName("produto_id")]
        public string ProdutoId { get; set; } = string.Empty;

        [JsonPropertyName("dimensoes")]
        public Dimensoes Dimensoes { get; set; } = new();

        public int Volume => Dimensoes.Altura * Dimensoes.Largura * Dimensoes.Comprimento;
    }
}
