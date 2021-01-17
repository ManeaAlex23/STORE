using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe;
using Microsoft.AspNetCore.Authorization;

namespace WebApiGames.Features.MakePayment
{
    public class MakePaymentController : ApiController
    {
        private readonly IMakePaymentInterface paymanetService;

        public MakePaymentController(IMakePaymentInterface paymanetService)
        {
            this.paymanetService = paymanetService;
        }

        [Authorize]
        [HttpPost]
        public async Task<dynamic> PayAsync(CreatePaymentModel model)
        {
            var created = await this.paymanetService.PayAsync(
                    model.cardNumber,
                    model.cardMonth,
                    model.cardYear,
                    model.cvv,
                    model.value);

            return created;
        }

    }
}
