using Hackathon.Service;

public static class WebAppHoster
{
    public static void HostWebApp<TStartup>(string[] args, int port) where TStartup : class
    {
        CreateHostBuilder<TStartup>(args, port).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder<TStartup>(string[] args, int port) where TStartup : class
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<TStartup>();
                webBuilder.UseUrls($"http://*:{port}");
            });
    }

}
public class Program
{
    public const int PORT = 8097;

    public static void Main(string[] args)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

        //int port = ConfigurationUtils.GetDefinedPort(config, PORT);
        int port = PORT;

        WebAppHoster.HostWebApp<Startup>(args, port);
    }

    // EF will look for a CreateHostBuilder method in Program. If it finds it, it won't call Main
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        Console.WriteLine("Doing Entity Framework migrations, not starting full application");
        return Host.CreateDefaultBuilder();
    }
}
