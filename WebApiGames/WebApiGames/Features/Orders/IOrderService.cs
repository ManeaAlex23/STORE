using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGames.Features.Orders
{
    public interface IOrderService
    {
        public Task<int> Create(string deliveraddr, string city, int gameId, string userid, bool isProcces, bool isDelivered, string currentCurrierLocation, int rentHours, string clientPhone, string currierPhone);

        public Task<IEnumerable<OrdersListRequestModel>> GetOrders(string userId);

        public Task<bool> UpdateOrder(int id,string deliveraddr, string city, int gameId, string userid, bool isProcces, bool isDelivered, string currentCurrierLocation, int rentHours, string clientPhone, string currierPhone);

        public Task<bool> DeleteGame(int id, string userId);
        
        //public Task<IEnumerable<OrdersListRequestModel>> GetOrdersByUser(string userId);
    }
}
