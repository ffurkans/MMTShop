using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MMT.Domain;
using MMT.Domain.Abstractions;
using MMT.Domain.Categories;
using MMT.Domain.Products;
using MMT.Infrastructure.EF.EntityConfigurations;
using System;
using System.Threading;
using System.Threading.Tasks;


// dotnet ef migrations Add Initial -c MMTContext -p MMT.Infrastructure -s MMT.Web.API -o "EF/Migrations"
namespace MMT.Infrastructure.EF
{
	public class MMTContext : DbContext, IUnitOfWork
	{
		public DbSet<Product> Product { get; set; }
		public DbSet<Category> Category { get; set; }

		public MMTContext(DbContextOptions<MMTContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			base.OnModelCreating(modelBuilder);
		}

		public Task SaveWithTransactionAsync(IDbContextTransaction transaction)
		{
			if (transaction == null) throw new MMTArgumentNullException(nameof(transaction));
			this.Database.UseTransaction(transaction.GetDbTransaction());
			return SaveChangesAsync();
		}

		public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
		{
			await base.SaveChangesAsync(cancellationToken);
			return true;
		}
	}
}
