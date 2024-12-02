using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Dima.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        //esse metodo aplica configurações iniciais ao banco se for sua primeira execucao
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //modelBuilder.ApplyConfiguration();
        }
    }
}
