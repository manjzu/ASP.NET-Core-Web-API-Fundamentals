using Microsoft.AspNetCore.Mvc;
using OrdersInfo.API.IServices;
using OrdersInfo.API.Models;

namespace OrdersInfo.API.Controllers
{
    //[Route("api/v{version:apiVersion}/orders")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //[Route("api/Orders")]
        [HttpGet]
        public IActionResult GetOrders()
        {            
            return Ok(_orderService.GetOrders());
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOrder(int id)
        {
            var orders = _orderService.GetOrdersById(id); 

            if (!orders.Any())
                return NotFound(orders);

            return Ok(orders);
        }

        // PUT: api/Orders/001
        [HttpPut("{id}")]
        public IActionResult PutOrder([FromRoute] int id, [FromBody] Order order)
        {
            _orderService.UpdateOrder(id, order);

            return Ok();
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult PostOrder([FromBody] Order order)
        {
            _orderService.CreateOrder(order);            

            return Created();
        }

        // DELETE: api/Orders/001
        [HttpDelete("{id}")]
        public IActionResult DeleteOrders([FromRoute] int id)
        {
            _orderService.DeleteOrder(id);

            return Ok();
        }
    }
}
