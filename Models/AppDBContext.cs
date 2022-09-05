using Microsoft.EntityFrameworkCore;

namespace GamblingAPI.Models
{
    public class AppDbContext : DbContext
    {
        #region Contstructor
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options) => Database.EnsureCreated();
        #endregion

        #region Public properties
        public DbSet<Player> Palyers { get; set; }
        #endregion

        #region Overidden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DBInitializer playersData = new DBInitializer();
            modelBuilder.Entity<Player>().HasData(playersData.Players);
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
