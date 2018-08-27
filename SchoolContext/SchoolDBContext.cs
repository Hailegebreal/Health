using AspNetCoreProject.LeprosyModel;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreProject.DataAccess
{

    class SchoolDBContext : DbContext
    {
        public SchoolDBContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=localhost,1433; Database=LeprosyTest; User=sa; Password =hamlccccet74*;");



        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Artists> Artists { get; set; }
    }
}