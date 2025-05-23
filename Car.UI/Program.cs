using Car.UI.Services;
using Car.UI.Services.Implementation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Car.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:8080") });

            builder.Services.AddScoped<ICustomerService, CustomerServiceWebApi>();
            builder.Services.AddScoped<IWorkService, WorkServiceWebApi>();
            builder.Services.AddSingleton<IWorkHourEstimationService, WorkHourEstimationService>();

            await builder.Build().RunAsync();
        }
    }
}
