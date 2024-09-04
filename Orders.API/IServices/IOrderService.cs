using OrdersInfo.API.Models;

namespace OrdersInfo.API.IServices
{
    public interface IOrderService
    {
        public List<Order> GetOrdersById(int id);

        public List<Order> GetOrders();

        public void UpdateOrder(int id, Order order);

        public void CreateOrder(Order order);

        public void DeleteOrder(int id);
    }
}
