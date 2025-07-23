using Microsoft.AspNetCore.Mvc;
using Pedidos.Api.Dto;
using Pedidos.Api.Repository;

namespace Pedidos.Api.Controllers.Orders;

public class OrdersController : ApplicationController
{
    private readonly IOrdersRepository _ordersRepository;
    public OrdersController(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var getOrderList = await _ordersRepository.GetAll();
        GenericResponse<List<Models.Orders>> message = new GenericResponse<List<Models.Orders>>(getOrderList);
        
        return Ok(message);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Models.Orders order)
    {
        if (!ModelState.IsValid)
        {
            var message = new GenericResponse<object>(new
            {
                message = "Parâmetros inválidos."
            });
            return BadRequest(message);
        }
        
        
        
        bool add = await _ordersRepository.AddOrder(order);
        if (!add)
        {
            var messageFailed = new GenericResponse<object>(new
            {
                message = "Falha ao salvar no banco de dados."
            });
            return BadRequest(messageFailed);
        }
        
        var messageSuccess = new GenericResponse<object>(new
        {
            message = "Parâmetros inválidos."
        });
        return Ok(messageSuccess);
    }
    
    
}