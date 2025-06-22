namespace Ecommerce.Infrastructure.CrossCutting.Extensions.Ioc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRavenDb(this IServiceCollection servicesCollection)
        {

            servicesCollection.TryAddSingleton<IDocumentStore>(ctx =>
            {
                var ravenDbSettings = ctx.GetRequiredService<IOptions<RavenDbSettings>>().Value;
                
                var store = new DocumentStore
                {
                    Urls = new[] { ravenDbSettings.Url },
                    Database = ravenDbSettings.DatabaseName
                };

                store.Initialize();

                return store;
            });

            return servicesCollection;
        }
    }
}