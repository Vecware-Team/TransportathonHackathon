using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.CrossCuttingConcerns.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly, Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            List<Type> types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (Type t in types)
                if (addWithLifeCycle is null)
                    services.AddScoped(t);
                else
                    addWithLifeCycle(services, t);

            return services;
        }
    }
}
