using Microsoft.EntityFrameworkCore;

namespace EFCore1.DBContext
{
    public class Emerald1Context:DbContext
    {
        DBHelper dbh = new DBHelper();

        // Models we want to become tables
        //public DbSet<Pets> Pets { get; set; }
        //public DbSet<Table2> Table2 { get; set; }
        public DbSet<GroupApi.Test> TestLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(dbh._conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }



    }
}
