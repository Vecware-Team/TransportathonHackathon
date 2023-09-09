using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns.IoC
{
    public class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceProvider Build(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return ServiceProvider;
        }

        public static IServiceProvider SetSetviceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            return ServiceProvider;
        }
    }
}
