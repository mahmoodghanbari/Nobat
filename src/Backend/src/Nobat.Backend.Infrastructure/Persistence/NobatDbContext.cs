namespace Nobat.Backend.Infrastructure.Persistence
{
    public sealed class NobatDbContext : DbContext
    {
        public NobatDbContext(DbContextOptions<NobatDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.RegisterAllEntities();
			modelBuilder.ApplyAllConfigurations();
			modelBuilder.ApplySoftDeleteFilter();

			base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.EnableDetailedErrors();
            }
        }
    }
}
