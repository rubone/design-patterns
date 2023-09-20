using Factory.Constants;
using Factory.Factory;
using Factory.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Factory.DI;

public static class TransportFactoryBuilderExtensions
{
    public static ITransportFactoryBuilder AddTransportFactory(this IServiceCollection services)
    {
        TransportFactoryBuilder builder = new(services);

        services.AddSingleton<ITransportFactory, TransportFactory>();

        return builder;
    }
    
    public static ITransportFactoryBuilder AddTransport<T>(this ITransportFactoryBuilder builder, TransportType transport) where T : class, ITransport
    {
        builder.Services.AddScoped<T>();

        var provider = builder.Services.BuildServiceProvider();

        var factory = provider.GetRequiredService<ITransportFactory>();

        factory.RegisterTransport(transport, () => provider.GetRequiredService<T>());


        builder.Services.Replace(ServiceDescriptor.Singleton(factory));

        return builder;
    }
}
