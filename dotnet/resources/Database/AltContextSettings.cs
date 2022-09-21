using System;
using System.Linq;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public partial class AltContext
    {
        private static readonly IConfigurationRoot Config;

        static AltContext() => Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        private static string ConnectionString => Config.GetConnectionString("AltDatabase");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(ConnectionString);

        public override int SaveChanges()
        {
            IQueryable<EntityEntry<AbstractModel>> entries = ChangeTracker.Entries<AbstractModel>().AsQueryable();
            IQueryable<EntityEntry<AbstractModel>> models = entries.Where(entityEntry => entityEntry.Entity != null);
            IQueryable<EntityEntry<AbstractModel>> editedModels = models.Where(
                    e => e.State == EntityState.Added || e.State == EntityState.Modified
                );

            foreach (EntityEntry<AbstractModel> entityEntry in editedModels)
            {
                entityEntry.Entity.UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                    entityEntry.Entity.CreatedDate = DateTime.Now;
            }

            return base.SaveChanges();
        }

        public static void ApplyMigration()
        {
            using var db = new AltContext(); 
            db.Database.Migrate();
        }
    }
}