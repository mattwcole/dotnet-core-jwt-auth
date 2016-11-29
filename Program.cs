using Microsoft.AspNetCore.Hosting;

namespace AuthDemo
{
    public class Program
    {
        public static void Main()
        {
            var hostBuilder = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseKestrel();

            using (var host = hostBuilder.Build()) {
                host.Run();
            }
        }
    }
}
