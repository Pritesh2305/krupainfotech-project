
using eventbookingmgmt.repository.Mydb;
using Microsoft.EntityFrameworkCore;

namespace eventbookingmgmt.repository
{
    public class Mydbcontext : DbContext
    {
        public Mydbcontext()
        {
        }
        public Mydbcontext(DbContextOptions<Mydbcontext> options) : base(options)
        {
        }
        #region DATABASE-TABLE
        public DbSet<Dbmstusers> mstusers { get; set; }
        public DbSet<Dbmstcity> mstcity { get; set; }
        public DbSet<Dbmststate> mststate { get; set; }
        public DbSet<Dbmstcountry> mstcountry { get; set; }
        public DbSet<Dbmstlocation> mstlocation { get; set; }
        public DbSet<Dbmstguest> mstguest { get; set; }

        #endregion

        #region USER-DEFINE-TABLE
        public DbSet<CoUserLogin> couserlogin { get; set; }
        public DbSet<Comstcity> comstcity { get; set; }
        public DbSet<Comststate> comststate { get; set; }
        public DbSet<Comstcountry> comstcountry { get; set; }
        public DbSet<Comstlocation> comstlocation { get; set; }
        public DbSet<Comstguest> comstguest { get; set; }

        #endregion
    }
}
