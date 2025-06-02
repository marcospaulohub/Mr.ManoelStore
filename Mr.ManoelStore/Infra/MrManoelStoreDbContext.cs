using Microsoft.EntityFrameworkCore;
using Mr.ManoelStore.Models;

namespace Mr.ManoelStore.Infra
{
    public class MrManoelStoreDbContext : DbContext
    {
        public MrManoelStoreDbContext(DbContextOptions<MrManoelStoreDbContext> options)
            : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<CaixaDisponivel>();
            builder.Ignore<Dimensoes>();


            builder.Entity<Pedido>().OwnsMany(p => p.Produtos, p =>
            {
                p.OwnsOne(prod => prod.Dimensoes);
            });


            base.OnModelCreating(builder);
        }
    }
}
