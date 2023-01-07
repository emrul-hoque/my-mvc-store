using My.Mvc.Store.Data;
using My.Mvc.Store.Domain.Entities;

namespace My.Mvc.Store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            _ = builder.Services.AddRazorPages();
            _ = builder.Services.AddDbContext<ProductDbContext>();

            WebApplication app = builder.Build();


            using (IServiceScope scope = app.Services.CreateScope())
            {
                IServiceProvider provider = scope.ServiceProvider;
                ProductDbContext context = provider.GetRequiredService<ProductDbContext>();
                _ = context.Database.EnsureDeleted();
                _ = context.Database.EnsureCreated();

                context.Products.AddRange(
                    new Product { Id = 1, Name = "Apple", Price = 1.5m, IsAvailable = true },
                    new Product { Id = 2, Name = "Orange", Price = 2.5m, IsAvailable = true },
                    new Product { Id = 3, Name = "Mango", Price = .5m, IsAvailable = true }
                    );

                _ = context.SaveChanges();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                _ = app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                _ = app.UseHsts();
            }

            _ = app.UseHttpsRedirection();
            _ = app.UseStaticFiles();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.MapRazorPages();

            app.Run();
        }
    }
}