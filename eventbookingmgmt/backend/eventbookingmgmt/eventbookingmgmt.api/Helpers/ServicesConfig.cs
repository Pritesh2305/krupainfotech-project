using eventbookingmgmt.api.Middleware;
using eventbookingmgmt.repository;
using eventbookingmgmt.repository.Implementation;
using eventbookingmgmt.repository.Interface;
using eventbookingmgmt.services.Implementation;
using eventbookingmgmt.services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;


namespace eventbookingmgmt.api.Helpers
{
    public static class ServicesConfig
    {
        public static void AddExtensionServices(this IServiceCollection services)
        {
            services.AddMydbcontextContext();
            services.AddScoped(typeof(IUserClientCodeService), typeof(UserClientCodeService));
            services.AddScoped(typeof(ImstusersRepository), typeof(mstusersRepository));
            services.AddScoped(typeof(ImstusersService), typeof(mstusersService));
            services.AddScoped(typeof(ImstcityRepository), typeof(mstcityRepository));
            services.AddScoped(typeof(ImstcityService), typeof(mstcityService));
            services.AddScoped(typeof(ImststateRepository), typeof(mststateRepository));
            services.AddScoped(typeof(ImststateService), typeof(mststateService));
            services.AddScoped(typeof(ImstcountryRepository), typeof(mstcountryRepository));
            services.AddScoped(typeof(ImstcountryService), typeof(mstcountryService));
            services.AddScoped(typeof(ImstlocationRepository), typeof(mstlocationRepository));
            services.AddScoped(typeof(ImstlocationService), typeof(mstlocationService));
            services.AddScoped(typeof(ImstguestRepository), typeof(mstguestRepository));
            services.AddScoped(typeof(ImstguestService), typeof(mstguestService));


        }

        public static void AddMydbcontextContext(this IServiceCollection services)
        {
            services.TryAdd(ServiceDescriptor.Describe(
                serviceType: typeof(Mydbcontext),
                implementationFactory: serviceProvider => BuildDbContext(serviceProvider),
                lifetime: ServiceLifetime.Scoped));
        }

        private static Mydbcontext BuildDbContext(IServiceProvider serviceProvider)
        {
            var userClientCodeService = serviceProvider.GetRequiredService<IUserClientCodeService>();
            if (string.IsNullOrWhiteSpace(userClientCodeService.ClientCode))
            {
                throw new Exception("Clientcode not found");
            }
            var connectionString = GetConnectionString(serviceProvider, userClientCodeService.ClientCode);
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("Connection string not found, Clientcode may be wrong");
            }
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<Mydbcontext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);
            return new Mydbcontext(dbContextOptionsBuilder.Options);
        }

        private static string? GetConnectionString(IServiceProvider serviceProvider, string clientCode)
        {
            var connectionStringProvider = serviceProvider.GetRequiredService<IConnectionStringProvider>();
            return connectionStringProvider.GetConnectionString(clientCode);
            
        }       
    }
  
    public interface IConnectionStringProvider
    {
        string GetConnectionString(string clientCode);
    }

    public sealed class CachedConnectionStringProvider(Masterdbcontext masterDbContext, TimeSpan? cacheDuration = null) : IConnectionStringProvider
    {
        private readonly object _lock = new();
        private readonly Masterdbcontext masterDbContext = masterDbContext;
        private readonly TimeSpan _cacheDuration = cacheDuration ?? TimeSpan.FromHours(24);
        private DateTime _expiresAtUtc = DateTime.MinValue;     

        private Dictionary<string, string> _clientConnectionStrings = new Dictionary<string, string>();

        public string GetConnectionString(string clientCode)
        {
            lock (_lock)
            {
                if (DateTime.UtcNow >= _expiresAtUtc)
                {
                    _clientConnectionStrings.Clear();
                }

                if (_clientConnectionStrings.TryGetValue(clientCode, out var connstr))
                {
                    return connstr;
                }

                if (_clientConnectionStrings.Count == 0)
                {
                    _expiresAtUtc = DateTime.UtcNow.Add(_cacheDuration);
                }

                var dbConnString = masterDbContext.mstuserinfo.Where(x => x.clientcode == clientCode).Select(x => x.connstr).FirstOrDefault() + "";
                _clientConnectionStrings.TryAdd(clientCode, dbConnString);
                return dbConnString;
            }
        }
    }
}
