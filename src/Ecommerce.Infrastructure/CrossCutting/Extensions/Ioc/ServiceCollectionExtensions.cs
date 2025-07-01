using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Mappers;
using Ecommerce.Domain.Core.Interfaces.Repositories;
using Ecommerce.Domain.Core.Services;
using Ecommerce.Domain.Mappers.Interfaces;
using Ecommerce.Domain.Model;
using Ecommerce.Domain.Services;
using Ecommerce.Infrastructure.Data.Repositories;
using Raven.Client.Documents.Operations;

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

        public static IServiceCollection AddRepositories(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddSingleton<ICustomerRepository, CustomerRepository>();
            return servicesCollection;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddScoped<ICustomerService, CustomerService>();
            return servicesCollection;
        }

        public static IServiceCollection AddMappers(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddScoped<IMapper<Customer, CustomerDto>, CustomerMapper>();
            servicesCollection.TryAddScoped<IMapper<CustomerDto, Customer>, CustomerMapper>();

            return servicesCollection;
        }

        public static IServiceCollection AddAplicationServices(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddScoped<ICustomerApplicationService, ICustomerApplicationService>();

            return servicesCollection;
        }
    }
}