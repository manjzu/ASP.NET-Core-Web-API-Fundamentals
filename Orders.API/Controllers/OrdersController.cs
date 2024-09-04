using Microsoft.AspNetCore.Mvc;
using OrdersInfo.API.Models;

namespace OrdersInfo.API.Controllers
{
    //[Route("api/v{version:apiVersion}/orders")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private static List<Order> Orders = new List<Order>()
        {
            new Order() {
                CustomerName = "John",
                Id = 001,
                OrderDate = DateTime.Now,
                OrderStatus = "Pending",
                TotalAmount = 9999}
        };


        //[Route("api/Orders")]
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(Orders);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetOrder(int id)
        {
            var orders = Orders.Where(x => x.Id == id);

            if (!orders.Any())
                return NotFound(orders);

            return Ok(orders);
        }

        // PUT: api/Orders/001
        [HttpPut("{id}")]
        public IActionResult PutOrder([FromRoute] int id, [FromBody] Order order)
        {
            var orderfound = Orders.Find(x => x.Id == id);
            var index = Orders.IndexOf(orderfound);

            Orders[index] = order;              

            return Ok();
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult PostOrder([FromBody] Order order)
        {
            Orders.Add(order);

            return Created();
        }

        // DELETE: api/Orders/001
        [HttpDelete("{id}")]
        public IActionResult DeleteOrders([FromRoute] int id)
        {
            var orderfound = Orders.Find(x => x.Id == id);
            var index = Orders.IndexOf(orderfound);

            Orders.RemoveAt(index);

            return Ok();
        }
    }
}
