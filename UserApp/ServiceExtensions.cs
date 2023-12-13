using UserBAL;
using UserDAL;
using UserModel;
using Microsoft.Extensions.DependencyInjection;
namespace UserApp
{
    public static class ServiceExtensions
    {
            public static void RegisterRepos(this IServiceCollection collection, ConfigurationManager configuration)
            {
                var connectionString = configuration["ConnectionStrings:UserConStr"];
                collection.AddTransient<IUserRegService, UserRegService>();
                collection.AddTransient<IUserRegRepo>(s => new UserRegRepo(connectionString));
                
                collection.AddTransient<IProductBLL, ProductBLL>();
                collection.AddTransient<IProductDAL>(s => new ProductDAL(connectionString));
        }
            public static void RegisterLogging(this IServiceCollection collection)
            {
                //Register logging

            }

            public static void RegisterAuth(this IServiceCollection collection)
            {
                //Register authentication services.

            }
        }
}
