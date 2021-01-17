using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiGames.Data.Models;
using WebApiGames.Infrastructure.Services;

namespace WebApiGames.Features.Orders
{
    public class OrdersController : ApiController
    {
        private readonly IOrderService orderService;
        private readonly ICurrentUserService currentUser;

        public OrdersController(
            IOrderService orderService,
            ICurrentUserService currentUser)
        {
            this.currentUser = currentUser;
            this.orderService = orderService;
        }

     


        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult<int>> Create(CreateOrderRequestModel model)
        {
            var userId = this.currentUser.GetId();
            
            var orderId = await this.orderService.Create(
                
                model.DeliverAdress,
                model.City,
                model.GameId,
                userId,
                model.IsProcesed,
                model.IsDelivered,
                model.CurrentCurierLocation,
                model.RentedHours,
                model.ClientPhoneNumber,
                model.CurrierPhoneNumber
                );

            return Created(nameof(this.Create), orderId);

        }


   
            
            [Authorize]
            [HttpGet]

            public async Task<IEnumerable<OrdersListRequestModel>> GetOrders()
            {
                var userId = this.currentUser.GetId();

                var orders = await this.orderService.GetOrders(userId);

                return orders;
            }

            [Authorize]
            [HttpGet]
            [Route("/user")]
            public async Task<IEnumerable<OrderListRequestByUserModel>> GetOrdersByUser()
            {
                var userId = this.currentUser.GetId();

                var orders = await this.orderService.GetOrdersByUser(userId);

                return orders;
            }

            [Authorize]
            [HttpPut]

            public async Task<ActionResult> UpdateOrder(OrderUpdateRequestModel model)
            {
            var userId = this.currentUser.GetId();

            var updated = await this.orderService.UpdateOrder(
                                      model.Id,
                                      model.DeliverAdress,
                                      model.City,        
                                      model.GameId,
                                      userId,
                                      model.IsProcesed,
                                      model.IsDelivered,
                                      model.CurrentCurierLocation,
                                      model.RentedHours,
                                      model.ClientPhoneNumber,
                                      model.CurrierPhoneNumber                      
                                      );
                  if (!updated)
                  {
                      return BadRequest();
                  }
                  return Ok();
            
            }

            [Authorize]
            [HttpDelete]
            [Route("{id}")]

            public async Task<ActionResult> DeleteOrder(int id)
            {
                var userId = this.currentUser.GetId();

            var deleted = await this.orderService.DeleteGame(id, userId);

            if (!deleted)
            {
                return BadRequest();
            }
            return Ok();

            }


        

      /*      public async Task<IEnumerable<OrderListRequestByUserModel>> GetOrdersByUser()
            {
                var userId = this.currentUser.GetId();

                var ordersbyUserId = await this.orderService.GetOrdersByUser(userId);

                return ordersbyUserId;
            }
        */

 
    


    }
}
