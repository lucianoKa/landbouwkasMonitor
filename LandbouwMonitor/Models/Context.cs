using System.Data.Entity;

namespace LBM
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(Settings.DbConnectionString) { }

        public DbSet<EF.Metadata> Metadata { get; set; }
        public DbSet<EF.Meting> Metingen { get; set; }
        public DbSet<EF.Zone> Zones { get; set; }
        public DbSet<EF.Gewas> Gewassen { get; set; }

        public DbSet<EF.Marge> Marges { get; set; }
    }
}
