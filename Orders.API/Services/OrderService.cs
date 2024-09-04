using OrdersInfo.API.IServices;
using OrdersInfo.API.Models;

namespace OrdersInfo.API.Services
{
    public class OrderService : IOrderService
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

        public void CreateOrder(Order order)
        {
            Orders.Add(order);
        }

        public void DeleteOrder(int id)
        {
            var orderfound = Orders.Find(x => x.Id == id);
            var index = Orders.IndexOf(orderfound);

            Orders.RemoveAt(index);
        }

        public List<Order> GetOrders()
        {
            return Orders;
        }

        public List<Order> GetOrdersById(int id)
        {
            return Orders.Where(x => x.Id == id).ToList<Order>();
        }

        public void UpdateOrder(int id, Order order)
        {
            var orderfound = Orders.Find(x => x.Id == id);
            var index = Orders.IndexOf(orderfound);

            Orders[index] = order;
        }
    }
}
