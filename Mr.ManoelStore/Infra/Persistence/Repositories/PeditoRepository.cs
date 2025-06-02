using Mr.ManoelStore.Infra;
using Mr.ManoelStore.Models;

namespace Mr.ManoelStore.Repositories
{
    public class PeditoRepository : IPeditoRepository
    {
        private readonly MrManoelStoreDbContext _context;

        public PeditoRepository(MrManoelStoreDbContext context)
        {
            _context = context;
        }

        public int Insert(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return pedido.PedidoId;
        }
        public void Update(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
        }
        public void Delete(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
        }
        public Pedido? GetById(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Pedido> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
