using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGames.Data.Models;

namespace WebApiGames.Features.Orders
{
    public class OrderService:IOrderService
    {

        private readonly UserDbContext data;

        public OrderService(UserDbContext data)
        {
            this.data = data;
        }

        public async Task<int> Create(string deliveraddr, string city, int gameId, string userid, bool isProcces, bool isDelivered, string currentCurrierLocation, int rentHours, string clientPhone, string currierPhone)
        {
            var order = new OrdersReq
            {
                DeliverAdress = deliveraddr,
                City = city,
                GameId = gameId,
                UserId = userid,
                IsProcesed = isProcces,
                IsDelivered = isDelivered,
                CurrentCurierLocation = currentCurrierLocation,
                RentedHours = rentHours,
                ClientPhoneNumber = clientPhone,
                CurrierPhoneNumber = currierPhone
            };
            this.data.Add(order);

            await this.data.SaveChangesAsync();

            return order.Id;

        }

/*        public async Task<IEnumerable<OrderListRequestByUserModel>> GetOrdersByUser(string userId)
            => await this.data
                       .Orders
                       .Where(o => o.UserId == userId)
                       .OrderByDescending(o => o.CreatedOn)
                       .Select(o => new OrdersListRequestModel
                       {
                           Id = o.Id,
                           DeliverAdress = o.DeliverAdress,
                           City = o.City,
                           GameId = o.GameId,
                           IsProcesed = o.IsProcesed,
                           IsDelivered = o.IsDelivered,
                           CurrentCurierLocation = o.CurrentCurierLocation,
                           RentedHours = o.RentedHours,
                           ClientPhoneNumber = o.ClientPhoneNumber,
                           CurrierPhoneNumber = o.CurrierPhoneNumber

                       })
                       .ToListAsync();*/

        public async Task<IEnumerable<OrdersListRequestModel>> GetOrders(string userId)
           => await this.data
                      .Orders
                      .Where(o=>o.UserId==userId)
                      .OrderByDescending(o => o.CreatedOn)
                      .Select(o => new OrdersListRequestModel
                      {
                          Id = o.Id,
                          DeliverAdress = o.DeliverAdress,
                          City = o.City,
                          GameId = o.GameId,
                          IsProcesed = o.IsProcesed,
                          IsDelivered = o.IsDelivered,
                          CurrentCurierLocation = o.CurrentCurierLocation,
                          RentedHours = o.RentedHours,
                          ClientPhoneNumber = o.ClientPhoneNumber,
                          CurrierPhoneNumber = o.CurrierPhoneNumber

                      })
                      .ToListAsync();

        public async Task<IEnumerable<OrderListRequestByUserModel>> GetOrdersByUser(string userId)
                => await this.data
                            .Orders
                            .Where(o => o.UserId == userId)
                            .OrderByDescending(o => o.CreatedOn)
                            .Select(o => new OrderListRequestByUserModel
                            {
                                Id = o.Id,
                                DeliverAdress = o.DeliverAdress,
                                City = o.City,
                                GameId = o.GameId,
                                IsProcesed = o.IsProcesed,
                                CurrentCurierLocation =o .CurrentCurierLocation,
                                RentedHours = o.RentedHours,
                                ClientPhoneNumber = o.ClientPhoneNumber,
                                CurrierPhoneNumber = o.CurrierPhoneNumber

                            })
                            .ToListAsync();


        public async Task<bool> UpdateOrder(int id,string deliveraddr, string city, int gameId, string userid, bool isProcces, bool isDelivered, string currentCurrierLocation, int rentHours, string clientPhone, string currierPhone)
        {
            var order = await this.data
                            .Orders
                            .Where(o => o.Id == id && o.GameId == gameId)
                            .FirstOrDefaultAsync();

                if(order == null)
            {
                return false;
            }
            order.DeliverAdress = deliveraddr;
            order.City = city;
            order.GameId = gameId;
            order.IsProcesed = isProcces;
            order.IsDelivered = isDelivered;
            order.CurrentCurierLocation = currentCurrierLocation;
            order.RentedHours = rentHours;
            order.ClientPhoneNumber = clientPhone;
            order.CurrierPhoneNumber = currierPhone;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteGame(int id, string userId)
        {
            var order = await this.data
                            .Orders
                            .Where(o => o.Id == id)
                            .FirstOrDefaultAsync();

                if(order == null)
            {
                return false;
            }
            this.data.Orders.Remove(order);

            await this.data.SaveChangesAsync();

            return true;
        }
    }
}
