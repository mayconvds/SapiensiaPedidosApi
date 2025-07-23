using Pedidos.Api.Models;

namespace Pedidos.Api.Repository;

public interface IOrdersRepository
{
    Task<List<Orders>> GetAll();
    
    Task<bool> AddOrder(Orders orders);
}