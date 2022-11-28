using Serilog;

namespace Veronica.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                    Host.CreateDefaultBuilder(args)
                        .UseSerilog()
                        .ConfigureWebHostDefaults(webBuilder =>
                        {
                            webBuilder.UseKestrel((host, options) =>
                            {
                                options.ListenAnyIP(8010);
                            });
                            webBuilder.UseStartup<Startup>();
                        });
    }
}