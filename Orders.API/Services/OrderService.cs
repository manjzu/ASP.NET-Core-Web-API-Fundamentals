using Microsoft.EntityFrameworkCore;
using OrdersInfo.API.IServices;
using OrdersInfo.API.Models;
using OrdersInfo.API.Models.Data;

namespace OrdersInfo.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApiDbContext _dbContext;
        public OrderService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //private static List<Order> Orders = new List<Order>()
        //{
        //    new Order() {
        //        CustomerName = "John",
        //        Id = 001,
        //        OrderDate = DateTime.Now,
        //        OrderStatus = "Pending",
        //        TotalAmount = 9999}
        //};

        public void CreateOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var orderfound = _dbContext.Orders.AsNoTracking().ToList().Find(x => x.Id == id);

            _dbContext.Orders.RemoveRange(orderfound);
            _dbContext.SaveChanges();
        }

        public List<Order> GetOrders()
        {
            return _dbContext.Orders.AsNoTracking().ToList();
        }

        public List<Order> GetOrdersById(int id)
        {
            return _dbContext.Orders.AsNoTracking().Where(x => x.Id == id).ToList<Order>();
        }

        public void UpdateOrder(int id, Order order)
        {
           // var orderfound = _dbContext.Orders.AsNoTracking().Include(x => x.Id == id).ToList();
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();

        }
    }
}
