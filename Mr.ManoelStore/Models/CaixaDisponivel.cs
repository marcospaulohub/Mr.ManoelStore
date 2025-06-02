
namespace Mr.ManoelStore.Models
{
    public class CaixaDisponivel
    {
        public string CaixaId { get; set; } = string.Empty;
        public Dimensoes Dimensoes { get; set; } = new();
    }
}
