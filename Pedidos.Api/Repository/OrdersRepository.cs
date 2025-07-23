using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Infraestructure;
using Pedidos.Api.Models;

namespace Pedidos.Api.Repository;

public class OrdersRepository  : IOrdersRepository
{
    private readonly ApplicationDbContext _context;
    
    public OrdersRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Orders>> GetAll()
    {
        var orders = await _context.Orders.ToListAsync();
        return orders;
    }

    public async Task<bool> AddOrder(Orders orders)
    {
        try
        {
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        
    }
    
}