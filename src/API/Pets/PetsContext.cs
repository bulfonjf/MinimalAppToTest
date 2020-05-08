using Microsoft.EntityFrameworkCore;

namespace PetsAPI.Pets
{
    public class PetsContext : DbContext
    {
        public PetsContext(DbContextOptions<PetsContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PetsDataBase;Integrated Security=SSPI;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Pet>().HasKey(x => x.Id);
        }

        public DbSet<Pet> Pets { get; set; }
    }
}