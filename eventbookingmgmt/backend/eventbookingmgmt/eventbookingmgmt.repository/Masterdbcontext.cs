using eventbookingmgmt.repository.masterdb;
using Microsoft.EntityFrameworkCore;

namespace eventbookingmgmt.repository
{
    public class Masterdbcontext : DbContext
    {
        public Masterdbcontext()
        {            
        }
        public Masterdbcontext(DbContextOptions<Masterdbcontext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Dbmstuserinfo> mstuserinfo { get; set; }
    }
}
