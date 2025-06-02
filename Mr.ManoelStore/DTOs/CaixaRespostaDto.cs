using System.Text.Json.Serialization;

namespace Mr.ManoelStore.DTOs
{
    public class CaixaRespostaDto
    {
        public string? CaixaId { get; set; }
        public List<string> Produtos { get; set; } = new();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Observacao { get; set; }
    }
}
