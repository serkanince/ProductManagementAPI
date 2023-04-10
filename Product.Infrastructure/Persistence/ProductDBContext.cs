using Microsoft.EntityFrameworkCore;
using Product.Domain.Entites;

namespace Product.Infrastructure.Persistence
{
    public class ProductDBContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }

        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }

        //
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseLazyLoadingProxies().UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=ProductDB;Pooling=false;Timeout=1024;CommandTimeout=1024;");
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifyDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>(x => x.HasData(new CategoryEntity()
            {
                CategoryId = 1,
                Name = "Mobile Phone",
                MinimumStock = 200,
                CreateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
            }));

            modelBuilder.Entity<CategoryEntity>(x => x.HasData(new CategoryEntity()
            {
                CategoryId = 2,
                Name = "PC",
                MinimumStock = 150,
                CreateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
            }));

            modelBuilder.Entity<ProductEntity>(x => x.HasData(new ProductEntity()
            {
                ProductId = 1,
                Title = "iPhone 14",
                Description = "Best mobile phone ever, buy it !",
                Stock = 100,
                CategoryId = 1,
                CreateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
            }, new ProductEntity()
            {
                ProductId = 2,
                Title = "iPhone 14 PRO",
                Description = "Best mobile phone ever, buy it !",
                Stock = 100,
                CategoryId = 1,
                CreateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
            }, new ProductEntity()
            {
                ProductId = 3,
                Title = "Mac M1 128GB",
                Description = "Best personel computer ever, buy it !",
                Stock = 100,
                CategoryId = 2,
                CreateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
            }, new ProductEntity()
            {
                ProductId = 4,
                Title = "Mac M2 256GB",
                Description = "Best personel computer ever, buy it !",
                Stock = 100,
                CategoryId = 2,
                CreateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
            }));
        }
    }
}
