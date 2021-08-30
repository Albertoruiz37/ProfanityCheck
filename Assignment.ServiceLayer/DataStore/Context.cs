using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Assignment.ServiceLayer.DataStore
{
    /// <summary>
    /// Context handling class.
    /// </summary>
    public class Context : DbContext
    {
        private string _connectionString;
        public Context(string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\alruiz\source\Repos\ProfanityCheckAssignment\Assignment.ServiceLayer\DataStore\Database.mdf;Integrated Security=True")
        {
            _connectionString = connectionString;
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Word> Words { get; set; }
    }
}
