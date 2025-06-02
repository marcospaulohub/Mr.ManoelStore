using Mr.ManoelStore.Models;

namespace Mr.ManoelStore.DTOs
{
    public class PedidoRequestDto
    {
        public List<Pedido> Pedidos { get; set; } = new();
    }
}
