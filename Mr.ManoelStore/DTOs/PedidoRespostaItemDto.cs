namespace Mr.ManoelStore.DTOs
{
    public class PedidoRespostaItemDto
    {
        public int PedidoId { get; set; }
        public List<CaixaRespostaDto> Caixas { get; set; } = new();
    }
}
