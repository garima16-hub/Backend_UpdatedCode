using _3DModels.Models;
using System.Collections.Generic;

namespace _3DModels.Repository
{
    public interface IOrders
    {
        List<Orders> GetAllOrders();
        Orders GetOrdersById(int order_id);
        void CreateOrders(Orders  orders);
        void UpdateOrdersl(Orders orders);
        void DeleteOrders(int order_id);
    }
}
