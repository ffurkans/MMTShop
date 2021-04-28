using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMT.Domain.Abstractions.Services;
using MMT.Domain.Categories;
using MMT.Domain.Products;
using MMT.Infrastructure.EF;
using MMT.Infrastructure.EF.Repositories;
using MMT.Infrastructure.Services;
using MMT.Web.API.Middlewares;

namespace MMT.Web.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped(s => new SqlConnection(Configuration.GetConnectionString("DefaultConnection")));

			services.AddDbContext<MMTContext>((sp, options) =>
			{
				var con = sp.GetService<SqlConnection>();
				options.UseSqlServer(con);
			}, ServiceLifetime.Scoped);
			services.AddSwaggerGen();

			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<ICategoryRepository, CategoryRepository>();

			services.AddTransient<IProductService, ProductService>();
			services.AddTransient<ICategoryService, CategoryService>();

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MMTContext mmtContext)
		{
			mmtContext.Database.Migrate();
			var seeder = new MMTContextSeed();
			seeder.Seed(mmtContext);
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
			});


			app.UseMiddleware<CustomExceptionMiddleware>();

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
