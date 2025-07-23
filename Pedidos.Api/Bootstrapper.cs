using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Infraestructure;
using Pedidos.Api.Repository;

namespace Pedidos.Api;

public static class Bootstrapper
{
    public static void AddInfraestructure(this IServiceCollection services, IConfiguration configurationManage)
    {
        services.AddScoped<IOrdersRepository, OrdersRepository>();
        var connectionString = configurationManage.GetConnectionString("DefaultConnection");
        Console.WriteLine(connectionString);
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
    }
}