using Microsoft.Extensions.DependencyInjection;
//using Client.RestClients;
using Microsoft.Extensions.Hosting;
using Refit;
using TaskClient.RestClients;

namespace TaskClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<MainForm>());
        }
        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<MainForm>();
                    services.AddRefitClient<IServakRestClient>().ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:7114"));
                });
        }
    }
}