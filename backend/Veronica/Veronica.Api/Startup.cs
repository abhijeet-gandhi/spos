using Microsoft.EntityFrameworkCore;
using Veronica.Menu;
using Veronica.Menu.Data;
using Veronica.Menu.Models;
using Veronica.Order;
using Veronica.Order.Data;
using Veronica.Order.Models;

namespace Veronica.Api
{
    public class Startup
    {
        private string _allowBlackWidow = "blackwidow";
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(_allowBlackWidow, policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "myApi";
                    options.Authority = "https://localhost:8001";
                });
            RegisterMenuModule(services);
            RegisterOrderModule(services);
        }

        public void RegisterMenuModule(IServiceCollection services)
        {
            services.AddTransient(provider =>
            {
                var option = new DbContextOptionsBuilder<MenuDbContext>()
                .UseInMemoryDatabase(nameof(MenuDbContext))
                .Options;
                return new MenuDbContext(option);
            });
            services.AddTransient<IMenuItemRepository, MenuItemRepository>();
            services.AddTransient<IMenuService, MenuService>();
        }

        public void RegisterOrderModule(IServiceCollection services)
        {
            services.AddTransient(provider =>
            {
                var option = new DbContextOptionsBuilder<OrderDbContext>()
                .UseInMemoryDatabase(nameof(OrderDbContext))
                .Options;
                return new OrderDbContext(option);
            });
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseCors(_allowBlackWidow);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}