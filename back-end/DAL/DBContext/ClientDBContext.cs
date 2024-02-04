using System.Reflection;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DBContext
{
    public partial class ClientDBContext : DbContext
    {
        public DbSet<CitizenshipModel> Citizenships { get; set; }
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<DisabilityModel> Disabilities { get; set; }
        public DbSet<MaritalStatusModel> MaritalStatuses { get; set; }
        public DbSet<PersonalInfoModel> PersonalInfos { get; set; }

        public ClientDBContext(DbContextOptions options)
            : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
