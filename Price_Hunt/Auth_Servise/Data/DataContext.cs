using Auth_Servise.Model;
using Microsoft.EntityFrameworkCore;

namespace Auth_Servise.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }

        public DbSet<User> Users { get; set; }  
        public DbSet<Token> Tokens { get; set; }
        public DbSet<TypeUser> UserTypes { get; set; }
    }
}
