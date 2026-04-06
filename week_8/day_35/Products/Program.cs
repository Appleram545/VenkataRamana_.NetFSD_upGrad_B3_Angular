using Products.Repositories;

namespace Products
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services
            builder.Services.AddControllersWithViews();

            // Dependency Injection
            builder.Services.AddTransient<IProductRepository, ProductRepository>();

            var app = builder.Build();

            // Error handling
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Middleware
            app.UseHttpsRedirection();
            app.UseStaticFiles();   // ✅ IMPORTANT
            app.UseRouting();
            app.UseAuthorization();

            // Routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}