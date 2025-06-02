using Mr.ManoelStore.DTOs;

namespace Mr.ManoelStore.Services
{
    public interface IPedidoService
    {
        PedidoResponseDto Empacotar(PedidoRequestDto request);
    }
}
