using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mr.ManoelStore.DTOs;
using Mr.ManoelStore.Services;

namespace Mr.ManoelStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [Authorize]
        [HttpPost("empacotar")]
        public IActionResult EmpacotarPedidos([FromBody] PedidoRequestDto request)
        {
            var resultado = _pedidoService.Empacotar(request);

            return Ok(resultado);
        }
    }
}
